using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    //拓扑多边形集合
    public class TopoPolygonSet
    {
        public List<TopoPolygon> TopoPolygonList { get; private set; }

        public TopoPolygonSet()
        { this.TopoPolygonList = new List<TopoPolygon>(); }
        public TopoPolygonSet(TopoPolygon[] gons)
        {
            this.TopoPolygonList = new List<TopoPolygon>();
            for (int i = 0; i < gons.Length; i++)
            {
                if (this.IsPolygonExist(gons[i].PID) == false)
                    TopoPolygonList.Add(gons[i]);
            }
        }
        //二次筛查
        public void Recheck(double regionArea)
        {
            double area_max = 0;
            int pid_max_index = -1;
            for (int i = 0; i < TopoPolygonList.Count; i++)
            {
                double area = TopoPolygonList[i].GetArea();
                if (area > area_max)
                { area_max = area; pid_max_index = i; }
            }
            if (pid_max_index != -1 && area_max > 0.5 * regionArea)
                TopoPolygonList.RemoveAt(pid_max_index);
        }
        //判断是否存在对应id的多边形
        public bool IsPolygonExist(int pid)
        {
            foreach (var polygon in TopoPolygonList)
            { if (polygon.PID == pid) return true; }
            return false;
        }
        //获取选中的多边形
        public TopoPolygon GetClickPointInsidePolygon(TopoPoint clickPoint)
        {
            foreach (var polygon in this.TopoPolygonList)
            { if (polygon.IfPointInRegion(clickPoint)) return polygon; }
            return null;
        }
        //导出多边形拓扑关系表至文件
        public void SavePolygonTableToFile(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}",
                    "ID", "Pol_ID", "Arc_Num", "ArcIds", "OuterPol_ID", "InnerPol_ID", "LX", "LY", "RX", "RY"));
            foreach (var polygon in TopoPolygonList)
            {
                string arcids = " ";
                foreach (var arc in polygon.TopologyArcs)
                { arcids += arc.ArcID + ","; }
                sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}",
                    polygon.innerId, polygon.PID, polygon.TopologyArcs.Count, arcids.Remove(arcids.Length - 1),
                    (polygon.OuterPolygon == null) ? "NULL" : polygon.OuterPolygon.PID.ToString(),
                    (polygon.InnerPolygons.Count == 0) ? "NULL" : polygon.InnerPolygons[0].PID.ToString(),
                    polygon.MBR.MinX, polygon.MBR.MinY, polygon.MBR.MaxX, polygon.MBR.MaxY));
            }
            sw.Close();
        }
    }
}
