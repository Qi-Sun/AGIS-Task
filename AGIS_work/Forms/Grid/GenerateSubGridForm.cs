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
    public partial class GenerateSubGridForm : Form
    {
        public int Division_X;
        public int Division_Y;
        public GenerateSubGridForm(int defaultX,int defaultY)
        {
            InitializeComponent();
            Division_X = defaultX != 1 ? defaultX : (int)this.numericUpDown_X.Value;
            Division_Y = defaultY != 1 ? defaultY : (int)this.numericUpDown_Y.Value;
        }

        private void bttnOK_Click(object sender, EventArgs e)
        {
            Division_X = (int)this.numericUpDown_X.Value;
            Division_Y = (int)this.numericUpDown_Y.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void GenerateSubGridForm_Load(object sender, EventArgs e)
        {
            this.numericUpDown_X.Value = Division_X;
            this.numericUpDown_Y.Value = Division_Y;
        }
    }
}
