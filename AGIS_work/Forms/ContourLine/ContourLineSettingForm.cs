using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGIS_work.Forms.ContourLine
{
    public partial class ContourLineSettingForm : Form
    {
        public double MaxValue = 0;
        public double MinValue = -480;
        public double IntervalValue = 60;


        public ContourLineSettingForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            MaxValue = (int)numUD_EleMax.Value;
            MinValue = (int)numUD_EleMin.Value;
            IntervalValue = (int)numUD_EleInt.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
