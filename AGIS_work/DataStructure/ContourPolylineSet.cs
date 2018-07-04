using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    /// <summary>
    /// 等值线集合
    /// </summary>
    public class ContourPolylineSet
    {
        public List<ContourPolyline> ContourPolylineList = new List<ContourPolyline>();
        public ContourPolylineSet() { }
        public ContourPolylineSet(ContourPolyline[] polylines) { ContourPolylineList.AddRange(polylines); }
    }
}
