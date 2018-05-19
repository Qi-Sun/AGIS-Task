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

        public DataPoint(int id, string name, double x, double y, double value)
        {
            this.ID = id;
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.Value = value;
            this.MBR = new MinBoundRect(x, y, x, y);
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
    }
}
