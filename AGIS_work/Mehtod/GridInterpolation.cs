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
        
        public double CalculateValueBy距离平方倒数法(double x,double y,int pts)
        {
            List<Tuple<DataPoint, double>> PointAndDistanceList = new List<Tuple<DataPoint, double>>();
            foreach (var point in mPointSet.PointList)
            {
                PointAndDistanceList.Add(new Tuple<DataPoint, double>(point, point.GetDistance(x, y)));
            }
            PointAndDistanceList.Sort((t1, t2) => t1.Item2.CompareTo(t2.Item2));
            double sDenominator = 0; //分母
            double sNumerator = 0;  //分子
            for (int i = 0; i < pts; i++)
            {
                sDenominator += 1 / PointAndDistanceList[i].Item2;
                sNumerator += (PointAndDistanceList[i].Item1.Value) / PointAndDistanceList[i].Item2;
            }
            return sNumerator / sDenominator;
        }

        public double CalculateValueBy按方位加权平均法(double x, double y,int sectorNums)
        {
            List<Tuple<DataPoint, double>>[] PointPositionDistanceList
                = new List<Tuple<DataPoint, double>>[sectorNums];
            for (int i = 0; i < sectorNums; i++)
                PointPositionDistanceList[i] = new List<Tuple<DataPoint, double>>();
            double sectorArc = 360.0 / sectorNums;
            foreach (var point in mPointSet.PointList)
            {
                double alpha = point.GetPosition(x, y);
                PointPositionDistanceList[(int)(alpha / sectorArc)].Add(new Tuple<DataPoint, double>(point, point.GetDistanceP2(x, y)));
            }
            List<Tuple<DataPoint, double>> SelectedPointList = new List<Tuple<DataPoint, double>>();
            for (int i = 0; i < sectorNums; i++)
            {
                if (PointPositionDistanceList[i].Count != 0)
                {
                    PointPositionDistanceList[i].Sort((t1, t2) => t1.Item2.CompareTo(t2.Item2));
                    SelectedPointList.Add(PointPositionDistanceList[i][0]);
                }
            }
            List<double> WeightList = new List<double>();
            int SelectPointCount = SelectedPointList.Count;
            if (SelectPointCount != 0)
            {
                double sProduct = 1; //总的乘积
                double sDenominator = 0; //分母
                double sResult = 0; //结果
                for (int j = 0; j < SelectPointCount; j++)
                    sProduct *= SelectedPointList[j].Item2;
                for (int j = 0; j < SelectPointCount; j++)
                {
                    WeightList.Add(sProduct / SelectedPointList[j].Item2);
                    sDenominator += sProduct / SelectedPointList[j].Item2;
                }
                for (int j = 0; j < SelectPointCount; j++)
                    sResult += WeightList[j] * SelectedPointList[j].Item1.Value / sDenominator;
                return sResult;
            }
            else throw new Exception("CalculateValueBy按方位加权平均法:没有选中的点");
        }
    }
}
