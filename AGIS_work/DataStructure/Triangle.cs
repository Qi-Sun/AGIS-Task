using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    public class Triangle
    {
        public int TID { get; private set; }
        public DataPoint VertexA { get; private set; }
        public DataPoint VertexB { get; private set; }
        public DataPoint VertexC { get; private set; }

        public Triangle(DataPoint v0,DataPoint v1,DataPoint v2,int tid)
        {
            this.VertexA = v0;
            this.VertexB = v1;
            this.VertexC = v2;
            this.TID = tid;
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

        public bool IsEqulesTri(int oid1,int oid2,int oid3)
        {
            List<int> TriOIDList = new List<int>();
            TriOIDList.Add(VertexA.OID);
            TriOIDList.Add(VertexB.OID);
            TriOIDList.Add(VertexC.OID);
            TriOIDList.Sort();
            List<int> VirOIDList = new List<int>();
            VirOIDList.Add(oid1);
            VirOIDList.Add(oid2);
            VirOIDList.Add(oid3);
            VirOIDList.Sort();
            return (TriOIDList[0] == VirOIDList[0]) && 
                (TriOIDList[1] == VirOIDList[1]) && 
                (TriOIDList[2] == VirOIDList[2]);
        }

        public Edge GetContourLine(double elevation)
        {
            List<DataPoint> points = new List<DataPoint>();
            if ((elevation - VertexA.Value) * (elevation - VertexB.Value) * (elevation - VertexC.Value) == 0)
                elevation += 0.1;
            if ((elevation - VertexA.Value)*(elevation - VertexB.Value) < 0)          
            {
                double EleX = VertexA.X + (VertexB.X - VertexA.X) * (elevation - VertexA.Value) / (VertexB.Value - VertexA.Value);
                double EleY = VertexA.Y + (VertexB.Y - VertexA.Y) * (elevation - VertexA.Value) / (VertexB.Value - VertexA.Value);
                DataPoint p1 = new DataPoint(VertexA.OID * 1000 + VertexB.OID,
                    "ContourPoint_" + VertexA.OID * 1000 + VertexB.OID,
                    EleX, EleY, elevation);
                points.Add(p1);
            }
            if ((elevation - VertexA.Value) * (elevation - VertexC.Value) < 0)
            {
                double EleX = VertexA.X + (VertexC.X - VertexA.X) * (elevation - VertexA.Value) / (VertexC.Value - VertexA.Value);
                double EleY = VertexA.Y + (VertexC.Y - VertexA.Y) * (elevation - VertexA.Value) / (VertexC.Value - VertexA.Value);
                DataPoint p1 = new DataPoint(VertexA.OID * 1000 + VertexC.OID,
                    "ContourPoint_" + VertexA.OID * 1000 + VertexC.OID,
                    EleX, EleY, elevation);
                points.Add(p1);
            }
            if ((elevation - VertexC.Value) * (elevation - VertexB.Value) < 0)
            {
                double EleX = VertexC.X + (VertexB.X - VertexC.X) * (elevation - VertexC.Value) / (VertexB.Value - VertexC.Value);
                double EleY = VertexC.Y + (VertexB.Y - VertexC.Y) * (elevation - VertexC.Value) / (VertexB.Value - VertexC.Value);
                DataPoint p1 = new DataPoint(VertexC.OID * 1000 + VertexB.OID,
                    "ContourPoint_" + VertexC.OID * 1000 + VertexB.OID,
                    EleX, EleY, elevation);
                points.Add(p1);
            }
            if (points.Count == 2)
            {
                return new Edge(points[0], points[1]);
            }
            else return null;
        }
    }
}
