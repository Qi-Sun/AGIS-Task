using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    public class EdgeSet
    {
        public List<Edge> EdgeList = new List<Edge>();
        public EdgeSet() { }
        public EdgeSet(Edge[] edges) { EdgeList.AddRange(edges); }

        /// <summary>
        /// 移除指定EID的边
        /// </summary>
        /// <param name="eid"></param>
        public void RemoveEdgeByEID(int eid)
        {
            int index = 0;
            foreach (var edge in EdgeList)
            {
                if (edge.EID == eid)
                    break;
                index++;
            }
            EdgeList.RemoveAt(index);
        }

        public void AddEdge(Edge  e)
        {
            EdgeList.Add(e);
        }

        public Edge GetEdgeByOID(int oid1,int oid2)
        {
            foreach (var edge in EdgeList)
            {
                if (edge.IsEqulesEdge(oid1, oid2))
                    return edge;
            }
            return null;
        }

        public static TriangleSet TopologyGenerateTriangleSet(Edge[] Edges,PointSet PointSet)
        {
            TriangleSet triangleSet = new TriangleSet();
            List<int> pointOID = new List<int>();
            EdgeSet edgeSet = new EdgeSet(Edges);
            for (int i = 0; i < Edges.Length; i++)
            {
                if (pointOID.Contains(Edges[i].StartOID) != true)
                    pointOID.Add(Edges[i].StartOID);
                if (pointOID.Contains(Edges[i].EndOID) != true)
                    pointOID.Add(Edges[i].EndOID);
            }
            for (int i = 0; i < Edges.Length; i++)
            {
                int soid = Edges[i].StartOID;
                int eoid = Edges[i].EndOID;
                for (int j = 0; j < pointOID.Count; j++)
                {
                    Edge edge1 = edgeSet.GetEdgeByOID(soid, pointOID[j]);
                    Edge edge2 = edgeSet.GetEdgeByOID(eoid, pointOID[j]);
                    if (edge1 != null && edge2 != null)
                    {
                        Triangle tri = new Triangle(PointSet.GetPointByOID(soid),
                            PointSet.GetPointByOID(eoid),
                            PointSet.GetPointByOID(pointOID[j]),i);
                        if (triangleSet.IsTriAlreadyExists(soid,eoid, pointOID[j]) == false)
                            triangleSet.AddTriangle(tri);
                    }
                }
                
            }
            return triangleSet;
        }
    }
}
