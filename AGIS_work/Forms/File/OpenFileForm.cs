using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGIS_work.Forms.File
{
    public partial class OpenFileForm : Form
    {
        public string PointSetFileName { get; private set; }
        public OpenFileForm()
        {
            InitializeComponent();
        }

        private void bttnOK_Click(object sender, EventArgs e)
        {
            PointSetFileName = this.txtBxFilename.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bttnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtBxFilename.Text = openDialog.FileName;
            }
        }

        private void OpenFileForm_Load(object sender, EventArgs e)
        {
            PointSetFileName = this.txtBxFilename.Text;
        }
    }
}
