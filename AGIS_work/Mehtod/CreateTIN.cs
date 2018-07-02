using AGIS_work.DataStructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.Mehtod
{
    public class CreateTIN
    {
        public PointSet mPointSet;


        private PointF[] arrDots;
        private ArrayList arrEdges = new ArrayList();
        private ArrayList arrTris = new ArrayList();

        public CreateTIN(PointSet pointSet)
        {
            this.mPointSet = pointSet;
        }
        
        public Edge[] PointByPointInsertion()
        {
            EdgeSet sEdgeSet = new EdgeSet();
            //int curEID = 0;
            //int curTID = 0;
            TriangleSet sTriangleSet = new TriangleSet();
            MinBoundRect sMBR = this.mPointSet.MBR;
            double width = sMBR.MaxX - sMBR.MinX;
            double height = sMBR.MaxY - sMBR.MinY;
            double middlePointX = (sMBR.MaxX + sMBR.MinX) / 2;
            double middlePointY = sMBR.MinY;
            DataPoint P0 = new DataPoint(-1, "P0", middlePointX - width, middlePointY, 0);
            DataPoint P1 = new DataPoint(-2, "P1", middlePointX + width, middlePointY, 0);
            DataPoint P2 = new DataPoint(-3, "P2", middlePointX, middlePointY + 2 * height, 0);
            Triangle T0 = new Triangle(P0, P1, P2, -1);
            sTriangleSet.AddTriangle(T0);
            sEdgeSet.AddEdge(new Edge(P0, P1));
            sEdgeSet.AddEdge(new Edge(P1, P2));
            sEdgeSet.AddEdge(new Edge(P1, P0));
            foreach (var point in mPointSet.PointList)
            {
                Triangle CurTri = sTriangleSet.GetPointInsidesTri(point);
                if (CurTri != null)
                {

                }
            }
            return sEdgeSet.EdgeList.ToArray();
        }


        public Edge[] EdgeExtension()
        {
            double ang;
            ArrayList tinlines = new ArrayList();
            //定义与第一点最近的点
            List<DataPoint> pointList = this.mPointSet.PointList;
            double mindis = pointList[0].GetDistance(pointList[1]);
            double dis;
            int count = 1;
            TinLine tl = new TinLine();
            for (int i = 1; i < pointList.Count; i++)
            {
                dis = pointList[0].GetDistance(pointList[i]);
                if (dis < mindis)
                {
                    mindis = dis;
                    count = i;
                }
            }
            //将第一条边反向已进行三角形扩展
            tl.Begin = (DataPoint)pointList[0];
            tl.End = (DataPoint)pointList[count];
            tinlines.Add(tl);
            TinLine line = new TinLine();
            DataPoint a = ((TinLine)tinlines[0]).Begin;
            DataPoint b = ((TinLine)tinlines[0]).End;
            line.Begin = b;
            line.End = a;
            tinlines.Add(line);
            //对每一条边进行扩展
            for (int j = 0; j < tinlines.Count; j++)
            {
                double minang = 0;
                bool OK;
                OK = false;
                TinLine tling1 = new TinLine();
                TinLine tling2 = new TinLine();
                for (int i = 0; i < pointList.Count; i++)
                {
                    int youbian;
                    //判断第三点与前两点的位置关系
                    youbian = DataPoint.LeftOrRight((DataPoint)pointList[i], ((TinLine)tinlines[j]).Begin, ((TinLine)tinlines[j]).End);
                    if (youbian == 1)
                    {
                        //获取角度最大点
                        ang = DataPoint.Angle((DataPoint)pointList[i], ((TinLine)tinlines[j]).Begin, ((TinLine)tinlines[j]).End);
                        if (ang > minang)
                        {
                            minang = ang;
                            count = i;
                        }
                        OK = true;
                    }

                }
                if (OK == true)
                {
                    //将新生成两条边添加入集合中
                    int t1 = 0;
                    int t2 = 0;
                    tling1.Begin = ((TinLine)tinlines[j]).Begin;
                    tling1.End = (DataPoint)pointList[count];
                    tling2.Begin = (DataPoint)pointList[count];
                    tling2.End = ((TinLine)tinlines[j]).End;
                    tinlines.Add(tling1);
                    tinlines.Add(tling2);
                    for (int i = 0; i < tinlines.Count - 2; i++)
                    {
                        //判断新生成的两边是否与已生成的边重合
                        if ((tling2.Begin == ((TinLine)tinlines[i]).Begin && tling2.End == ((TinLine)tinlines[i]).End) ||
                            (tling2.Begin == ((TinLine)tinlines[i]).End && tling2.End == ((TinLine)tinlines[i]).Begin))
                        {
                            t2 = 1;
                        }
                        if ((tling1.Begin == ((TinLine)tinlines[i]).Begin && tling1.End == ((TinLine)tinlines[i]).End) ||
                            (tling1.Begin == ((TinLine)tinlines[i]).End && tling1.End == ((TinLine)tinlines[i]).Begin))
                        {
                            t1 = 1;

                        }
                    }
                    //两条边都重合
                    if (t2 == 1 && t1 == 1)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            tinlines.Remove(tinlines[tinlines.Count - 1]);
                        }
                    }
                    //第二条边重合
                    else if (t2 == 1)
                    {
                        tinlines.Remove(tinlines[tinlines.Count - 1]);
                    }
                    //第一条边重合
                    else if (t1 == 1)
                    {
                        tinlines.Remove(tinlines[tinlines.Count - 2]);
                    }
                }
            }
            tinlines.Remove(tinlines[0]);//将集合中的第一条边删除    
            List<Edge> ResultEdge = new List<Edge>();
            int eid = 1;
            foreach (var tinLine in tinlines)
            {
                ResultEdge.Add(new Edge(((TinLine)tinLine).Begin, ((TinLine)tinLine).End));
                eid++;
            }
            return ResultEdge.ToArray();
        }

        public class Edge2
        {
            public int Start;//边的起点 
            public int End;//边的终点 
            public int LeftTri = -1;//左三角形索引 
            public int RightTri = -1;//右三角形索引 
        }
        public class Tri
        {
            public int NodeA;
            public int NodeB;
            public int NodeC;
            public int AdjTriA = -1;
            public int AdjTriB = -1;
            public int AdjTriC = -1;
        }

        public List<Edge> GeneTIN()
        {
            arrEdges.Clear();
            arrTris.Clear();
            arrDots = new PointF[mPointSet.PointList.Count];
            for (int kk = 0; kk < mPointSet.PointList.Count; kk++)
            {
                arrDots[kk] = new PointF((float)mPointSet.PointList[kk].X, (float)mPointSet.PointList[kk].Y);
            }
            int i, idxStart = 0, endTemp, ptindex;
            bool isExist;
            double angMax, angMin, angTemp, angRcdMax, angRcdTmp, lenMin, lenCur, lenTmp1, lenTmp2;
            Edge2 edge = new Edge2();


            //找到边界---（删除不需要的点，从X最小的地方开始找，直至回到起始点） 
            PointF dirCur = new PointF();
            PointF dirTmp1 = new PointF();
            PointF dirTmp2 = new PointF();
            PointF ptStart = new PointF();

            for (i = 1; i < arrDots.Length; i++)
            {
                if (arrDots[i].X < arrDots[idxStart].X)
                {
                    idxStart = i;
                }
            }
            endTemp = idxStart - 1;
            ptStart.X = arrDots[idxStart].X;
            ptStart.Y = arrDots[idxStart].Y;
            edge.Start = idxStart;
            angMin = Math.PI;
            dirCur.X = 0;
            dirCur.Y = 500;
            while (endTemp != idxStart)
            {
                lenCur = Math.Sqrt(dirCur.X * dirCur.X + dirCur.Y * dirCur.Y);
                lenMin = 1000;
                for (i = 0; i < arrDots.Length; i++)//找边界 
                {

                    if (i != edge.Start)
                    {
                        dirTmp1.X = arrDots[i].X - ptStart.X;
                        dirTmp1.Y = arrDots[i].Y - ptStart.Y;
                        lenTmp1 = Math.Sqrt(dirTmp1.X * dirTmp1.X + dirTmp1.Y * dirTmp1.Y);
                        angTemp = Math.Acos((dirCur.X * dirTmp1.X + dirCur.Y * dirTmp1.Y) / (lenTmp1 * lenCur));
                        if (angTemp < angMin)
                        {
                            angMin = angTemp;
                            edge.End = i;
                            lenMin = lenTmp1;
                        }
                        else if (angTemp == angMin && lenTmp1 < lenMin)
                        {
                            edge.End = i;
                            lenMin = lenTmp1;
                        }
                    }
                }
                arrEdges.Add(edge);
                endTemp = edge.End;
                edge = new Edge2();
                angMin = Math.PI;
                dirCur.X = arrDots[endTemp].X - ptStart.X;
                dirCur.Y = arrDots[endTemp].Y - ptStart.Y;
                ptStart = arrDots[endTemp];
                edge.Start = endTemp;
            }
            //以下为自动生成TIN 
            //从第一条边开始，按照先左后右的顺序寻找，找到则加入三角形数组和边数组，没有则继续下一边，直到边到达最后 
            //注意边可能有两种顺序存储。 
            for (i = 0; i < arrEdges.Count; i++)
            {
                //取出一条边 
                edge = new Edge2();
                edge = (Edge2)arrEdges[i];
                //先左后右计算扩展点-判断三角形是否存在过（若本边的左三角已存在，则计算右三角）？？ 
                if (edge.LeftTri == -1)
                {
                    ptindex = -1;//选中的点的index 
                    dirCur.X = arrDots[edge.End].X - arrDots[edge.Start].X;
                    dirCur.Y = arrDots[edge.End].Y - arrDots[edge.Start].Y;
                    angRcdMax = 0;//与该边夹角最大值 
                    angMax = 0;//最大圆内接角 
                    for (int j = 0; j < arrDots.Length; j++)
                    {
                        if (j != edge.Start && j != edge.End)//排除边的端点 
                        {
                            dirTmp1.X = arrDots[j].X - arrDots[edge.Start].X;
                            dirTmp1.Y = arrDots[j].Y - arrDots[edge.Start].Y;
                            if (dirCur.X * dirTmp1.Y - dirCur.Y * dirTmp1.X < 0)//如果该点在左边，则计算 
                            {
                                //找角度最大的 
                                lenCur = Math.Sqrt(dirCur.X * dirCur.X + dirCur.Y * dirCur.Y);//当前向量长度 
                                lenTmp1 = Math.Sqrt(dirTmp1.X * dirTmp1.X + dirTmp1.Y * dirTmp1.Y);

                                dirTmp2.X = arrDots[j].X - arrDots[edge.End].X;
                                dirTmp2.Y = arrDots[j].Y - arrDots[edge.End].Y;
                                lenTmp2 = Math.Sqrt(dirTmp2.X * dirTmp2.X + dirTmp2.Y * dirTmp2.Y);
                                angRcdTmp = Math.Acos((dirCur.X * dirTmp1.X + dirCur.Y * dirTmp1.Y) / (lenTmp1 * lenCur));
                                angTemp = Math.Acos((dirTmp2.X * dirTmp1.X + dirTmp2.Y * dirTmp1.Y) / (lenTmp1 * lenTmp2));
                                if (angTemp > angMax)
                                {
                                    angMax = angTemp;
                                    angRcdMax = angRcdTmp;
                                    ptindex = j;
                                }
                                else if (angTemp == angMax && angRcdMax < angRcdTmp)//相等取最左 
                                {
                                    angRcdMax = angRcdTmp;
                                    ptindex = j;
                                }

                            }
                        }
                    }
                    if (ptindex != -1)//选择有点 
                    {
                        //记录三角形 
                        Tri tri = new Tri();
                        tri.NodeA = edge.Start;
                        tri.NodeB = edge.End;
                        tri.NodeC = ptindex;
                        edge.LeftTri = arrTris.Count;


                        isExist = false;
                        //记录边1-需要检索是否存在过这条边-由于每条边都先有左三角形，如有三角形加入，必定为右三角形 
                        for (int k = 0; k < arrEdges.Count; k++)
                        {
                            Edge2 e = (Edge2)arrEdges[k];
                            if (e.Start == edge.Start && e.End == ptindex)//如果存在过这条边，则记录其右三角形 
                            {
                                e.RightTri = arrTris.Count;
                                tri.AdjTriB = e.LeftTri;
                                isExist = true;
                                break;
                            }
                            else if (e.Start == ptindex && e.End == edge.Start)
                            {
                                e.LeftTri = arrTris.Count;
                                tri.AdjTriB = e.RightTri;
                                isExist = true;
                                break;
                            }
                        }
                        if (isExist == false)//如果不存在这条边，则新建一条边 
                        {
                            Edge2 edgeadd = new Edge2();
                            edgeadd.Start = ptindex;
                            edgeadd.End = edge.Start;
                            edgeadd.LeftTri = arrTris.Count;
                            arrEdges.Add(edgeadd);

                        }


                        isExist = false;
                        //记录边2 
                        for (int k = 0; k < arrEdges.Count; k++)
                        {
                            Edge2 e = (Edge2)arrEdges[k];
                            if (e.Start == ptindex && e.End == edge.End)//如果存在过这条边，则记录其右三角形 
                            {
                                e.RightTri = arrTris.Count;
                                tri.AdjTriA = e.LeftTri;
                                isExist = true;
                                break;
                            }
                            else if (e.Start == edge.End && e.End == ptindex)
                            {
                                e.LeftTri = arrTris.Count;
                                tri.AdjTriA = e.RightTri;
                                isExist = true;
                                break;
                            }
                        }
                        if (isExist == false)//如果不存在这条边，则新建一条边 
                        {
                            Edge2 edgeadd = new Edge2();
                            edgeadd.Start = edge.End;
                            edgeadd.End = ptindex;
                            edgeadd.LeftTri = arrTris.Count;
                            arrEdges.Add(edgeadd);

                        }
                        tri.AdjTriC = edge.RightTri;//如果edge的右三角形不存在，由if进来可见左三角也不存在，这只能是边界，从而tri.AdjTriC=-1合理 
                        arrTris.Add(tri);//add the tri to the arraylist 
                    }
                }
                else if (edge.RightTri == -1)//由于最开始的那部分都是边界，只有一个三角形；以后的边都已存在一个三角形，也仅剩余一个，故可以else if 
                {
                    //仅在右边找 
                    ptindex = -1;//选中的点的index 
                    dirCur.X = arrDots[edge.End].X - arrDots[edge.Start].X;
                    dirCur.Y = arrDots[edge.End].Y - arrDots[edge.Start].Y;
                    angMax = 0;//最大角度 
                    angRcdMax = 0;//与该边夹角最大值 
                    for (int j = 0; j < arrDots.Length; j++)
                    {
                        if (j != edge.Start && j != edge.End)//排除边的端点 
                        {
                            lenCur = Math.Sqrt(dirCur.X * dirCur.X + dirCur.Y * dirCur.Y);//当前向量长度 
                            dirTmp1.X = arrDots[j].X - arrDots[edge.Start].X;
                            dirTmp1.Y = arrDots[j].Y - arrDots[edge.Start].Y;
                            if (dirCur.X * dirTmp1.Y - dirCur.Y * dirTmp1.X > 0)//如果该点在右边，则计算 
                            {
                                //找角度最大的 
                                lenTmp1 = Math.Sqrt(dirTmp1.X * dirTmp1.X + dirTmp1.Y * dirTmp1.Y);

                                dirTmp2.X = arrDots[j].X - arrDots[edge.End].X;
                                dirTmp2.Y = arrDots[j].Y - arrDots[edge.End].Y;
                                lenTmp2 = Math.Sqrt(dirTmp2.X * dirTmp2.X + dirTmp2.Y * dirTmp2.Y);
                                angRcdTmp = Math.Acos((dirCur.X * dirTmp1.X + dirCur.Y * dirTmp1.Y) / (lenTmp1 * lenCur));
                                angTemp = Math.Acos((dirTmp2.X * dirTmp1.X + dirTmp2.Y * dirTmp1.Y) / (lenTmp1 * lenTmp2));
                                if (angTemp > angMax)
                                {
                                    angMax = angTemp;
                                    angRcdMax = angRcdTmp;
                                    ptindex = j;
                                }
                                else if (angTemp == angMax && angRcdTmp > angTemp)//相等取最左 
                                {
                                    angRcdTmp = angTemp;
                                    ptindex = j;
                                }

                            }
                        }
                    }
                    if (ptindex != -1)//选择有点 
                    {
                        //记录三角形 
                        //记录三角形 
                        Tri tri = new Tri();
                        tri.NodeA = edge.Start;
                        tri.NodeB = edge.End;
                        tri.NodeC = ptindex;
                        edge.RightTri = arrTris.Count;
                        isExist = false;
                        //记录边1-需要检索是否存在过这条边-由于每条边都先有左三角形，如有三角形加入，必定为右三角形 
                        for (int k = 0; k < arrEdges.Count; k++)
                        {
                            Edge2 e = (Edge2)arrEdges[k];
                            if (e.Start == ptindex && e.End == edge.Start)//如果存在过这条边，则记录其右三角形 
                            {
                                e.RightTri = arrTris.Count;
                                tri.AdjTriB = e.LeftTri;
                                isExist = true;
                                break;
                            }
                            else if (e.Start == edge.Start && e.End == ptindex)
                            {
                                e.LeftTri = arrTris.Count;
                                tri.AdjTriB = e.RightTri;
                                isExist = true;
                                break;

                            }
                        }
                        if (isExist == false)//如果不存在这条边，则新建一条边 
                        {
                            Edge2 edgeadd = new Edge2();
                            edgeadd.Start = edge.Start;
                            edgeadd.End = ptindex;
                            edgeadd.LeftTri = arrTris.Count;
                            arrEdges.Add(edgeadd);

                        }
                        isExist = false;
                        //记录边2 
                        for (int k = 0; k < arrEdges.Count; k++)
                        {
                            Edge2 e = (Edge2)arrEdges[k];
                            if (e.Start == edge.End && e.End == ptindex)//如果存在过这条边，则记录其右三角形 
                            {
                                e.RightTri = arrTris.Count;
                                tri.AdjTriA = e.LeftTri;
                                isExist = true;
                                break;
                            }
                            else if (e.Start == ptindex && e.End == edge.End)
                            {
                                e.LeftTri = arrTris.Count;
                                tri.AdjTriA = e.RightTri;
                                isExist = true;
                                break;
                            }
                        }
                        if (isExist == false)//如果不存在这条边，则新建一条边 
                        {
                            Edge2 edgeadd = new Edge2();
                            edgeadd.Start = ptindex;
                            edgeadd.End = edge.End;
                            edgeadd.LeftTri = arrTris.Count;
                            arrEdges.Add(edgeadd);
                        }
                        tri.AdjTriC = edge.LeftTri;//如果edge的左三角形不存在，由if进来可见右三角也不存在，这只能是边界，从而tri.AdjTriC=-1合理 
                        arrTris.Add(tri);//add the tri to the arraylist	 
                    }

                }

            }
            List<Edge> EdgeList = new List<Edge>();
            for (int gg = 0; gg < arrEdges.Count; gg++)
            {
                Edge2 eg = (Edge2)arrEdges[gg];
                PointF pt1, pt2;
                pt1 = arrDots[eg.Start];
                pt2 = arrDots[eg.End];
                EdgeList.Add(new Edge(
                    new DataPoint(gg, gg.ToString(), pt1.X, pt1.Y, 0),
                    new DataPoint(-gg, (-gg).ToString(), pt2.X, pt2.Y, 0)));
            }
            return EdgeList;
        }
    }
}
