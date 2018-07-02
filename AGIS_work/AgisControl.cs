using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AGIS_work.DataStructure;
using System.Drawing.Drawing2D;
using AGIS_work.Mehtod;

namespace AGIS_work
{
    public enum UserOperationType
    {
        None = 0,
        DisplayThePointSet = 1,
        DisplayInGrid = 2,
        DisplayInTIN = 3,
        GenerateContourByGrid = 4,
        GenerateContourByTin = 5,
        GenerateTopology

    }

    public partial class AgisControl : UserControl
    {
        public AgisControl()
        {
            InitializeComponent();
            ZoomScale = 1;
            CenterPoint = new PointF(0, 0);
            this.MouseWheel += this.AgisControl_MouseWheel;
        }

        

        public PointSet PointSet { get; private set; }
        public UserOperationType UserOperation { get; private set; }

        public MinBoundRect MBR_Origin { get; private set; }
        public PointF CenterPoint { get; private set; }
        public double ZoomScale { get; private  set; }   //  Screen / RawData
        public Brush PointBrush = new SolidBrush(Color.Indigo);
        public double PointRadius = 3;
        public double FrameScaling = 1.2;
        public double Zoom = 1;
        public PointF CurMouseLocation;
        public bool IsPanning = false;
        public double OffsetX = 0;
        public double OffsetY = 0;

        //格网差值
        public int 距离平方倒数法NearPts = -1;
        public int 按方位加权平均法SectorNum = -1;
        public GridInterpolationMehtod GridIntMethod = GridInterpolationMehtod.None;

        public bool LoadPointSet(PointSet pointset, double frameScaling = 1.2)
        {
            try
            {
                this.PointSet = pointset;
                this.FrameScaling = frameScaling;
                //重绘
                MinBoundRect pointMBR = pointset.MBR;
                CenterPoint = new PointF((float)(pointMBR.MaxX + pointMBR.MinX) / 2,
                    (float)(pointMBR.MaxY + pointMBR.MinY) / 2);
                double pointSetWidth = pointMBR.MaxX - pointMBR.MinX;
                double pointSetHeight = pointMBR.MaxY - pointMBR.MinY;
                this.ZoomScale = Math.Min(this.Height / (pointSetHeight),
                    this.Width / (pointSetWidth)) / frameScaling;
                MBR_Origin = new MinBoundRect(CenterPoint.X - pointSetWidth * frameScaling / 2,
                    CenterPoint.Y - pointSetHeight * frameScaling / 2,
                    CenterPoint.X + pointSetWidth * frameScaling / 2,
                    CenterPoint.Y + pointSetHeight * frameScaling / 2);
                OffsetX = MBR_Origin.MinX;
                OffsetY = MBR_Origin.MinY;
                Zoom = ZoomScale;
                UserOperation = UserOperationType.DisplayThePointSet;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void AgisControl_Load(object sender, EventArgs e)
        {

        }

        private void AgisControl_Paint(object sender, PaintEventArgs e)
        {/*
            try
            {
                Graphics g = e.Graphics;
                foreach (DataPoint point in PointSet.PointList)
                {                   
                    g.FillRectangle(PointBrush, (float)((point.X - this.OffsetX) * this.Zoom - PointRadius),
                        (float)(this.Height - ((point.Y - this.OffsetY) * this.Zoom - PointRadius)),
                        (float)(PointRadius * 2), (float)(PointRadius * 2));
                    //MessageBox.Show(string.Format("[0} {1}", (float)((point.X - this.MBR.MinX) * this.Scale),
                    //    this.Height - (float)((point.Y - this.MBR.MinY) * this.Scale)));
                }
            }
            catch { }*/
        }

        public void SetUserOperationToDisplayInGrid()
        {
            this.UserOperation = UserOperationType.DisplayInGrid;
        }

        /// <summary>
        /// 获取实际坐标点在屏幕上的位置
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public PointF GetScreenLocation(double x,double y)
        {
            return new PointF((float)((x - this.OffsetX) * this.Zoom),
                (float)(this.Height - ((y - this.OffsetY) * this.Zoom)));
        }

        /// <summary>
        /// 单独获取实际坐标点X轴在屏幕上的位置
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double GetScreenLocX(double x)
        {
            return (x - this.OffsetX) * this.Zoom;
        }
        /// <summary>
        /// 单独获取实际坐标点Y轴在屏幕上的位置
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public double GetScreenLocY(double y)
        {
            return (this.Height - ((y - this.OffsetY) * this.Zoom));
        }

        /// <summary>
        /// 获取实际边在屏幕上的投影
        /// </summary>
        /// <param name="edge"></param>
        /// <returns></returns>
        public PointF[] GetScreenEdge(Edge edge)
        {
            PointF startP = new PointF((float)GetScreenLocX(edge.StartPoint.X), (float)GetScreenLocY(edge.StartPoint.Y));
            PointF endP = new PointF((float)GetScreenLocX(edge.EndPoint.X), (float)GetScreenLocY(edge.EndPoint.Y));
            return new PointF[] { startP,endP };
        }



        /// <summary>
        /// 获取屏幕点的实际位置。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double[] GetRealWorldLocation(float x , float y)
        {
            return new double[] { (x / this.Zoom + this.OffsetX),
                ((this.Height - y) / this.Zoom + this.OffsetY) };
           
        }

        public double GetRealWorldLocX(float x)
        {
            return x / this.Zoom + this.OffsetX;
        }

        public double GetRealWorldLocY(float y)
        {
            return (this.Height - y) / this.Zoom + this.OffsetY;
        }

        private void AgisControl_Resize(object sender, EventArgs e)
        {
            try
            {
                /*
                this.Scale = Math.Min(this.Width / (PointSet.MBR.MaxX - PointSet.MBR.MinX),
                    this.Height / (PointSet.MBR.MaxY - PointSet.MBR.MinY)) / this.FrameScaling;
                this.Refresh();*/
            }
            catch
            {

            }
            this.Refresh(); 
        }

        private void AgisControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                OffsetX = MBR_Origin.MinX;
                OffsetY = MBR_Origin.MinY;
                this.ZoomScale = Math.Min(this.Height / (this.PointSet.MBR.MaxY - this.PointSet.MBR.MinY),
                    this.Width / (this.PointSet.MBR.MaxX - this.PointSet.MBR.MinX)) / this.FrameScaling;
                this.Zoom = this.ZoomScale;
            }
            this.Refresh();
        }

        private void AgisControl_MouseWheel(object sender, MouseEventArgs e)
        {
            PointF mouseLoc = e.Location;
            double[] curLoc = this.GetRealWorldLocation(mouseLoc.X, mouseLoc.Y);
            if (e.Delta > 0)
            {
                OffsetX = curLoc[0] - (curLoc[0] - OffsetX) * 0.9;
                OffsetY = curLoc[1] - (curLoc[1] - OffsetY) * 0.9;
                Zoom /= 0.9;
            }
            else
            {
                OffsetX = curLoc[0] - (curLoc[0] - OffsetX) / 0.9;
                OffsetY = curLoc[1] - (curLoc[1] - OffsetY) / 0.9;
                Zoom *= 0.9;
            }
            this.Refresh();
        }

        private void AgisControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsPanning == true)
            {
                PointF mouseLoc = e.Location;
                double[] curLoc = this.GetRealWorldLocation(mouseLoc.X, mouseLoc.Y);
                double[] lastLoc = this.GetRealWorldLocation(this.CurMouseLocation.X, this.CurMouseLocation.Y);
                this.OffsetX += -curLoc[0] + lastLoc[0];
                this.OffsetY += -curLoc[1] + lastLoc[1];
                this.Refresh();
                this.CurMouseLocation = mouseLoc;
            }
        }

        private void AgisControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.IsPanning = true;
            this.CurMouseLocation = e.Location;
        }

        private void AgisControl_MouseUp(object sender, MouseEventArgs e)
        {
            this.IsPanning = false;
            this.CurMouseLocation = e.Location;
        }

        public double GetGridInterpolationValue(double x,double y)
        {
            GridInterpolation method = new GridInterpolation(this.PointSet);
            switch (this.GridIntMethod)
            {
                case GridInterpolationMehtod.None:
                    throw new Exception("未选择插值方法");
                case GridInterpolationMehtod.距离平方倒数法:
                    return method.CalculateValueBy距离平方倒数法(x, y, 距离平方倒数法NearPts);
                case GridInterpolationMehtod.按方位加权平均法:
                    return method.CalculateValueBy按方位加权平均法(x, y, 按方位加权平均法SectorNum);
                default:
                    throw new Exception("未选择插值方法");
            }
        }
    }
}
