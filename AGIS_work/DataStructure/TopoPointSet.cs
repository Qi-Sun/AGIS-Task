using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    public class TopoPointSet
    {
        /// <summary>
        /// 中间点表
        /// </summary>
        public List<TopoPoint> TopoPointList { get; private set; }
        /// <summary>
        /// 结点表
        /// </summary>
        public List<TopoPoint> TopoNodeList { get; private set; }

        public TopoPointSet()
        {
            TopoPointList = new List<TopoPoint>();
            TopoNodeList = new List<TopoPoint>();
        }

        public TopoPointSet(TopoPoint[] topoPoints)
        {
            TopoPointList = new List<TopoPoint>();
            TopoNodeList = new List<TopoPoint>();
            for (int i = 0; i < topoPoints.Length; i++)
            {
                if (topoPoints[i].IsNode == false)
                    TopoPointList.Add(topoPoints[i]);
                else
                    TopoNodeList.Add(topoPoints[i]);
            }
        }

        /// <summary>
        /// 判断中间点是否已经存在
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public bool IfPointExists(int oid)
        {
            foreach (var point in TopoPointList)
            {
                if (point.PointID == oid)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 判断节点是否已经存在
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public bool IfNodeExists(int oid)
        {
            foreach (var point in TopoNodeList)
            {
                if (point.PointID == oid)
                    return true;
            }
            return false;
        }

        public TopoPoint GetNodeByPointID(int poid)
        {
            foreach (var point in TopoNodeList)
            {
                if (point.PointID == poid)
                    return point;
            }
            return null;
        }

        public TopoPointSet(TopoPolyline[] topoLines)
        {
            TopoPointList = new List<TopoPoint>();
            TopoNodeList = new List<TopoPoint>();
            for (int i = 0; i < topoLines.Length; i++)
            {
                for (int j = 0; j < topoLines[i].MiddlePoint.Count; j++)
                {
                    if (this.IfPointExists(topoLines[i].MiddlePoint[j].PointID) == false)
                        TopoPointList.Add(topoLines[i].MiddlePoint[j]);
                }
                if (this.IfNodeExists(topoLines[i].BeginNode.PointID) == false)
                    TopoNodeList.Add(topoLines[i].BeginNode);
                else
                {
                    TopoPoint existPoint = this.GetNodeByPointID(topoLines[i].BeginNode.PointID);
                    if (existPoint.TopologyArcs.Contains(topoLines[i]) == false)
                        existPoint.TopologyArcs.Add(topoLines[i]);
                }
                if (this.IfNodeExists(topoLines[i].EndNode.PointID) == false)
                    TopoNodeList.Add(topoLines[i].EndNode);
                else
                {
                    TopoPoint existPoint = this.GetNodeByPointID(topoLines[i].EndNode.PointID);
                    if (existPoint.TopologyArcs.Contains(topoLines[i]) == false)
                        existPoint.TopologyArcs.Add(topoLines[i]);
                }
            }
        }

        /// <summary>
        /// 根据点的拓扑关系，生成多边形的拓扑关系
        /// </summary>
        /// <returns></returns>
        public TopoPolygonSet GenerateTopoPolygonSet()
        {
            List<TopoPolygon> polygonList = new List<TopoPolygon>();
            foreach (var tpPoint in this.TopoNodeList)
            {
                List<Tuple<TopoPoint, double, double, int, TopoPolyline>> curPointStructList = 
                    new List<Tuple<TopoPoint, double, double, int, TopoPolyline>>();
                List<TopoPolyline> relaArcs = tpPoint.TopologyArcs;
                foreach (var arc in relaArcs)
                {
                    int direct = arc.IsNode(tpPoint);
                    double angle = -1;
                    double otherNodeAngle = -2;
                    switch (direct)
                    {
                        case 1:
                            angle = arc.GetBeginNodeAngle();
                            otherNodeAngle = arc.GetEndNodeAngle();
                            break;
                        case -1:
                            angle = arc.GetEndNodeAngle();
                            otherNodeAngle = arc.GetBeginNodeAngle();
                            break;
                        default:
                            break;
                    }
                    Tuple<TopoPoint, double, double, int, TopoPolyline> curPointStruct
                        = new Tuple<TopoPoint, double, double, int, TopoPolyline>(arc.GetAnotherNode(tpPoint), angle, otherNodeAngle, direct, arc);
                    curPointStructList.Add(curPointStruct);
                }
                List<TopoPolyline> curPolygon = new List<TopoPolyline>();
                List<int> directList = new List<int>();
                foreach (var pointStruct in curPointStructList)
                {
                    var iterationTuple = pointStruct;
                    while (iterationTuple.Item1.PointID != tpPoint.PointID)
                    {
                        curPolygon.Add(iterationTuple.Item5);
                        directList.Add(iterationTuple.Item4);
                        iterationTuple = this.GetNextNode(iterationTuple);
                    }
                    curPolygon.Add(iterationTuple.Item5);
                    directList.Add(iterationTuple.Item4);
                    //追踪成功
                    if (curPolygon.Count > 0)
                    {
                        TopoPolygon tempPolygon = new TopoPolygon(curPolygon.ToArray());
                        for (int i = 0; i < directList.Count; i++)
                        {
                            if (directList[i] > 0)
                                curPolygon[i].RightPolygon = tempPolygon;
                            else if (directList[i] < 0)
                                curPolygon[i].LeftPolygon = tempPolygon;
                        }
                        polygonList.Add(tempPolygon);
                        curPolygon = new List<TopoPolyline>();
                        directList = new List<int>();
                    }
                }
                           
            }
            return new TopoPolygonSet(polygonList.ToArray());
        }

        public void SortTheSearchLine(List<Tuple<TopoPoint, double, double, int, TopoPolyline>> lineToSort, double startAngle)
        {
            lineToSort.Sort((x, y) =>
            {
                double x2 = x.Item2 - startAngle;
                double y2 = y.Item2 - startAngle;
                if (x2 <= 0) x2 += 360;
                if (y2 <= 0) y2 += 360;
                return x2.CompareTo(y2);
            });
            return;
        }

        public TopoPoint GetTopoPointByID(int poid)
        {
            foreach (var point in this.TopoPointList)
            {
                if (point.PointID == poid)
                    return point;
            }
            return null;
        }

        /// <summary>
        /// 循环搜索下一个节点
        /// </summary>
        /// <param name="curNode">TopoPoint当前搜索点，double前一步的排序条件，double当前的步的排序条件，int方向，Polyline当前弧段</param>
        /// <returns></returns>
        public Tuple<TopoPoint, double, double, int,TopoPolyline> GetNextNode(Tuple<TopoPoint, double, double, int, TopoPolyline> curNode)
        {
            List<TopoPolyline> curArcs = this.GetNodeByPointID(curNode.Item1.PointID).TopologyArcs;
            List<Tuple<TopoPoint, double, double, int, TopoPolyline>> tempList = new List<Tuple<TopoPoint, double, double, int, TopoPolyline>>();
            foreach (var arc in curArcs)
            {
                int direct = arc.IsNode(curNode.Item1);
                double angle = -1;
                double otherNodeAngle = -2;
                switch (direct)
                {
                    case 1:
                        angle = arc.GetBeginNodeAngle();
                        otherNodeAngle = arc.GetEndNodeAngle();
                        break;
                    case -1:
                        angle = arc.GetEndNodeAngle();
                        otherNodeAngle = arc.GetBeginNodeAngle();
                        break;
                    default:
                        break;
                }
                tempList.Add(new Tuple<TopoPoint, double, double, int, TopoPolyline>(
                    arc.GetAnotherNode(curNode.Item1), angle, otherNodeAngle, direct, arc));
            }
            SortTheSearchLine(tempList, curNode.Item3);
            return tempList[0];
        }
    }
}
