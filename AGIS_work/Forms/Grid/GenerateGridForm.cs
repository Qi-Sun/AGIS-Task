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
    public partial class GenerateGridForm : Form
    {
        public GenerateGridForm(int x,int y)
        {
            InitializeComponent();
            DivisionX = x;
            DivisionY = y;
            numericUpDown_X.Value = x != 0 ? x : 10;
            numericUpDown_Y.Value = y != 0 ? y : 10;
        }
        public int DivisionX;
        public int DivisionY;

        private void bttnOK_Click(object sender, EventArgs e)
        {
            DivisionX = (int)numericUpDown_X.Value;
            DivisionY = (int)numericUpDown_Y.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
