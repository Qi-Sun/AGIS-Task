using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    public class DataPoint
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Value { get; private set; }
        public MinBoundRect MBR { get; private set; }
        public int OID { get; private set; }
        private static int _oid = 1000000;
        public double RelativeLoc { get; set; }
        
        public DataPoint(int id, string name, double x, double y, double value,int oid)
        {
            this.ID = id;
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.Value = value;
            this.MBR = new MinBoundRect(x, y, x, y);
            this.OID = oid;
        }

        public DataPoint(int id, string name, double x, double y, double value)
        {
            this.ID = id;
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.Value = value;
            this.MBR = new MinBoundRect(x, y, x, y);
            this.OID = _oid++;
        }

        public override string ToString()
        {
            return string.Format("ID:{0} Name:{1}\r\n Point({2},{3})\r\nValue:{4}",
                ID, Name, X, Y, Value);
        }

        //获取与另一点得距离
        public double GetDistance(DataPoint other)
        {
            return Math.Sqrt(Math.Pow(this.X - other.X, 2) + Math.Pow(this.Y - other.Y, 2));
        }

        public double GetDistance(double x, double y)
        {
            return Math.Sqrt(Math.Pow(this.X - x, 2) + Math.Pow(this.Y - y, 2));
        }

        public double GetDistanceP2(double x, double y)
        {
            return (Math.Pow(this.X - x, 2) + Math.Pow(this.Y - y, 2));
        }

        //获取在另一点的方位角(角度)
        public double GetPosition(double x,double y)
        {
            double deltaX = this.X - x;
            double deltaY = this.Y - y;
            if (deltaX * deltaY == 0)
            {
                if (deltaX == 0)
                {
                    if (deltaY > 0)
                        return 90;
                    else if (deltaY < 0)
                        return 270;
                    else
                        throw new Exception("DataPoint.GetPosition:两点重合");                    
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

        public static Vector2D operator - (DataPoint p1 ,DataPoint p2)
        {
            return new Vector2D(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static double Angle(DataPoint c, DataPoint a, DataPoint b)
        {
            double ang;
            double l1 = Math.Sqrt((b.X - c.X) * (b.X - c.X) + (b.Y - c.Y) * (b.Y - c.Y));
            double l2 = Math.Sqrt((a.X - c.X) * (a.X - c.X) + (a.Y - c.Y) * (a.Y - c.Y));
            double l3 = Math.Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y));
            ang = Math.Acos((l1 * l1 + l2 * l2 - l3 * l3) / (2 * l1 * l2));
            return ang;
        }

        public static int LeftOrRight(DataPoint c, DataPoint a, DataPoint b)
        {
            int youbian;
            double S;
            S = (a.X - c.X) * (b.Y - c.Y) - (a.Y - c.Y) * (b.X - c.X);
            if (S > 0)
            {
                youbian = 1;
            }
            else if (S < 0)
            {
                youbian = -1;
            }
            else
            {
                youbian = 0;
            }
            return youbian;
        }


    }
}
