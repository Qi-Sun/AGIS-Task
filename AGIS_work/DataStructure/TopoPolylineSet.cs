using System;
using System.Collections.Generic;
using System.IO;
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

        public void SavePolylineTableToFile(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}",
                "ID", "Arc_ID", "BeginNode", "EndNode", "LeftPolygon", "RightPolygon", "MiddlePtsNum",
                "MiddlePtsCooridinate", "LX", "LY", "RX", "RY"));
            foreach (var line in TopoPolylineList)
            {
                string middleCoorinate = " ";
                foreach (var mpoint in line.MiddlePoint)
                    middleCoorinate += string.Format("({0},{1},{2}),", mpoint.X, mpoint.Y, mpoint.Z);
                sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}",
                    line.Innerid, line.ArcID, line.BeginNode.PointID, line.EndNode.PointID,
                    (line.LeftPolygon == null) ? "NULL" : line.LeftPolygon.PID.ToString(),
                    (line.RightPolygon == null) ? "NULL" : line.RightPolygon.PID.ToString(),
                    line.MiddlePoint.Count, middleCoorinate.Remove(middleCoorinate.Length - 1),
                    line.MBR.MinX, line.MBR.MinY, line.MBR.MaxX, line.MBR.MaxY));
            }
            sw.Close();
        }
    }
}
