using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    public class TopoPolygon
    {
        private static int _polygonID = 0;
        public int PID { get; private set; }
        public List<TopoPolyline> TopologyArcs { get;  set; }
        public TopoPolygon OuterPolygon { get;  set; }
        public List<TopoPolygon> InnerPolygons { get;  set; }

        public TopoPolygon()
        {
            this.PID = _polygonID++;
            OuterPolygon = null;
            TopologyArcs = new List<TopoPolyline>();
            InnerPolygons = new List<TopoPolygon>();
        }

    }
}
