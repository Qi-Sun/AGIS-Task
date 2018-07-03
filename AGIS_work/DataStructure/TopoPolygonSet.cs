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
        public void Recheck(double regionArea)
        {
            double area_max = 0;
            int pid_max_index = -1;
            for (int i = 0; i < TopoPolygonList.Count; i++)
            {
                double area = TopoPolygonList[i].GetArea();
                if (area > area_max)
                {
                    area_max = area;
                    pid_max_index = i;
                }
            }
            if (pid_max_index != -1 && area_max > 0.5 * regionArea)
                TopoPolygonList.RemoveAt(pid_max_index);
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


        public TopoPolygon GetClickPointInsidePolygon(TopoPoint clickPoint)
        {
            foreach (var polygon in this.TopoPolygonList)
            {
                if (polygon.IfPointInRegion(clickPoint))
                    return polygon;
            }
            return null; 
        }
        
    }
}
