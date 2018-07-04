using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGIS_work.DataStructure
{
    public class MinBoundRect
    {
        public double MinX { get; private set; }
        public double MinY { get; private set; }
        public double MaxX { get; private set; }
        public double MaxY { get; private set; }

        public MinBoundRect()
        {
            this.MinX = double.MaxValue;
            this.MinY = double.MaxValue;
            this.MaxX = double.MinValue;
            this.MaxY = double.MinValue;
        }
        public MinBoundRect(double minX,double minY,double maxX,double maxY)
        {
            this.MinX = minX;
            this.MinY = minY;
            this.MaxX = maxX;
            this.MaxY = maxY;
        }

        public void UpdateRect(double x,double y)
        {
            this.MinX = Math.Min(this.MinX, x);
            this.MinY = Math.Min(this.MinY, y);
            this.MaxX = Math.Max(this.MaxX, x);
            this.MaxY = Math.Max(this.MaxY, y);
            return;
        }

        public void UpdateRect(MinBoundRect mbr)
        {
            this.MinX = Math.Min(this.MinX, mbr.MinX);
            this.MinY = Math.Min(this.MinY, mbr.MinY);
            this.MaxX = Math.Max(this.MaxX, mbr.MaxX);
            this.MaxY = Math.Max(this.MaxY, mbr.MaxY);
            return;
        }

        public void PanningVector(double deltaX,double deltaY)
        {
            this.MinX += deltaX;
            this.MinY += deltaY;
            this.MaxX += deltaX;
            this.MaxY += deltaY;
        }

        public void ZoomPointAndRatio(double x,double y,double ratio)
        {
            this.MinX = x - (x - this.MinX) * ratio;
            this.MinY = y - (y - this.MinY) * ratio;
            this.MaxX = (this.MaxX - x) * ratio + x;
            this.MaxY = (this.MaxY - y) * ratio + y;
        }
    }
}
