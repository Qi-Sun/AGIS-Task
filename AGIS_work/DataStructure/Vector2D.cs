using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    public class Vector2D
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Vector2D(double x,double y)
        {
            this.X = x;
            this.Y = y;
        }
        public double CrossProduct(Vector2D v2)
        {
            return this.X * v2.Y - this.Y * v2.X;
        }
        public double DotProduct(Vector2D v2)
        {
            return this.X * v2.X + this.Y * v2.Y;
        }

        public static Vector2D operator + (Vector2D v1,Vector2D v2)
        {
            return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
        }
    }
}
