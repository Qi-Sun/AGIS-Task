using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AGIS_work.DataStructure;

namespace AGIS_work.Forms.Topology
{
    public partial class QueryPolygonInfoForm : Form
    {
        public QueryPolygonInfoForm(TopoPolygonSet polygonset)
        {
            InitializeComponent();
            this.sTopoPolygonSet = polygonset;
        }
        public TopoPolygonSet sTopoPolygonSet;

        private void bttnQuit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void QueryPolygonInfoForm_Load(object sender, EventArgs e)
        {
            foreach (var polygon in sTopoPolygonSet.TopoPolygonList)
            {
                comboBox1.Items.Add(polygon.PID);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TopoPolygon SelectedTopoPolygon = sTopoPolygonSet.TopoPolygonList[comboBox1.SelectedIndex];
            textBox1.Text = string.Format("PID:\t{0}\r\n弧段数:\t{1}\r\n周长:\t{2}\r\n面积:\t{3}",
                        SelectedTopoPolygon.PID, SelectedTopoPolygon.TopologyArcs.Count,
                        SelectedTopoPolygon.GetPerimeter().ToString("0.00"),
                        SelectedTopoPolygon.GetArea().ToString("0.00"));
        }
    }
}
