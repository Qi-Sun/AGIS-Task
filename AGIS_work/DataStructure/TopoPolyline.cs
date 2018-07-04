using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    //拓扑边
    public class TopoPolyline
    {
        public int ArcID { get; private set; }//唯一标识码
        private static int _ArcID = 0;
        public int Innerid { get; private set; }//内部码
        public TopoPoint BeginNode { get; private set; }//起始节点
        public TopoPoint EndNode { get; private set; }//终止节点
        public List<TopoPoint> MiddlePoint { get; private set; }//中间点序列
        public TopoPolygon LeftPolygon { get; set; }//左多边形
        public TopoPolygon RightPolygon { get; set; }//右多边形
        public MinBoundRect MBR { get; private set; }

        public TopoPolyline()
        {
            this.ArcID = _ArcID++;
            MiddlePoint = new List<TopoPoint>();
            Innerid = this.ArcID;
            MBR = new MinBoundRect();
        }

        public TopoPolyline(ContourPolyline polyline)
        {
            this.ArcID = polyline.PID;
            Innerid = _ArcID++;
            MiddlePoint = new List<TopoPoint>();
            MBR = new MinBoundRect();
            if (polyline.PointList.Count >= 2)
            {
                TopoPoint startPoint = new TopoPoint(polyline.PointList.First(), true);
                startPoint.TopologyArcs.Add(this);
                this.BeginNode = startPoint;
                TopoPoint endPoint = new TopoPoint(polyline.PointList.Last(), true);
                endPoint.TopologyArcs.Add(this);
                this.EndNode = endPoint;
                MBR.UpdateRect(startPoint.X, startPoint.Y);
                MBR.UpdateRect(endPoint.X, endPoint.Y);
                for (int i = 1; i < polyline.PointList.Count - 1; i++)
                {
                    if (polyline.PointList[i].OID != startPoint.PointID &&
                       polyline.PointList[i].OID != EndNode.PointID)
                    {
                        TopoPoint midPoint = new TopoPoint(polyline.PointList[i], false);
                        MiddlePoint.Add(midPoint);
                        midPoint.TopologyArcs.Add(this);
                    }
                    MBR.UpdateRect(polyline.PointList[i].X, polyline.PointList[i].Y);
                }
            }
        }

        public TopoPolyline(Edge edge)
        {
            this.ArcID = edge.EID;
            MiddlePoint = new List<TopoPoint>();
            MBR = new MinBoundRect();
            TopoPoint startPoint = new TopoPoint(edge.StartPoint, true);
            startPoint.TopologyArcs.Add(this);
            this.BeginNode = startPoint;
            TopoPoint endPoint = new TopoPoint(edge.EndPoint, true);
            endPoint.TopologyArcs.Add(this);
            this.EndNode = endPoint;
            MBR.UpdateRect(startPoint.X, startPoint.Y);
            MBR.UpdateRect(endPoint.X, endPoint.Y);
        }
        //获取另一结点
        public TopoPoint GetAnotherNode(TopoPoint p)
        {
            if (this.BeginNode.PointID == p.PointID)
                return this.EndNode;
            else if (this.EndNode.PointID == p.PointID)
                return this.BeginNode;
            else return null;
        }
        //获取起始节点的角度
        public double GetBeginNodeAngle()
        {
            if (MiddlePoint.Count < 1) return this.BeginNode.GetPositon(this.EndNode);
            else return this.BeginNode.GetPositon(this.MiddlePoint[0]);
        }
        //获取终止节点的角度
        public double GetEndNodeAngle()
        {
            if (MiddlePoint.Count < 1) return this.EndNode.GetPositon(this.BeginNode);
            else return this.EndNode.GetPositon(this.MiddlePoint[0]);
        }
        //判断是否是结点
        public int IsNode(TopoPoint p)
        {
            if (this.BeginNode.PointID == p.PointID) return 1;
            else if (this.EndNode.PointID == p.PointID) return -1;
            else return 0;
        }

        public override string ToString()
        {
            return string.Format("ArcID:{0},StartID:{1},EndID:{2},MPointCount:{3}",
                   this.ArcID, this.BeginNode.PointID, this.EndNode.PointID, this.MiddlePoint.Count);
        }
    }
}
