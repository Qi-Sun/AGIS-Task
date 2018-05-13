using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AGIS_work.Forms.File;
using AGIS_work.DataStructure;

namespace AGIS_work
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public PointSet mPointSet;

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void 打开ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileForm openFile = new OpenFileForm();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                mPointSet = PointSet.ReadFromCSV(openFile.PointSetFileName);
            }
            agisControl.LoadPointSet(mPointSet,1.2);
            agisControl.Refresh();
            return;
        }

        private void agisControl_Resize(object sender, EventArgs e)
        {
            agisControl.Refresh();
        }

        private void agisControl_MarginChanged(object sender, EventArgs e)
        {
            agisControl.Refresh();
        }
    }
}
