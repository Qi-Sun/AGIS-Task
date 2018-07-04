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

        private void buttonNodeSelect_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveForm = new SaveFileDialog();
            if (saveForm.ShowDialog(this) == DialogResult.OK)
            {
                this.textBoxNodePath.Text = saveForm.FileName;
            }
        }

        private void buttonPointSelect_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveForm = new SaveFileDialog();
            if (saveForm.ShowDialog(this) == DialogResult.OK)
            {
                this.textBoxPointPath.Text = saveForm.FileName;
            }
        }

        private void buttonArcSelect_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveForm = new SaveFileDialog();
            if (saveForm.ShowDialog(this) == DialogResult.OK)
            {
                this.textBoxArcPath.Text = saveForm.FileName;
            }
        }

        private void buttonGonSelect_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveForm = new SaveFileDialog();
            if (saveForm.ShowDialog(this) == DialogResult.OK)
            {
                this.textBoxGonPath.Text = saveForm.FileName;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (checkBoxNode.Checked && textBoxNodePath.Text != "")
            {
               // this.Nset.SaveNodeTableToFile(textBoxNodePath.Text);
                try
                {
                    this.Nset.SaveNodeTableToFile(textBoxNodePath.Text);
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message, "保存失败！");
                }
            }
            if (checkBoxPoint.Checked && textBoxPointPath.Text != "")
            {
                //this.Nset.SavePointTableToFile(textBoxPointPath.Text);
                try
                {
                    this.Nset.SavePointTableToFile(textBoxPointPath.Text);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "保存失败！");
                }
            }
            if (checkBoxArc.Checked && textBoxArcPath.Text != "")
            {
                //this.Lset.SavePolylineTableToFile(textBoxArcPath.Text);
                try
                {
                    this.Lset.SavePolylineTableToFile(textBoxArcPath.Text);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "保存失败！");
                }
            }
            if (checkBoxGon.Checked && textBoxGonPath.Text != "")
            {
                //this.Pset.SavePolygonTableToFile(textBoxGonPath.Text);
                try
                {
                    this.Pset.SavePolygonTableToFile(textBoxGonPath.Text);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "保存失败！");
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
