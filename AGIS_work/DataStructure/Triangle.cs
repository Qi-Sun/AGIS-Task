using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    public class Triangle
    {
        public DataPoint VertexA { get; private set; }
        public DataPoint VertexB { get; private set; }
        public DataPoint VertexC { get; private set; }

        public Triangle(DataPoint v0,DataPoint v1,DataPoint v2)
        {
            this.VertexA = v0;
            this.VertexB = v1;
            this.VertexC = v2;
        }

        public bool IsPointInTriangle(DataPoint p)
        {
            Vector2D vectorPA = VertexA - p;
            Vector2D vectorPB = VertexB - p;
            Vector2D vectorPC = VertexC - p;
            double vPaPb = vectorPA.CrossProduct(vectorPB);
            double vPbPc = vectorPB.CrossProduct(vectorPC);
            double vPcPa = vectorPC.CrossProduct(vectorPA);
            return (vPaPb > 0 && vPbPc > 0 && vPcPa > 0) || (vPaPb < 0 && vPbPc < 0 && vPcPa < 0);
        }

    }
}
