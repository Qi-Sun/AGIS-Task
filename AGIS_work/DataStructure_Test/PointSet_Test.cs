using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGIS_work.DataStructure;
using Xunit;
using System.IO;

namespace AGIS_work.DataStructure_Test
{	
    public class PointSet_Test
    {
        [Fact]
        public void ReadFromCSV_Test()
        {
            //Console.WriteLine(Environment.CurrentDirectory.ToString());
            PointSet pointSet = PointSet.ReadFromCSV("..//..//Data//TestData.csv");
        }
    }
}
