using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGIS_work.DataStructure;

namespace AGIS_work.Mehtod
{
    //格网生成等值线
    public class GridCreateContourLine
    {
        public List<double> XAxis = new List<double>();//横线值序列
        public List<double> YAxis = new List<double>();//竖线值序列
        public double[,] HH = null; //横边追踪数组
        public double[,] SS = null; //竖边追踪数组
        public int XCount = 0;
        public int YCount = 0;
        public double Elevation = 0;//当前等值线值

        public GridCreateContourLine(List<double> xAxis, List<double> yAxis,
            double[,] hh, double[,] ss, int xCount, int yCount, double elev)
        {
            XAxis = xAxis;
            YAxis = yAxis;
            HH = hh;
            SS = ss;
            XCount = xCount;
            YCount = yCount;
            Elevation = elev;

        }

        //           2
        //       ___________
        //      |           |
        //      |           |
        //    3 |           |  5
        //      |           |
        //      |___________|
        //  (i,j)     7
        //
        //生成所有等值线
        public List<ContourPolyline> CreateContourLines()
        {
            List<ContourPolyline> tempPolylineLsit = new List<ContourPolyline>();
            for (int i = 0; i < XCount; i++)
            {
                for (int j = 0; j <= YCount; j++)
                {
                    if (HH[i, j] < 2)
                    {
                        ContourPolyline tempPolyline = CreateContourLine(i, j, 2);
                        if (tempPolyline != null)
                            tempPolylineLsit.Add(tempPolyline);
                        tempPolyline = CreateContourLine(i, j, 7);
                        if (tempPolyline != null)
                            tempPolylineLsit.Add(tempPolyline);
                    }
                }
            }
            for (int i = 0; i <= XCount; i++)
            {
                for (int j = 0; j < YCount; j++)
                {
                    if (SS[i, j] < 2)
                    {
                        ContourPolyline tempPolyline = CreateContourLine(i, j, 3);
                        if (tempPolyline != null)
                            tempPolylineLsit.Add(tempPolyline);
                        tempPolyline = CreateContourLine(i, j, 5);
                        if (tempPolyline != null)
                            tempPolylineLsit.Add(tempPolyline);
                    }
                }
            }
            return tempPolylineLsit;
        }
        //生成一条等值线
        private ContourPolyline CreateContourLine(int ii, int jj, int direct)
        {
            List<DataPoint> tempDataPoints = new List<DataPoint>();
            int[] res = new int[3] { ii, jj, direct };
            while (res != null)
            {
                res = Track(res[0], res[1], res[2]);
                if (res != null)
                {
                    switch (res[2])
                    {
                        case 2:
                            tempDataPoints.Add(new DataPoint(-res[0] * 100 - res[1] - 1, "等值点" + (-res[0] * 100 - res[1] - 1).ToString(),
                                        XAxis[res[0]] + HH[res[0], res[1] + 1] * (XAxis[res[0] + 1] - XAxis[res[0]]),
                                        YAxis[res[1] + 1], Elevation/*, -res[0] * 100 - res[1] - 1*/));
                            HH[res[0], res[1] + 1] = 5;
                            break;
                        case 3:
                            tempDataPoints.Add(new DataPoint(res[0] * 100 + res[1],
                                "等值点" + (res[0] * 100 + res[1]).ToString(), XAxis[res[0]],
                                        YAxis[res[1]] + SS[res[0], res[1]] * (YAxis[res[1] + 1] - YAxis[res[1]]),
                                        Elevation/*, res[0] * 100 + res[1]*/));
                            SS[res[0], res[1]] = 5;
                            break;
                        case 5:
                            SS[res[0] + 1, res[1]] = 5;
                            tempDataPoints.Add(new DataPoint((res[0] + 1) * 100 + res[1],
                                "等值点" + ((1 + res[0]) * 100 + res[1]).ToString(), XAxis[res[0] + 1],
                                        YAxis[res[1]] + SS[res[0] + 1, res[1]] * (YAxis[res[1] + 1] - YAxis[res[1]]),
                                        Elevation/*, (res[0] + 1) * 100 + res[1]*/));
                            break;
                        case 7:
                            tempDataPoints.Add(new DataPoint(-res[0] * 100 - res[1], "等值点" + (-res[0] * 100 - res[1]).ToString(),
                                        XAxis[res[0]] + HH[res[0], res[1]] * (XAxis[res[0] + 1] - XAxis[res[0]]),
                                        XAxis[res[1]], Elevation/*, -res[0] * 100 - res[1]*/));
                            HH[res[0], res[1]] = 5;
                            break;
                        default:
                            break;
                    }
                }
            }
            if (tempDataPoints.Count > 0) { return new ContourPolyline(tempDataPoints.ToArray()); }
            else return null;
        }
        //追踪
        private int[] Track(int i, int j, int inDirc)
        {
            if (i < 0 || j < 0 || i >= XCount - 1 || j >= YCount - 1)
            { return null; }
            switch (inDirc)
            {
                case 2:
                    if (SS[i, j] < 2)
                        return new int[3] { i - 1, j, 5 };
                    else if (SS[i, j + 1] < 2)
                        return new int[3] { i + 1, j, 3 };
                    else if (HH[i, j] < 2)
                        return new int[3] { i, j - 1, 2 };
                    break;
                case 3:
                    if (HH[i, j] < 2)
                        return new int[3] { i, j - 1, 2 };
                    else if (HH[i, j + 1] < 2)
                        return new int[3] { i, j + 1, 7 };
                    else if (SS[i, j + 1] < 2)
                        return new int[3] { i + 1, j, 3 };
                    break;
                case 5:
                    if (HH[i, j + 1] < 2)
                        return new int[3] { i, j + 1, 7 };
                    else if (HH[i, j] < 2)
                        return new int[3] { i, j - 1, 2 };
                    else if (SS[i, j] < 2)
                        return new int[3] { i - 1, j, 5 };
                    break;
                case 7:
                    if (SS[i, j + 1] < 2)
                        return new int[3] { i + 1, j, 3 };
                    else if (SS[i, j] < 2)
                        return new int[3] { i - 1, j, 5 };
                    else if (HH[i, j + 1] < 2)
                        return new int[3] { i, j + 1, 7 };
                    break;
                default:
                    break;
            }
            return null;
        }
    }
}
