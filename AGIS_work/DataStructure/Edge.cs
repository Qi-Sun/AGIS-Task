using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    public class Edge
    {
        public DataPoint StartPoint { get; private set; }
        public DataPoint EndPoint { get; private set; }

        public Edge(DataPoint startP,DataPoint endP)
        {
            this.StartPoint = startP;
            this.EndPoint = endP;
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
    }
}
