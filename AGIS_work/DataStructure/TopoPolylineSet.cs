using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    public class TopoPolylineSet
    {
        public List<TopoPolyline> TopoPolylineList { get; private set; }

        public TopoPolylineSet()
        {
            this.TopoPolylineList = new List<TopoPolyline>();
        }
        public TopoPolylineSet(TopoPolyline[] lines)
        {
            this.TopoPolylineList = new List<TopoPolyline>();
            this.TopoPolylineList.AddRange(lines);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
