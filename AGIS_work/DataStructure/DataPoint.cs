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

        public DataPoint(int id,string name,double x,double y ,double value)
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

    }
}
