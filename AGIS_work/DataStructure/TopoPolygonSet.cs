using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    public class TopoPolygonSet
    {
        public List<TopoPolygon> TopoPolygonList { get; private set; }

        public TopoPolygonSet()
        {
            this.TopoPolygonList = new List<TopoPolygon>();
        }
        public TopoPolygonSet(TopoPolygon[] gons)
        {
            this.TopoPolygonList = new List<TopoPolygon>();
            for (int i = 0; i < gons.Length; i++)
            {
                if (this.IsPolygonExist(gons[i].PID) == false)
                    TopoPolygonList.Add(gons[i]);
            }
        }
        

        public bool IsPolygonExist(int pid)
        {
            foreach (var polygon in TopoPolygonList)
            {
                if (polygon.PID == pid)
                    return true;
            }
            return false;
        }

        
    }
}
