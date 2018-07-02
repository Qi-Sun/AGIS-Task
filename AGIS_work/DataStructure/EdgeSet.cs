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

        public void AddEdge(Edge e)
        {
            EdgeList.Add(e);
        }

        public Edge GetEdgeByOID(int oid1, int oid2)
        {
            foreach (var edge in EdgeList)
            {
                if (edge.IsEqulesEdge(oid1, oid2))
                    return edge;
            }
            return null;
        }

        public Edge GetEdgeByOID(int oid)
        {
            foreach (var edge in EdgeList)
            {
                if (edge.StartOID == oid || edge.EndOID == oid)
                    return edge;
            }
            return null;
        }


        public static TriangleSet TopologyGenerateTriangleSet(Edge[] Edges, PointSet PointSet)
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
                            PointSet.GetPointByOID(pointOID[j]), i);
                        if (triangleSet.IsTriAlreadyExists(soid, eoid, pointOID[j]) == false)
                            triangleSet.AddTriangle(tri);
                    }
                }

            }
            return triangleSet;
        }

        public static ContourPolylineSet TopologyGenerateContourPolylineSet(Edge[] Edges)
        {
            List<ContourPolyline> ContourPolylineList = new List<ContourPolyline>();
            PointSet ContourPointSet = new PointSet();
            EdgeSet ContourEdgeSet = new EdgeSet(Edges);
            EdgeSet ContourEdgeSetCopy = new EdgeSet(Edges);
            for (int i = 0; i < Edges.Length; i++)
            {
                ContourPointSet.AddPoint(Edges[i].StartPoint);
                ContourPointSet.AddPoint(Edges[i].EndPoint);
            }
            List<int> PointOID = ContourPointSet.GetPointOIDList();
            while (PointOID.Count > 0)
            {
                //选取一个等值线上的点
                List<int> tempPointsOID = new List<int>();
                tempPointsOID.Add(PointOID[0]);
                PointOID.Remove(PointOID[0]);
                for (int i = 0; i < tempPointsOID.Count; i++)
                {
                    Edge tempEdge = ContourEdgeSetCopy.GetEdgeByOID(tempPointsOID[i]);
                    if (tempEdge != null)
                    {
                        int tempoid = (tempEdge.StartOID == tempPointsOID[i]) ? tempEdge.EndOID : tempEdge.StartOID;
                        tempPointsOID.Add(tempoid);
                        ContourEdgeSetCopy.EdgeList.Remove(tempEdge);
                        PointOID.Remove(tempoid);
                        i = -1;
                    }
                }
                //找到了这条线上的全部点
                List<DataPoint> tempPointList = new List<DataPoint>();
                tempPointList.Add(ContourPointSet.GetPointByOID(tempPointsOID[0]));
                Edge firstEdge = ContourEdgeSet.GetEdgeByOID(tempPointsOID[0]);
                int secondOID = (firstEdge.StartOID == tempPointsOID[0]) ? firstEdge.EndOID : firstEdge.StartOID;
                tempPointList.Add(ContourPointSet.GetPointByOID(secondOID));
                ContourEdgeSet.EdgeList.Remove(firstEdge);
                while (true)
                {
                    int endPointOID = tempPointList.Last().OID;
                    Edge endEdge = ContourEdgeSet.GetEdgeByOID(endPointOID);
                    if (endEdge != null)
                    {
                        int endOID = (endEdge.StartOID == endPointOID) ? endEdge.EndOID : endEdge.StartOID;
                        tempPointList.Add(ContourPointSet.GetPointByOID(endOID));
                        ContourEdgeSet.EdgeList.Remove(endEdge);
                    }
                    else break;
                }
                while (true)
                {
                    int startPointOID = tempPointList.First().OID;
                    Edge startEdge = ContourEdgeSet.GetEdgeByOID(startPointOID);
                    if (startEdge != null)
                    {
                        int startOID = (startEdge.StartOID == startPointOID) ? startEdge.EndOID : startEdge.StartOID;
                        tempPointList.Insert(0,ContourPointSet.GetPointByOID(startOID));
                        ContourEdgeSet.EdgeList.Remove(startEdge);
                    }
                    else break;
                }
                ContourPolyline tempPolyline = new ContourPolyline(tempPointList.ToArray());
                ContourPolylineList.Add(tempPolyline);
            }
            return new ContourPolylineSet(ContourPolylineList.ToArray());
        }
    }
}
