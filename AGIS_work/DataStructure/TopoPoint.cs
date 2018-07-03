using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    public class TopoPoint
    {
        private static int _pointID = 0;
        public int PointID { get; private set; }
        public bool IsNode { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public List<TopoPolyline> TopologyArcs { get; private set; }

        public TopoPoint(DataPoint dpoint,bool isNode)
        {
            this.PointID = dpoint.OID;
            this.IsNode = isNode;
            this.X = dpoint.X;
            this.Y = dpoint.Y;
            this.Z = dpoint.Value;
            this.TopologyArcs = new List<TopoPolyline>();

        }

        public TopoPoint(double x,double y,double  z, bool isNode)
        {
            this.PointID = _pointID--;
            this.IsNode = isNode;
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.TopologyArcs = new List<TopoPolyline>();

        }
        /// <summary>
        /// 获取另一点对于当前点的方位角(角度)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double GetPosition(double x, double y)
        {
            double deltaX = x-this.X;
            double deltaY = y-this.Y;
            if (deltaX * deltaY == 0)
            {
                if (deltaX == 0)
                {
                    if (deltaY > 0)
                        return 90;
                    else if (deltaY < 0)
                        return 270;
                    else
                        throw new Exception("Topology.GetPosition:两点重合");
                }
                else
                {
                    if (deltaX > 0)
                        return 0;
                    else return 180;
                }
            }
            else
            {
                double alpha = Math.Atan(Math.Abs(deltaY / deltaX));
                if (deltaX > 0)
                {
                    if (deltaY > 0) return alpha;
                    else return 360 - alpha;
                }
                else
                {
                    if (deltaY > 0) return 180 - alpha;
                    else return 180 + alpha;
                }
            }

        }

        /// <summary>
        /// 获取另一点对于当前点的方位角(角度)
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public double GetPositon(TopoPoint p)
        {
            return this.GetPosition(p.X, p.Y);
        }

        public double GetDistance(TopoPoint other)
        {
            return Math.Sqrt(Math.Pow(this.X - other.X, 2) + Math.Pow(this.Y - other.Y, 2));
        }

        public override string ToString()
        {
            return string.Format("PointID:{0},IsNode:{1}", this.PointID, this.IsNode.ToString());
        }
    }
}
