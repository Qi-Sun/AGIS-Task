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
using AGIS_work.Mehtod;
using AGIS_work.Forms.ContourLine;

namespace AGIS_work
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.agisControl.MouseWheel += this.agisControl_MouseWheel;
        }



        public PointSet mPointSet;

        public UserOperationType UserOperation;

        // ----格网相关
        public bool IsGridVisible = false;
        public int GridDivisionCount_X = 0;
        public int GridDivisionCount_Y = 0;
        public int EachGridDivisionCount_X = 1;
        public int EachGridDivisionCount_Y = 1;
        public float GridLineWidth = 2.0f;
        public float GridSubLineWidth = 1.0f;
        public Pen GridLinePen = new Pen(Color.Black, 1.6f);
        public Pen GridSubLinePen = new Pen(Color.Black, 1.0f);
        public bool IsQueryIntersection = false;
        public List<double> Grid_AxisX = new List<double>();
        public List<double> Grid_AxisY = new List<double>();
        public List<double> GridScreen_AxisX = new List<double>();
        public List<double> GridScreen_AxisY = new List<double>();
        public Brush PointIconBrush = new SolidBrush(Color.Red);

        // -- 格网选中交点
        public int SelectPixelThreshold = 9;
        public PointF MouseLocation;
        public Pen GridSelectedPointPen = new Pen(Color.Cyan, 3.0f);
        public double SelectPointX = -1;
        public double SelectPointY = -1;

        // -- 格网等高线
        public Edge[] GridContourList = null;
        public Pen GridContourLinePen = new Pen(Color.Brown, 1.5f);
        public double[,] GridValueMatrix = null;
        public double[,] SS = null;
        public double[,] HH = null;

        // -- Tin相关
        public bool ShowTin = false;
        public Edge[] TinEdges = null;
        public Pen TinPen = new Pen(Color.Blue, 1.0f);

        // -- Tin等高线相关
        public int ContourLineType = 0; //0:不显示，1：根据格网，2：根据Tin
        public bool ShowContourLine = true;
        public Edge[] TinContourLineList = null;
        public Pen TinContourLinePen = new Pen(Color.Gray, 1.0f);

        private void MainForm_Load(object sender, EventArgs e)
        {
            GridLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            GridSubLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
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
                    PointF MinPointXY = this.agisControl.GetScreenLocation(agisControl.MBR_Origin.MinX, agisControl.MBR_Origin.MinY);
                    PointF MaxPointXY = this.agisControl.GetScreenLocation(agisControl.MBR_Origin.MaxX, agisControl.MBR_Origin.MaxY);
                    float width = MaxPointXY.X - MinPointXY.X;
                    float height = MaxPointXY.Y - MinPointXY.Y;
                    //g.DrawLine(new Pen(Color.Green), MinPointXY, MaxPointXY);                    
                    for (int i = 0; i < GridDivisionCount_X; i++)
                    {
                        g.DrawLine(this.GridLinePen, MinPointXY.X + i * (width / GridDivisionCount_X), MinPointXY.Y,
                           MinPointXY.X + i * (width / GridDivisionCount_X), MaxPointXY.Y);
                        for (int ii = 1; ii < EachGridDivisionCount_X; ii++)
                        {
                            g.DrawLine(this.GridSubLinePen, MinPointXY.X + (i + ii * 1.0f / EachGridDivisionCount_X) * (width / GridDivisionCount_X), MinPointXY.Y,
                           MinPointXY.X + (i + ii * 1.0f / EachGridDivisionCount_X) * (width / GridDivisionCount_X), MaxPointXY.Y);
                        }
                    }
                    g.DrawLine(this.GridLinePen, MinPointXY.X + width, MinPointXY.Y, MinPointXY.X + width, MaxPointXY.Y);
                    for (int j = 0; j < GridDivisionCount_Y; j++)
                    {
                        g.DrawLine(this.GridLinePen, MinPointXY.X, MinPointXY.Y + j * (height / GridDivisionCount_Y),
                           MaxPointXY.X, MinPointXY.Y + j * (height / GridDivisionCount_Y));
                        for (int jj = 0; jj < EachGridDivisionCount_Y; jj++)
                        {
                            g.DrawLine(this.GridSubLinePen, MinPointXY.X, MinPointXY.Y + (j + jj * 1.0f / EachGridDivisionCount_Y) * (height / GridDivisionCount_Y),
                           MaxPointXY.X, MinPointXY.Y + (j + jj * 1.0f / EachGridDivisionCount_Y) * (height / GridDivisionCount_Y));
                        }
                    }
                    g.DrawLine(this.GridLinePen, MinPointXY.X, MinPointXY.Y + height, MaxPointXY.X, MinPointXY.Y + height);
                    if (this.IsQueryIntersection == true && SelectPointX != 0 && SelectPointY != 0)
                    {
                        double sScreenSelectPointX = this.agisControl.GetScreenLocX(SelectPointX);
                        double sScreenSelectPointY = this.agisControl.GetScreenLocY(SelectPointY);

                        g.DrawEllipse(this.GridSelectedPointPen, (float)sScreenSelectPointX - SelectPixelThreshold,
                            (float)sScreenSelectPointY - SelectPixelThreshold,
                            SelectPixelThreshold * 2, SelectPixelThreshold * 2);
                    }
                }
                //绘制等值线
                if (ShowContourLine == true && GridContourList != null)
                {
                    for (int i = 0; i < GridContourList.Length; i++)
                    {
                        PointF[] screenLine = agisControl.GetScreenEdge(GridContourList[i]);
                        Graphics g = e.Graphics;
                        g.DrawLine(GridContourLinePen, screenLine[0], screenLine[1]);
                    }
                }
            }
            if (this.UserOperation == UserOperationType.DisplayInTIN)
            {
                //绘制三角网
                if (ShowTin == true && TinEdges != null)
                {
                    for (int i = 0; i < TinEdges.Length; i++)
                    {
                        PointF[] screenLine = agisControl.GetScreenEdge(TinEdges[i]);
                        Graphics g = e.Graphics;
                        g.DrawLine(TinPen, screenLine[0], screenLine[1]);
                    }
                }
                //绘制等高线
                if (ShowContourLine == true && TinContourLineList != null)
                {
                    for (int i = 0; i < TinContourLineList.Length; i++)
                    {
                        PointF[] screenLine = agisControl.GetScreenEdge(TinContourLineList[i]);
                        Graphics g = e.Graphics;
                        g.DrawLine(TinContourLinePen, screenLine[0], screenLine[1]);
                    }
                }
            }

            //绘制数据点
            if (mPointSet != null)
            {
                foreach (var point in mPointSet.PointList)
                {
                    Graphics g = e.Graphics;
                    g.FillRectangle(PointIconBrush, (float)agisControl.GetScreenLocX(point.X) - 3,
                        (float)agisControl.GetScreenLocY(point.Y) - 3, 6, 6);
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
            if (this.UserOperation == UserOperationType.DisplayInGrid)
            {
                if (this.IsGridVisible && this.IsQueryIntersection && this.agisControl.IsPanning)
                    GridDivisionScreenRefresh();
            }
        }

        private void agisControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (this.UserOperation == UserOperationType.DisplayInGrid)
            {
                if (this.IsGridVisible && this.IsQueryIntersection)
                    GridDivisionScreenRefresh();
            }
        }

        private void 距离平方倒数法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.agisControl.SetUserOperationToDisplayInGrid();

            if (agisControl.PointSet == null) return;
            int tempPara = agisControl.距离平方倒数法NearPts;
            if (tempPara < 0)
                tempPara = Math.Max(agisControl.PointSet.PointList.Count / 4, 1);
            GridIntParaForm form = new GridIntParaForm("取插值点邻域内最近的N个点", tempPara, 1, agisControl.PointSet.PointList.Count);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.UserOperation = UserOperationType.DisplayInGrid;
                this.agisControl.GridIntMethod = Mehtod.GridInterpolationMehtod.距离平方倒数法;
                按方位加权平均法ToolStripMenuItem.Checked = false;
                距离平方倒数法ToolStripMenuItem.Checked = true;
                agisControl.距离平方倒数法NearPts = form.ParaValue;
                MessageBox.Show("参数设置成功！", "提示");
            }
        }

        private void 按方位加权平均法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.agisControl.SetUserOperationToDisplayInGrid();
            if (agisControl.PointSet == null) return;
            int tempPara = agisControl.按方位加权平均法SectorNum;
            if (tempPara < 0)
                tempPara = Math.Max(agisControl.PointSet.PointList.Count / 8, 1);
            GridIntParaForm form = new GridIntParaForm("每个象限等分的no个扇区", tempPara, 1,
                Math.Max(agisControl.PointSet.PointList.Count / 4, 1));
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.UserOperation = UserOperationType.DisplayInGrid;
                this.agisControl.GridIntMethod = Mehtod.GridInterpolationMehtod.按方位加权平均法;
                按方位加权平均法ToolStripMenuItem.Checked = true;
                距离平方倒数法ToolStripMenuItem.Checked = false;
                agisControl.按方位加权平均法SectorNum = form.ParaValue * 4;
                MessageBox.Show("参数设置成功！", "提示");
            }
        }

        private void 加密网格toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.UserOperation != UserOperationType.DisplayInGrid)
            {
                MessageBox.Show("请先生成格网！", "提示");
                return;
            }
            if (this.IsGridVisible == false)
            {
                if (MessageBox.Show(this, "当先设置为不显示格网，继续操作将显示格网，是否继续？", "提示", MessageBoxButtons.OKCancel)
                    != DialogResult.OK)
                {
                    this.IsGridVisible = true;
                    this.显示隐藏格网ToolStripMenuItem.Checked = true;
                }
                else
                    return;
            }
            GenerateSubGridForm form = new GenerateSubGridForm(this.EachGridDivisionCount_X, this.EachGridDivisionCount_Y);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.EachGridDivisionCount_X = form.Division_X;
                this.EachGridDivisionCount_Y = form.Division_Y;
            }
            GridDivisionRefresh();
            this.agisControl.Refresh();
        }

        //每次格网重新划分时进行调用
        private void GridDivisionRefresh()
        {
            int TotalSegmentNum_X = GridDivisionCount_X * EachGridDivisionCount_X;
            int TotalSegmentNum_Y = GridDivisionCount_Y * EachGridDivisionCount_Y;
            double MbrMinX = agisControl.MBR_Origin.MinX;
            double MbrMaxX = agisControl.MBR_Origin.MaxX;
            double MbrMinY = agisControl.MBR_Origin.MinY;
            double MbrMaxY = agisControl.MBR_Origin.MaxY;
            double width = MbrMaxX - MbrMinX;
            double height = MbrMaxY - MbrMinY;
            Grid_AxisX = new List<double>();
            for (int i = 0; i <= TotalSegmentNum_X; i++)
                Grid_AxisX.Add(MbrMinX + i * width / TotalSegmentNum_X);
            Grid_AxisY = new List<double>();
            for (int i = 0; i <= TotalSegmentNum_Y; i++)
                Grid_AxisY.Add(MbrMinY + i * height / TotalSegmentNum_Y);
            return;
        }

        //格网重新划分或屏幕窗口平移或缩放时调用
        private void GridDivisionScreenRefresh()
        {
            int TotalSegmentNum_X = GridDivisionCount_X * EachGridDivisionCount_X;
            int TotalSegmentNum_Y = GridDivisionCount_Y * EachGridDivisionCount_Y;
            GridScreen_AxisX = new List<double>();
            for (int i = 0; i <= TotalSegmentNum_X; i++)
            {
                double screenX = agisControl.GetScreenLocX(Grid_AxisX[i]);
                if (screenX >= 0 && screenX < agisControl.Width)
                    GridScreen_AxisX.Add(screenX);
            }
            GridScreen_AxisY = new List<double>();
            for (int i = 0; i <= TotalSegmentNum_Y; i++)
            {
                double screenY = agisControl.GetScreenLocY(Grid_AxisY[i]);
                if (screenY >= 0 && screenY < agisControl.Height)
                    GridScreen_AxisY.Add(screenY);
            }
            return;
        }

        private void 查询节点属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.agisControl.GridIntMethod == Mehtod.GridInterpolationMehtod.None)
            {
                MessageBox.Show("尚未选择格网插值方法！\r\n请在“格网模型”中选择“距离平方倒数法”或“按方位加权平均法”！", "提示");
                return;
            }
            this.IsQueryIntersection = (this.IsQueryIntersection == true) ? false : true;
            this.查询节点属性ToolStripMenuItem.Checked = this.IsQueryIntersection;
            if (this.查询节点属性ToolStripMenuItem.Checked == true)
            {
                MessageBox.Show(" ‘双击’ 进行选取格网交点", "提示");
            }
            return;
        }

        private void 生成等值线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.UserOperation != UserOperationType.DisplayInGrid)
            {
                MessageBox.Show("当前并没有在格网下显示，请先生成网格！", "提示");
                return;
            }
            else if (this.agisControl.GridIntMethod == Mehtod.GridInterpolationMehtod.None)
            {
                MessageBox.Show("尚未选择格网插值方法！\r\n请在“格网模型”中选择“距离平方倒数法”或“按方位加权平均法”！", "提示");
                return;
            }
            else
            {
                this.生成等值线ToolStripMenuItem.Checked = (this.生成等值线ToolStripMenuItem.Checked == false);
                this.ShowContourLine = (this.生成等值线ToolStripMenuItem.Checked == true);
                if (this.ShowContourLine == false) { this.agisControl.Refresh(); return; }
                ContourLineSettingForm settingForm = new ContourLineSettingForm();
                if (settingForm.ShowDialog(this) == DialogResult.OK)
                {
                    //生成格网矩阵
                    List<Edge> tempGridContourLineList = new List<Edge>();
                    //计算等值线条数
                    int lineCount = (int)((settingForm.MaxValue - settingForm.MinValue) / settingForm.IntervalValue);
                    for (int k = 0; k < lineCount; k++)
                    {
                        double tempElevation = settingForm.MaxValue - k * settingForm.IntervalValue;
                        double[,] GridRealLoc = GridPointPositionMatrix();
                        double[,] tempHH = 内插等值点_HH(tempElevation);
                        double[,] tempSS = 内插等值点_SS(tempElevation);
                        int Grid_Count_all_X = this.EachGridDivisionCount_X * this.GridDivisionCount_X;
                        int Grid_Count_all_Y = this.EachGridDivisionCount_Y * this.GridDivisionCount_Y;
                        for (int i = 0; i < Grid_Count_all_X  ; i++)
                        {
                            for (int j = 0; j < Grid_Count_all_Y ; j++)
                            {
                                List<DataPoint> tempPointList = new List<DataPoint>();
                                //横边有等值点
                                if (tempHH[i, j] < 2)
                                {
                                    tempPointList.Add(new DataPoint(-i * 100 - j, "等值点" + (-i * 100 - j).ToString(),
                                        Grid_AxisX[i] + tempHH[i, j] * (Grid_AxisX[i + 1] - Grid_AxisX[i]),
                                        Grid_AxisY[j], tempElevation, -i * 100 - j));
                                }
                                //竖边有等值点
                                if (tempSS[i, j] < 2)
                                {
                                    tempPointList.Add(new DataPoint(i * 100 + j, "等值点" + (i * 100 + j).ToString(),
                                        Grid_AxisX[i],
                                        Grid_AxisY[j] + tempSS[i, j] * (Grid_AxisY[j + 1] - Grid_AxisY[j]),
                                        tempElevation, i * 100 + j));
                                }
                                //另一条横边有等值点
                                if (tempHH[i, j + 1] < 2)
                                {
                                    tempPointList.Add(new DataPoint(-i * 100 - j - 1, "等值点" + (-i * 100 - j - 1).ToString(),
                                        Grid_AxisX[i] + tempHH[i, j + 1] * (Grid_AxisX[i + 1] - Grid_AxisX[i]),
                                        Grid_AxisY[j + 1], tempElevation, -i * 100 - j - 1));
                                }
                                //另一条竖边有等值点
                                if (tempSS[i + 1, j] < 2)
                                {
                                    tempPointList.Add(new DataPoint((i + 1) * 100 + j, "等值点" + ((1 + i) * 100 + j).ToString(),
                                        Grid_AxisX[i + 1],
                                        Grid_AxisY[j] + tempSS[i + 1, j] * (Grid_AxisY[j + 1] - Grid_AxisY[j]),
                                        tempElevation, (i + 1) * 100 + j));
                                }
                                if (tempPointList.Count < 2)//无等值线
                                    continue;
                                else if (tempPointList.Count < 4)
                                {
                                    tempGridContourLineList.Add(new Edge(tempPointList[0], tempPointList[1],
                                        (tempPointList[0].GetHashCode() * tempPointList[1].GetHashCode()).GetHashCode()));
                                }
                                else
                                {
                                    tempGridContourLineList.Add(new Edge(tempPointList[0], tempPointList[1],
                                        (tempPointList[0].GetHashCode() * tempPointList[1].GetHashCode()).GetHashCode()));
                                    tempGridContourLineList.Add(new Edge(tempPointList[2], tempPointList[3],
                                        (tempPointList[2].GetHashCode() * tempPointList[3].GetHashCode()).GetHashCode()));
                                }
                            }
                        }
                        
                        for (int i = 0; i < Grid_Count_all_X - 1; i++)
                        {
                            int j = Grid_Count_all_Y - 1;
                        }
                    }
                    this.GridContourList = tempGridContourLineList.ToArray();
                }
                GridContourLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                agisControl.Refresh();
            }
        }

        //生成格网点的真实坐标位置
        private double[,] GridPointPositionMatrix()
        {
            List<double> tempGridAxisX = new List<double>();
            List<double> tempGridAxisY = new List<double>();
            tempGridAxisX.AddRange(Grid_AxisX);
            tempGridAxisY.AddRange(Grid_AxisY);
            //tempGridAxisX.Add(Grid_AxisX.Last() + Grid_AxisX[1] - Grid_AxisX[0]);
            //tempGridAxisY.Add(Grid_AxisY.Last() + Grid_AxisY[1] - Grid_AxisY[0]);
            int Grid_Count_all_X = this.EachGridDivisionCount_X * this.GridDivisionCount_X;
            int Grid_Count_all_Y = this.EachGridDivisionCount_Y * this.GridDivisionCount_Y;
            double[,] GridRealLoc = new double[Grid_Count_all_X + 1, Grid_Count_all_Y + 1];
            for (int i = 0; i <= Grid_Count_all_X; i++)
            {
                for (int j = 0; j <= Grid_Count_all_Y; j++)
                {
                    GridRealLoc[i, j] = agisControl.GetGridInterpolationValue(tempGridAxisX[i], tempGridAxisY[j]);
                }
            }
            this.GridValueMatrix = GridRealLoc;
            return GridRealLoc;
        }

        private double[,] 内插等值点_HH(double elev)
        {
            int Grid_Count_all_X = this.EachGridDivisionCount_X * this.GridDivisionCount_X;
            int Grid_Count_all_Y = this.EachGridDivisionCount_Y * this.GridDivisionCount_Y;
            double[,] tempHH = new double[Grid_Count_all_X, Grid_Count_all_Y + 1];
            for (int i = 0; i < Grid_Count_all_X ; i++)
            {
                for (int j = 0; j <= Grid_Count_all_Y; j++)
                {
                    double r = (elev - GridValueMatrix[i, j]) / (GridValueMatrix[i + 1, j] - GridValueMatrix[i, j]);
                    tempHH[i, j] = (r <= 1 && r >= 0) ? r : 3;
                }
            }
            this.HH = tempHH;
            return tempHH;
        }

        private double[,] 内插等值点_SS(double elev)
        {
            int Grid_Count_all_X = this.EachGridDivisionCount_X * this.GridDivisionCount_X;
            int Grid_Count_all_Y = this.EachGridDivisionCount_Y * this.GridDivisionCount_Y;
            double[,] tempSS = new double[Grid_Count_all_X + 1, Grid_Count_all_Y];
            for (int i = 0; i <= Grid_Count_all_X; i++)
            {
                for (int j = 0; j < Grid_Count_all_Y ; j++)
                {
                    double r = (elev - GridValueMatrix[i, j]) / (GridValueMatrix[i, j + 1] - GridValueMatrix[i, j]);
                    tempSS[i, j] = (r <= 1 && r >= 0) ? r : 3;
                }
            }
            this.SS = tempSS;
            return tempSS;
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 逐点插入法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //交互-格网与TIN
            if (逐点插入法ToolStripMenuItem.Checked == true)
            {
                //修改显示
                this.UserOperation = UserOperationType.DisplayInTIN;
                this.ShowTin = true;
                this.显示隐藏TINToolStripMenuItem.Checked = true;
                CreateTIN createTin = new CreateTIN(this.mPointSet);
                Edge[] tinEdges = createTin.EdgeExtension();
                Edge[] tinEdges2 = createTin.GeneTIN().ToArray();
                TinEdges = tinEdges;
                TriangleSet triSet = EdgeSet.TopologyGenerateTriangleSet(tinEdges, mPointSet);
                Triangle[] triList = triSet.TriangleList.ToArray();
                TinContourLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                agisControl.Refresh();
            }
            else
            {
                //修改显示
                this.UserOperation = UserOperationType.None;
                this.ShowTin = false;
                this.显示隐藏TINToolStripMenuItem.Checked = false;
            }

        }

        private void 生成等值线ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ShowContourLine = (this.生成等值线ToolStripMenuItem1.Checked == true);
            if (this.ShowContourLine == false) { this.agisControl.Refresh(); return; }
            ContourLineSettingForm settingForm = new ContourLineSettingForm();
            if (settingForm.ShowDialog(this) == DialogResult.OK)
            {
                //生成Tin
                CreateTIN createTin = new CreateTIN(this.mPointSet);
                Edge[] tinEdges = createTin.EdgeExtension();
                TinEdges = tinEdges;
                TriangleSet triSet = EdgeSet.TopologyGenerateTriangleSet(tinEdges, mPointSet);
                Triangle[] triList = triSet.TriangleList.ToArray();
                List<Edge> contourLinesList = new List<Edge>();
                //计算等值线条数
                int lineCount = (int)((settingForm.MaxValue - settingForm.MinValue) / settingForm.IntervalValue);
                for (int i = 0; i < lineCount; i++)
                {
                    for (int j = 0; j < triList.Length; j++)
                    {
                        Edge contourLine = triList[j].GetContourLine(settingForm.MaxValue - i * settingForm.IntervalValue);
                        if (contourLine != null)
                            contourLinesList.Add(contourLine);
                    }
                    this.TinContourLineList = contourLinesList.ToArray();
                }
            }
            TinContourLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            agisControl.Refresh();
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
                GridDivisionRefresh();
                this.agisControl.Refresh();
            }
        }

        private void agisControl_MouseClick(object sender, MouseEventArgs e)
        {
            MouseLocation = e.Location;
        }

        private void agisControl_MouseDown(object sender, MouseEventArgs e)
        {
            //MouseLocation = e.Location;
            //this.agisControl.Refresh();
        }

        private void agisControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MouseLocation = e.Location;
            GridDivisionScreenRefresh();
            if (this.UserOperation != UserOperationType.DisplayInGrid
                || GridDivisionCount_X * EachGridDivisionCount_X < 1
                || GridDivisionCount_Y * EachGridDivisionCount_Y < 1
                || this.IsGridVisible == false)
                return;
            if (e.Clicks == 2 && this.IsQueryIntersection == true)
            {
                SelectPointX = SelectPointY = -1;
                int gridScreen_AxisX_count = GridScreen_AxisX.Count;
                for (int i = 0; i < gridScreen_AxisX_count; i++)
                {
                    if (Math.Abs(GridScreen_AxisX[i] - this.MouseLocation.X) < this.SelectPixelThreshold)
                        SelectPointX = this.agisControl.GetRealWorldLocX((float)GridScreen_AxisX[i]);
                }
                int gridScreen_AxisY_count = GridScreen_AxisY.Count;
                for (int i = 0; i < gridScreen_AxisY_count; i++)
                {
                    if (Math.Abs(GridScreen_AxisY[i] - this.MouseLocation.Y) < this.SelectPixelThreshold)
                        SelectPointY = this.agisControl.GetRealWorldLocY((float)GridScreen_AxisY[i]);
                }
                //选中了格网点
                if (SelectPointX != -1 && SelectPointY != -1 && agisControl.GridIntMethod != Mehtod.GridInterpolationMehtod.None)
                {
                    this.agisControl.Refresh();
                    string MethodName = "";
                    string Para = "";
                    if (agisControl.GridIntMethod == Mehtod.GridInterpolationMehtod.按方位加权平均法)
                    {
                        if (agisControl.按方位加权平均法SectorNum < 0)
                        {
                            MessageBox.Show("按方位加权平均法 参数尚未设置", "错误");
                            return;
                        }
                        MethodName = "按方位加权平均法";
                        Para = string.Format("{0}:{1}", "每个象限等分扇区数N0", agisControl.按方位加权平均法SectorNum / 4);
                    }
                    else if (agisControl.GridIntMethod == Mehtod.GridInterpolationMehtod.距离平方倒数法)
                    {
                        if (agisControl.距离平方倒数法NearPts < 0)
                        {
                            MessageBox.Show("距离平方倒数法 参数尚未设置", "错误");
                            return;
                        }
                        MethodName = "距离平方倒数法";
                        Para = string.Format("{0}:{1}", "选取距插值点最近的N个点", agisControl.距离平方倒数法NearPts);
                    }
                    MessageBox.Show(string.Format("{0}\t\r\nX:{1}\t\nY:{2}\t\r\nValue:{3}\r\n\r\n{4}\r\n{5}",
                        "格网点属性信息：", SelectPointX.ToString("0.00"), SelectPointY.ToString("0.00"),
                        agisControl.GetGridInterpolationValue(SelectPointX, SelectPointY).ToString("0.000"),
                        "插值方法：" + MethodName, Para
                        ), "属性查询");
                }
            }

        }

        private void agisControl_Load(object sender, EventArgs e)
        {

        }

        private void 显示隐藏TINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowTin = (显示隐藏TINToolStripMenuItem.Checked == true);
            agisControl.Refresh();
        }

        private void 生成等值线ToolStripMenuItem1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Set等值线可见性(bool isVisable)
        {
            this.ShowContourLine = isVisable;
            生成等值线ToolStripMenuItem1.Checked = isVisable;
            生成等值线ToolStripMenuItem.Checked = isVisable;
            agisControl.Refresh();
        }
    }
}
