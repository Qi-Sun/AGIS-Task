using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGIS_work.Forms.Grid
{
    public partial class GridIntParaForm : Form
    {
        public GridIntParaForm(string pname,int pvalue,int pmin,int pmax)
        {
            InitializeComponent();
            ParaName = pname;
            ParaMinValue = pmin;
            ParaMaxValue = pmax;
            ParaDefaultValue = pvalue;
        }

        public string ParaName;
        public int ParaDefaultValue;
        public int ParaMaxValue;
        public int ParaMinValue;
        public int ParaValue { get; private set; }

        private void GridIntParaForm_Load(object sender, EventArgs e)
        {
            label_Pare.Text = ParaName;
            numericUpDown_Para.Minimum = this.ParaMinValue;
            numericUpDown_Para.Maximum = this.ParaMaxValue;
            numericUpDown_Para.Value = this.ParaDefaultValue;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            ParaValue = (int)this.numericUpDown_Para.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
