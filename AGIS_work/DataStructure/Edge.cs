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

        public Edge(DataPoint startP,DataPoint endP,int eid)
        {
            this.StartPoint = startP;
            this.EndPoint = endP;
            this.EID = eid;
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

        public bool IsEqulesEdge(int oid1,int oid2)
        {
            return ((StartPoint.OID == oid1) && (EndPoint.OID == oid2)||
                (StartPoint.OID == oid2) && (EndPoint.OID == oid1));
        }
        
    }
}
