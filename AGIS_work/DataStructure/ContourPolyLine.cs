using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    //等值线
    public class ContourPolyline
    {
        public int PID { get; private set; }   //唯一标识码
        private static int _pid = 777777;
        public List<DataPoint> PointList = new List<DataPoint>();//点序列
        public ContourPolyline() { this.PID = _pid++; }
        public ContourPolyline(DataPoint[] points)
        {
            this.PointList.AddRange(points);
            this.PID = _pid++;
        }
        //获取折线与边的交点
        public static Object[] IntersectResult(ContourPolyline pl1, Edge edge)
        {
            List<ContourPolyline> sublineFromPL1 = new List<ContourPolyline>();
            List<Edge> suEdgeFromEdge = new List<Edge>();
            //对边上点排序
            List<DataPoint> subEdgePoint = new List<DataPoint>();
            subEdgePoint.Add(edge.StartPoint);
            subEdgePoint.Add(edge.EndPoint);
            edge.StartPoint.RelativeLoc = 0;
            edge.EndPoint.RelativeLoc = 1;
            //对折线上点排序
            List<DataPoint> subLinePoint = new List<DataPoint>();
            subLinePoint.Add(pl1.PointList[0]);
            for (int i = 0; i < pl1.PointList.Count - 1; i++)
            {
                Edge pl1OneEdge = new Edge(pl1.PointList[i], pl1.PointList[i + 1]);
                DataPoint intersectP = Edge.IntersectPoint(pl1OneEdge, edge);
                double relativeLocOnLine = Edge.IntersectPointRelativeLoc(pl1OneEdge, edge);
                double relativeLocOnEdge = Edge.IntersectPointRelativeLoc(edge, pl1OneEdge);
                if (intersectP != null)
                {
                    if (relativeLocOnEdge < 1 && relativeLocOnEdge > 0)
                    { intersectP.RelativeLoc = relativeLocOnEdge; subEdgePoint.Add(intersectP); }
                    if (relativeLocOnLine <= 1 && relativeLocOnLine > 0)
                    {
                        subLinePoint.Add(intersectP);
                        sublineFromPL1.Add(new ContourPolyline(subLinePoint.ToArray()));
                        subLinePoint = new List<DataPoint>();
                        subLinePoint.Add(intersectP);
                    }
                }
                subLinePoint.Add(pl1.PointList[i + 1]);
            }
            sublineFromPL1.Add(new ContourPolyline(subLinePoint.ToArray()));
            subEdgePoint.Sort((x, y) => x.RelativeLoc.CompareTo(y.RelativeLoc));
            for (int i = 0; i < subEdgePoint.Count - 1; i++)
            { suEdgeFromEdge.Add(new Edge(subEdgePoint[i], subEdgePoint[i + 1])); }
            return new Object[2] { sublineFromPL1, suEdgeFromEdge };
        }
        //获取多条等值线与线段你的交点
        public static Object[] IntersectResult(ContourPolyline[] plineList, Edge edge)
        {
            List<ContourPolyline> sublineFromPLs = new List<ContourPolyline>();
            List<Edge> suEdgeFromEdge = new List<Edge>();
            //对边上点排序
            List<DataPoint> subEdgePoint = new List<DataPoint>();
            subEdgePoint.Add(edge.StartPoint);
            subEdgePoint.Add(edge.EndPoint);
            edge.StartPoint.RelativeLoc = 0;
            edge.EndPoint.RelativeLoc = 1;
            for (int k = 0; k < plineList.Length; k++)
            {
                //对折线上点排序
                List<DataPoint> subLinePoint = new List<DataPoint>();
                ContourPolyline curCpl = plineList[k];
                subLinePoint.Add(curCpl.PointList[0]);
                //选取一个等值线
                for (int i = 0; i < curCpl.PointList.Count - 1; i++)
                {
                    Edge pl1OneEdge = new Edge(curCpl.PointList[i], curCpl.PointList[i + 1]);
                    DataPoint intersectP = Edge.IntersectPoint(pl1OneEdge, edge);
                    double relativeLocOnLine = Edge.IntersectPointRelativeLoc(pl1OneEdge, edge);
                    double relativeLocOnEdge = Edge.IntersectPointRelativeLoc(edge, pl1OneEdge);
                    if (intersectP != null)
                    {
                        if (relativeLocOnEdge < 1 && relativeLocOnEdge > 0)
                        { intersectP.RelativeLoc = relativeLocOnEdge; subEdgePoint.Add(intersectP); }
                        if (relativeLocOnLine <= 1 && relativeLocOnLine > 0)
                        {
                            if (subLinePoint.Count == 1 && subLinePoint[0].OID == intersectP.OID) { }
                            else
                            {
                                subLinePoint.Add(intersectP);
                                sublineFromPLs.Add(new ContourPolyline(subLinePoint.ToArray()));
                                subLinePoint = new List<DataPoint>();
                                subLinePoint.Add(intersectP);
                            }
                        }
                    }
                    subLinePoint.Add(curCpl.PointList[i + 1]);
                }
                if (subLinePoint.Count >= 2 && !(subLinePoint.Count == 2 && subLinePoint[0].OID == subLinePoint[1].OID))
                    sublineFromPLs.Add(new ContourPolyline(subLinePoint.ToArray()));
            }
            subEdgePoint.Sort((x, y) => x.RelativeLoc.CompareTo(y.RelativeLoc));
            for (int i = 0; i < subEdgePoint.Count - 1; i++)
            {
                if (subEdgePoint[i].RelativeLoc != subEdgePoint[i + 1].RelativeLoc)
                    suEdgeFromEdge.Add(new Edge(subEdgePoint[i], subEdgePoint[i + 1]));
            }
            return new Object[2] { sublineFromPLs, suEdgeFromEdge };
        }

        public override string ToString()
        { return string.Format("CLid:{0},PtsCount:{1}", this.PID, this.PointList.Count); }
    }
}
