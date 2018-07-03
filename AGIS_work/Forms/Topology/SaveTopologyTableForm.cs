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
    public partial class SaveTopologyTableForm : Form
    {
        private TopoPointSet Nset;
        private TopoPolylineSet Lset;
        private TopoPolygonSet Pset;

        public SaveTopologyTableForm(TopoPointSet nset,TopoPolylineSet lset,TopoPolygonSet pset)
        {
            InitializeComponent();
            Nset = nset;
            Lset = lset;
            Pset = pset;
        }

        private void SaveTopologyTableForm_Load(object sender, EventArgs e)
        {

        }
    }
}
