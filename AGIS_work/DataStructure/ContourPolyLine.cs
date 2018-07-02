using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    public class ContourPolyline
    {
        public int PID { get; private set; }
        private static int _pid = 777777; 
        public List<DataPoint> PointList = new List<DataPoint>();
        public ContourPolyline() { this.PID = _pid++; }
        public ContourPolyline(DataPoint[] points)
        {
            this.PointList.AddRange(points);
            this.PID = _pid++;
        }

    }
}
