using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    public class TopoPolyline
    {
        public int ArcID { get; private set; }
        private int _ArcID = 0;
        public TopoPoint BeginNode { get; private set; }
        public TopoPoint EndNode { get; private set; }
        public List<TopoPoint> MiddlePoint { get; private set; }
        public TopoPolygon LeftPolygon { get; set; }
        public TopoPolygon RightPolygon { get; set; }

        public TopoPolyline()
        {
            this.ArcID = _ArcID ++;
            MiddlePoint = new List<TopoPoint>();
        }

        public TopoPolyline(ContourPolyline polyline)
        {
            this.ArcID = polyline.PID;
            MiddlePoint = new List<TopoPoint>();
            if (polyline.PointList.Count >= 2)
            {
                TopoPoint startPoint = new TopoPoint(polyline.PointList.First(), true);
                startPoint.TopologyArcs.Add(this);
                this.BeginNode = startPoint;
                TopoPoint endPoint = new TopoPoint(polyline.PointList.Last(), true);
                endPoint.TopologyArcs.Add(this);
                this.EndNode = endPoint;
                for (int i = 1; i < polyline.PointList.Count - 1; i++)
                {
                    if (polyline.PointList[i].OID != startPoint.PointID &&
                       polyline.PointList[i].OID != EndNode.PointID)
                        MiddlePoint.Add(new TopoPoint(polyline.PointList[i], false));
                }
            }
            
        }

        public TopoPolyline(Edge edge)
        {
            this.ArcID = edge.EID;
            MiddlePoint = new List<TopoPoint>();
            TopoPoint startPoint = new TopoPoint(edge.StartPoint, true);
            startPoint.TopologyArcs.Add(this);
            this.BeginNode = startPoint;
            TopoPoint endPoint = new TopoPoint(edge.EndPoint, true);
            endPoint.TopologyArcs.Add(this);
            this.EndNode = endPoint;
        }

        public TopoPoint GetAnotherNode(TopoPoint p)
        {
            if (this.BeginNode.PointID == p.PointID)
                return this.EndNode;
            else if (this.EndNode.PointID == p.PointID)
                return this.BeginNode;
            else return null;
        }

        public double GetBeginNodeAngle()
        {
            if (MiddlePoint.Count < 1)
                return this.BeginNode.GetPositon(this.EndNode);
            else return this.BeginNode.GetPositon(this.MiddlePoint[0]);
        }

        public double GetEndNodeAngle()
        {
            if (MiddlePoint.Count < 1)
                return this.EndNode.GetPositon(this.BeginNode);
            else return this.EndNode.GetPositon(this.MiddlePoint[0]);
        }

        public int IsNode(TopoPoint p)
        {
            if (this.BeginNode.PointID == p.PointID)
                return 1;
            else if (this.EndNode.PointID == p.PointID)
                return -1;
            else return 0;
        }

        public override string ToString()
        {
            return string.Format("ArcID:{0},StartID:{1},EndID:{2},MPointCount:{3}",
                this.ArcID, this.BeginNode.PointID, this.EndNode.PointID, this.MiddlePoint.Count);
        }
    }
}
