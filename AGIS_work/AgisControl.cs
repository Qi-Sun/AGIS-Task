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

namespace AGIS_work
{
    public enum UserOperationType
    {
        None = 0,
        DisplayThePointSet = 1
    }

    public partial class AgisControl : UserControl
    {
        public AgisControl()
        {
            InitializeComponent();
            Scale = 1;
            CenterPoint = new PointF(0, 0);
            MBR = new MinBoundRect(-1, -1, 1, 1);
        }

        public PointSet PointSet { get; private set; }
        public UserOperationType UserOperation { get; private set; }

        public MinBoundRect MBR { get; set; }
        public PointF CenterPoint { get; set; }
        public double Scale { get; set; }   //  Screen / RawData
        public Brush PointBrush = new SolidBrush(Color.Indigo);
        public float PointRadius = 3;
        public double FrameScaling = 1.2;

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
                this.Scale = Math.Min(this.Height / (pointSetHeight),
                    this.Width / (pointSetWidth)) / frameScaling;
                MBR = new MinBoundRect(CenterPoint.X - pointSetWidth * frameScaling / 2,
                    CenterPoint.Y - pointSetHeight * frameScaling / 2,
                    CenterPoint.X + pointSetWidth * frameScaling / 2,
                    CenterPoint.Y - pointSetHeight * frameScaling / 2);
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
        {
            switch (UserOperation)
            {
                case UserOperationType.DisplayThePointSet:
                    foreach (DataPoint point in PointSet.PointList)
                    {
                        Graphics g = e.Graphics;
                        g.FillEllipse(PointBrush, (float)((point.X - this.MBR.MinX) * this.Scale - PointRadius),
                            this.Height - (float)((point.Y - this.MBR.MinY) * this.Scale - PointRadius),
                            PointRadius * 2, PointRadius * 2);
                    }
                    break;
                default:
                    break;
            }
        }

        private void AgisControl_Resize(object sender, EventArgs e)
        {
            try
            {
                this.Scale = Math.Min(this.Width / (PointSet.MBR.MaxX - PointSet.MBR.MinX),
                    this.Height / (PointSet.MBR.MaxY - PointSet.MBR.MinY)) / this.FrameScaling;
                this.Refresh();
            }
            catch
            {

            }
        }
        
    }
}
