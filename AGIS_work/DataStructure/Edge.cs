using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    public class Edge
    {
        public int EID { get; private set; }
        public DataPoint StartPoint { get; private set; }
        public DataPoint EndPoint { get; private set; }
        public int StartOID
        { get { return StartPoint.OID; } }
        public int EndOID
        { get { return EndPoint.OID; } }
        public Triangle OwnerTriangle { get; set; }
        public object Tag { get; set; }
        private static int _eid = 10000;

        public Edge(DataPoint startP, DataPoint endP)
        {
            this.StartPoint = startP;
            this.EndPoint = endP;
            this.EID = _eid++;
        }
        public double MaxValue()
        {
            return Math.Max(StartPoint.Value, EndPoint.Value);
        }

        public double MinValue()
        {
            return Math.Min(StartPoint.Value, EndPoint.Value);
        }

        public double GetRelativeCoordinate(double value)
        {
            return (value - StartPoint.Value) / (EndPoint.Value - StartPoint.Value);
        }
        public double GetValue(double ralativeCoordinate)
        {
            return ralativeCoordinate * (EndPoint.Value - StartPoint.Value) + StartPoint.Value;
        }

        public bool IsEqulesEdge(int oid1, int oid2)
        {
            return ((StartPoint.OID == oid1) && (EndPoint.OID == oid2) ||
                (StartPoint.OID == oid2) && (EndPoint.OID == oid1));
        }

        public static DataPoint IntersectPoint(Edge e1, Edge e2)
        {
            double IntersectX =
                ((e1.EndPoint.X - e1.StartPoint.X) * (e2.StartPoint.X - e2.EndPoint.X) * (e2.StartPoint.Y - e1.StartPoint.Y) -
                e2.StartPoint.X * (e1.EndPoint.X - e1.StartPoint.X) * (e2.StartPoint.Y - e2.EndPoint.Y) +
                e1.StartPoint.X * (e1.EndPoint.Y - e1.StartPoint.Y) * (e2.StartPoint.X - e2.EndPoint.X)) /
                ((e1.EndPoint.Y - e1.StartPoint.Y) * (e2.StartPoint.X - e2.EndPoint.X) -
                (e1.EndPoint.X - e1.StartPoint.X) * (e2.StartPoint.Y - e2.EndPoint.Y));
            double IntersectY =
                ((e1.EndPoint.Y - e1.StartPoint.Y) * (e2.StartPoint.Y - e2.EndPoint.Y) * (e2.StartPoint.X - e1.StartPoint.X) -
                e2.StartPoint.Y * (e1.EndPoint.Y - e1.StartPoint.Y) * (e2.StartPoint.X - e2.EndPoint.X) +
                e1.StartPoint.Y * (e1.EndPoint.X - e1.StartPoint.X) * (e2.StartPoint.Y - e2.EndPoint.Y)) /
                ((e1.EndPoint.X - e1.StartPoint.X) * (e2.StartPoint.Y - e2.EndPoint.Y) -
                (e1.EndPoint.Y - e1.StartPoint.Y) * (e2.StartPoint.X - e2.EndPoint.X));
            double relativeE1 = 0;
            if ((e1.EndPoint.X - e1.StartPoint.X) != 0)
                relativeE1 = (IntersectX - e1.StartPoint.X) / (e1.EndPoint.X - e1.StartPoint.X);
            else relativeE1 = (IntersectY - e1.StartPoint.Y) / (e1.EndPoint.Y - e1.StartPoint.Y);
            double relativeE2 = 0;
            if ((e2.EndPoint.X - e2.StartPoint.X) != 0)
                relativeE2 = (IntersectX - e2.StartPoint.X) / (e2.EndPoint.X - e2.StartPoint.X);
            else relativeE2 = (IntersectY - e2.StartPoint.Y) / (e2.EndPoint.Y - e2.StartPoint.Y);
            int tempID = Math.Abs(e1.StartOID) + Math.Abs(e1.EndOID) + Math.Abs(e2.StartOID) + Math.Abs(e2.EndOID);
            if (relativeE1 < 1 && relativeE1 > 0 && relativeE2 > 0 && relativeE2 < 1)
                return new DataPoint(tempID, tempID.ToString(), IntersectX, IntersectY, -1);
            else if (Math.Abs(relativeE1) < 1E-5)
                return e1.StartPoint;
            else if (Math.Abs(relativeE1 - 1) < 1E-5)
                return e1.EndPoint;
            else if (Math.Abs(relativeE2) < 1E-5)
                return e2.StartPoint;
            else if (Math.Abs(relativeE2 - 1) < 1E-5)
                return e2.EndPoint;
            else return null;
        }

        /// <summary>
        /// 判断边2两点是否在边1两侧
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool CheckCross(Edge e1, Edge e2)
        {
            Vector2D v1 = e1.StartPoint - e1.EndPoint;
            Vector2D v2 = e2.StartPoint - e1.EndPoint;
            Vector2D v3 = e2.EndPoint - e2.EndPoint;
            return v1.CrossProduct(v2) * v1.CrossProduct(v3) < 0;
        }
    }
}
