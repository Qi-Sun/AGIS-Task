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
        public TopoPolygon LeftPolygon { get; private set; }
        public TopoPolygon RightPolygon { get; private set; }

        public TopoPolyline()
        {
            this.ArcID = _ArcID ++;
        }

        public TopoPolyline(ContourPolyline polyline)
        {
            this.ArcID = polyline.PID;
            if (polyline.PointList.Count >= 2)
            {
                TopoPoint startPoint = new TopoPoint(polyline.PointList.First(), true);
                startPoint.TopologyArcs.Add(this);
                TopoPoint endPoint = new TopoPoint(polyline.PointList.Last(), true);
                endPoint.TopologyArcs.Add(this);
                for (int i = 1; i < polyline.PointList.Count - 1; i++)
                    MiddlePoint.Add(new TopoPoint(polyline.PointList[i], false));
            }
            
        }
    }
}
