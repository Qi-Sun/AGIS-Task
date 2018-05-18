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
using AGIS_work.Forms.Grid;

namespace AGIS_work
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public PointSet mPointSet;

        public UserOperationType UserOperation;

        // ----格网相关
        public bool IsGridVisible = false;
        public int GridDivisionCount_X = 0;
        public int GridDivisionCount_Y = 0;
        public float GridLineWidth = 2.0f;
        public float GridSubLineWidth = 1.0f;
        public Pen GridLinePen = new Pen(Color.Black);

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void 打开ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            OpenFileForm openFile = new OpenFileForm();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                mPointSet = PointSet.ReadFromCSV(openFile.PointSetFileName);
                this.Width = 1000;
                this.Height = 800;
                this.UserOperation = UserOperationType.DisplayThePointSet;
                agisControl.LoadPointSet(mPointSet, 1.2);
                agisControl.Refresh();
            }
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

        private void agisControl_Paint(object sender, PaintEventArgs e)
        {
            //画一些基础的图形
            if (this.UserOperation != UserOperationType.None) { }
            //在网格中
            if (this.UserOperation == UserOperationType.DisplayInGrid)
            {
                //格网可见，且XY方向等分数不为0
                if (IsGridVisible != false && GridDivisionCount_X != 0 && GridDivisionCount_Y != 0)
                {
                    Graphics g = e.Graphics;
                    this.GridLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    PointF MinPointXY = this.agisControl.GetScreenLocation(agisControl.MBR_Origin.MinX, agisControl.MBR_Origin.MinY);
                    PointF MaxPointXY = this.agisControl.GetScreenLocation(agisControl.MBR_Origin.MaxX, agisControl.MBR_Origin.MaxY);
                    float width = MaxPointXY.X - MinPointXY.X;
                    float height = MaxPointXY.Y - MinPointXY.Y;
                    //g.DrawLine(new Pen(Color.Green), MinPointXY, MaxPointXY);
                    
                    for (int i = 0; i <= GridDivisionCount_X; i++)
                    {
                        g.DrawLine(this.GridLinePen, MinPointXY.X+  i * (width / GridDivisionCount_X), MinPointXY.Y,
                           MinPointXY.X+  i * (width / GridDivisionCount_X), MaxPointXY.Y);
                    }
                    for (int j = 0; j <= GridDivisionCount_Y; j++)
                    {
                        g.DrawLine(this.GridLinePen, MinPointXY.X, MinPointXY.Y+ j * (height / GridDivisionCount_Y),
                           MaxPointXY.X, MinPointXY.Y + j * (height / GridDivisionCount_Y));
                    }
                }                  
            }

        }

        private void agisControl_MouseMove(object sender, MouseEventArgs e)
        {
            switch (this.UserOperation)
            {
                case UserOperationType.None:
                    break;
                default:
                    PointF mouse = e.Location;
                    StatusLabelScreenX.Text = mouse.X.ToString("0.000");
                    StatusLabelScreenY.Text = mouse.Y.ToString("0.000");
                    double[] realLoc = agisControl.GetRealWorldLocation(mouse.X, mouse.Y);
                    StatusLabel_X.Text = realLoc[0].ToString("0.000");
                    StatusLabel_Y.Text = realLoc[1].ToString("0.000");
                    break;
            }
        }

        private void 距离平方倒数法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.agisControl.SetUserOperationToDisplayInGrid();
            this.UserOperation = UserOperationType.DisplayInGrid;
            this.agisControl.GridIntMethod = Mehtod.GridInterpolationMehtod.距离平方倒数法;
            按方位加权平均法ToolStripMenuItem.Checked = false;
            距离平方倒数法ToolStripMenuItem.Checked = true;
        }

        private void 按方位加权平均法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.agisControl.SetUserOperationToDisplayInGrid();
            this.UserOperation = UserOperationType.DisplayInGrid;
            this.agisControl.GridIntMethod = Mehtod.GridInterpolationMehtod.按方位加权平均法;
            按方位加权平均法ToolStripMenuItem.Checked = true;
            距离平方倒数法ToolStripMenuItem.Checked = false;
        }

        private void 加密网格toolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 查询节点属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 生成等值线ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 逐点插入法ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 生成等值线ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 生成拓扑关系ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 可视化ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 导出拓扑关系表ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 程序信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agisControl_MouseHover(object sender, EventArgs e)
        {

        }

        private void 显示隐藏格网ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsGridVisible = (显示隐藏格网ToolStripMenuItem.Checked == true);
            agisControl.Refresh();
        }

        private void 生成格网ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsGridVisible = true;
            this.显示隐藏格网ToolStripMenuItem.Checked = true;
            this.UserOperation = UserOperationType.DisplayInGrid;
            GenerateGridForm form = new GenerateGridForm(this.GridDivisionCount_X, this.GridDivisionCount_Y);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.GridDivisionCount_X = form.DivisionX;
                this.GridDivisionCount_Y = form.DivisionY;
                this.agisControl.Refresh();
            }
        }
    }
}
