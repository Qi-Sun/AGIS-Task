using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    public class TopoPoint
    {
        private static int _pointID = 0;
        public int PointID { get; private set; }
        public bool IsNode { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public List<TopoPolyline> TopologyArcs { get; private set; }

        public TopoPoint(DataPoint dpoint,bool isNode)
        {
            this.PointID = dpoint.OID;
            this.IsNode = isNode;
            this.X = dpoint.X;
            this.Y = dpoint.Y;
            this.Z = dpoint.Value;
            this.TopologyArcs = new List<TopoPolyline>();

        }

        public TopoPoint(double x,double y,double  z, bool isNode)
        {
            this.PointID = _pointID--;
            this.IsNode = isNode;
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.TopologyArcs = new List<TopoPolyline>();

        }
    }
}
