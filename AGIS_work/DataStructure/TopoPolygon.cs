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
        public List<TopoPolyline> TopologyArcs { get; set; }
        public TopoPolygon OuterPolygon { get; set; }
        public List<TopoPolygon> InnerPolygons { get; set; }

        public TopoPolygon()
        {
            this.PID = _polygonID++;
            OuterPolygon = null;
            TopologyArcs = new List<TopoPolyline>();
            InnerPolygons = new List<TopoPolygon>();
        }

        public TopoPolygon(TopoPolyline[] lines)
        {
            OuterPolygon = null;
            TopologyArcs = new List<TopoPolyline>();
            InnerPolygons = new List<TopoPolygon>();
            this.TopologyArcs.AddRange(lines);
            List<int> ArcIDList = new List<int>();
            foreach (var arc in lines)
            {
                ArcIDList.Add(arc.ArcID);
            }
            ArcIDList.Sort();
            int hasgCode = 1;
            foreach (var arcid in ArcIDList)
            {
                hasgCode *= arcid;
            }
            this.PID = hasgCode.GetHashCode();

        }

        public TopoPoint[] ConvertToPointArray()
        {
            List<TopoPoint> pointArray = new List<TopoPoint>();
            TopoPoint b1 = TopologyArcs[0].BeginNode;
            TopoPoint e1 = TopologyArcs[0].EndNode;
            TopoPoint b2 = TopologyArcs.Last().BeginNode;
            TopoPoint e2 = TopologyArcs.Last().EndNode;

            TopoPoint beginPoint;
            if (b1.PointID == b2.PointID)
                beginPoint = b1;
            else if (b1.PointID == e2.PointID)
                beginPoint = b1;
            else beginPoint = e1;
            pointArray.Add(beginPoint);
            for (int i = 0; i < TopologyArcs.Count; i++)
            {
                int direct = TopologyArcs[i].IsNode(beginPoint);
                if (direct > 0)
                    pointArray.AddRange(TopologyArcs[i].MiddlePoint.ToArray());
                else
                {
                    List<TopoPoint> middlePoint = TopologyArcs[i].MiddlePoint;
                    for (int k = 0; k < middlePoint.Count; k++)
                        pointArray.Add(middlePoint[middlePoint.Count - 1 - k]);
                }
                beginPoint = TopologyArcs[i].GetAnotherNode(beginPoint);
                pointArray.Add(beginPoint);
            }
            return pointArray.ToArray();
        }

        public double GetArea()
        {
            TopoPoint[] points = this.ConvertToPointArray();
            var area = Math.Abs(points.Take(points.Length - 1)
               .Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y))
               .Sum() / 2);
            return area;
        }

        public double GetPerimeter()
        {
            TopoPoint[] points = this.ConvertToPointArray();
            double perimeter = 0;
            for (int i = 0; i < points.Length - 1; i++)
            {
                perimeter += points[i].GetDistance(points[i + 1]);
            }
            return perimeter;
        }

        public bool IfPointInRegion(TopoPoint todeterPoint)
        {
            TopoPoint[] points = this.ConvertToPointArray();
            TopoPoint rayPoint = new TopoPoint(todeterPoint.X * 2, todeterPoint.Y, todeterPoint.Z, false);
            int intersectCount = 0;
            for (int i = 0; i < points.Length - 1; i++)
            {
                if (TopoPolygon.IntersectPoint(points[i], points[i + 1], todeterPoint, rayPoint) == true)
                    intersectCount++;
            }
            return (intersectCount / 2 != 0);
        }

        public static bool IntersectPoint(TopoPoint p1, TopoPoint p2, TopoPoint todeterPoint, TopoPoint rays)
        {
            double IntersectX =
                ((p2.X - p1.X) * (todeterPoint.X - rays.X) * (todeterPoint.Y - p1.Y) -
                todeterPoint.X * (p2.X - p1.X) * (todeterPoint.Y - rays.Y) +
                p1.X * (p2.Y - p1.Y) * (todeterPoint.X - rays.X)) /
                ((p2.Y - p1.Y) * (todeterPoint.X - rays.X) -
                (p2.X - p1.X) * (todeterPoint.Y - rays.Y));
            double IntersectY =
                ((p2.Y - p1.Y) * (todeterPoint.Y - rays.Y) * (todeterPoint.X - p1.X) -
                todeterPoint.Y * (p2.Y - p1.Y) * (todeterPoint.X - rays.X) +
                p1.Y * (p2.X - p1.X) * (todeterPoint.Y - rays.Y)) /
                ((p2.X - p1.X) * (todeterPoint.Y - rays.Y) -
                (p2.Y - p1.Y) * (todeterPoint.X - rays.X));
            double relativeE1 = 0;
            if ((p2.X - p1.X) != 0)
                relativeE1 = (IntersectX - p1.X) / (p2.X - p1.X);
            else relativeE1 = (IntersectY - p1.Y) / (p2.Y - p1.Y);
            if (0 <= relativeE1 && relativeE1 < 1)
                return true;
            else return false;
        }



    }
}
