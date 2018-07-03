using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AGIS_work.DataStructure;

namespace AGIS_work.DataStructure_Test
{
    public class Edge_Test
    {
        [Fact]
        public void Intersect_Test()
        {
            //Console.WriteLine(Environment.CurrentDirectory.ToString());
            DataPoint p1 = new DataPoint(1, "1", 0, 0, 0);
            DataPoint p2 = new DataPoint(2, "2", 10, 10, 0);
            DataPoint p3 = new DataPoint(3, "3", 10, 0, 0);
            DataPoint p4 = new DataPoint(4, "4", 0, 10, 0);
            DataPoint p5 = new DataPoint(5, "5", 5, 5, 0);
            DataPoint p6 = new DataPoint(6, "6", 5, 10, 0);
            DataPoint p7 = new DataPoint(7, "7", 10, 5, 0);
            DataPoint p8 = new DataPoint(8, "8", 5, 0, 0);

            Edge e1 = new Edge(p1, p2);
            Edge e2 = new Edge(p3, p4);
            Edge e3 = new Edge(p5, p7);
            Edge e4 = new Edge(p8, p2);
            Edge e5 = new Edge(p1, p4);
            DataPoint ipt = Edge.IntersectPoint(e5, e4);
            Assert.True(ipt != null);
        }
    }
}
