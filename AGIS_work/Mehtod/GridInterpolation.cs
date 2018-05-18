using AGIS_work.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.Mehtod
{
    public enum GridInterpolationMehtod
    {
        None = 0,
        距离平方倒数法 = 1,
        按方位加权平均法 = 2
    }

    public class GridInterpolation
    {
        public PointSet mPointSet { get; private set; }
        public GridInterpolation(PointSet pointSet)
        {
            this.mPointSet = pointSet;
        }

        public double CalculateValueBy距离平方倒数法(double x,double y)
        {
            throw new Exception("Unfinished");
        }

        public double CalculateValueBy按方位加权平均法(double x, double y)
        {
            throw new Exception("Unfinished");
        }
    }
}
