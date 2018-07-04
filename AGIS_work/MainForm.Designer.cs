namespace AGIS_work
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.格网模型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.距离平方倒数法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按方位加权平均法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.生成格网ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加密网格toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询节点属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.生成等值线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示隐藏格网ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除格网ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TIN模型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.逐点插入法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.生成等值线ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.显示隐藏TINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清楚TINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拓扑关系ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成拓扑关系ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.可视化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出拓扑关系表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.作者信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.程序信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_X = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel_X = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Y = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel_Y = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelScreenX = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabelScreenX = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelScreenY = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabelScreenY = new System.Windows.Forms.ToolStripStatusLabel();
            this.拓扑点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拓扑边ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拓扑多边形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agisControl = new AGIS_work.AgisControl();
            this.平滑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.格网模型ToolStripMenuItem,
            this.TIN模型ToolStripMenuItem,
            this.拓扑关系ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(995, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建toolStripMenuItem,
            this.打开ToolStripMenuItem1,
            this.保存ToolStripMenuItem,
            this.另存为ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建toolStripMenuItem
            // 
            this.新建toolStripMenuItem.Enabled = false;
            this.新建toolStripMenuItem.Name = "新建toolStripMenuItem";
            this.新建toolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.新建toolStripMenuItem.Text = "新建";
            // 
            // 打开ToolStripMenuItem1
            // 
            this.打开ToolStripMenuItem1.Name = "打开ToolStripMenuItem1";
            this.打开ToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.打开ToolStripMenuItem1.Text = "打开";
            this.打开ToolStripMenuItem1.Click += new System.EventHandler(this.打开ToolStripMenuItem1_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Enabled = false;
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.Enabled = false;
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.另存为ToolStripMenuItem.Text = "另存为";
            // 
            // 格网模型ToolStripMenuItem
            // 
            this.格网模型ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.距离平方倒数法ToolStripMenuItem,
            this.按方位加权平均法ToolStripMenuItem,
            this.toolStripSeparator3,
            this.生成格网ToolStripMenuItem,
            this.加密网格toolStripMenuItem,
            this.查询节点属性ToolStripMenuItem,
            this.toolStripSeparator1,
            this.生成等值线ToolStripMenuItem,
            this.toolStripSeparator2,
            this.设置ToolStripMenuItem});
            this.格网模型ToolStripMenuItem.Name = "格网模型ToolStripMenuItem";
            this.格网模型ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.格网模型ToolStripMenuItem.Text = "格网模型";
            // 
            // 距离平方倒数法ToolStripMenuItem
            // 
            this.距离平方倒数法ToolStripMenuItem.Name = "距离平方倒数法ToolStripMenuItem";
            this.距离平方倒数法ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.距离平方倒数法ToolStripMenuItem.Text = "距离平方倒数法";
            this.距离平方倒数法ToolStripMenuItem.Click += new System.EventHandler(this.距离平方倒数法ToolStripMenuItem_Click);
            // 
            // 按方位加权平均法ToolStripMenuItem
            // 
            this.按方位加权平均法ToolStripMenuItem.Name = "按方位加权平均法ToolStripMenuItem";
            this.按方位加权平均法ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.按方位加权平均法ToolStripMenuItem.Text = "按方位加权平均法";
            this.按方位加权平均法ToolStripMenuItem.Click += new System.EventHandler(this.按方位加权平均法ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // 生成格网ToolStripMenuItem
            // 
            this.生成格网ToolStripMenuItem.Name = "生成格网ToolStripMenuItem";
            this.生成格网ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.生成格网ToolStripMenuItem.Text = "生成格网";
            this.生成格网ToolStripMenuItem.Click += new System.EventHandler(this.生成格网ToolStripMenuItem_Click);
            // 
            // 加密网格toolStripMenuItem
            // 
            this.加密网格toolStripMenuItem.Name = "加密网格toolStripMenuItem";
            this.加密网格toolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.加密网格toolStripMenuItem.Text = "加密网格";
            this.加密网格toolStripMenuItem.Click += new System.EventHandler(this.加密网格toolStripMenuItem_Click);
            // 
            // 查询节点属性ToolStripMenuItem
            // 
            this.查询节点属性ToolStripMenuItem.Name = "查询节点属性ToolStripMenuItem";
            this.查询节点属性ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.查询节点属性ToolStripMenuItem.Text = "查询节点属性";
            this.查询节点属性ToolStripMenuItem.Click += new System.EventHandler(this.查询节点属性ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // 生成等值线ToolStripMenuItem
            // 
            this.生成等值线ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.平滑ToolStripMenuItem});
            this.生成等值线ToolStripMenuItem.Name = "生成等值线ToolStripMenuItem";
            this.生成等值线ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.生成等值线ToolStripMenuItem.Text = "生成等值线";
            this.生成等值线ToolStripMenuItem.Click += new System.EventHandler(this.生成等值线ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示隐藏格网ToolStripMenuItem,
            this.清除格网ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // 显示隐藏格网ToolStripMenuItem
            // 
            this.显示隐藏格网ToolStripMenuItem.CheckOnClick = true;
            this.显示隐藏格网ToolStripMenuItem.Name = "显示隐藏格网ToolStripMenuItem";
            this.显示隐藏格网ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.显示隐藏格网ToolStripMenuItem.Text = "显示/隐藏格网";
            this.显示隐藏格网ToolStripMenuItem.Click += new System.EventHandler(this.显示隐藏格网ToolStripMenuItem_Click);
            // 
            // 清除格网ToolStripMenuItem
            // 
            this.清除格网ToolStripMenuItem.Name = "清除格网ToolStripMenuItem";
            this.清除格网ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.清除格网ToolStripMenuItem.Text = "清除格网";
            this.清除格网ToolStripMenuItem.Click += new System.EventHandler(this.清除格网ToolStripMenuItem_Click);
            // 
            // TIN模型ToolStripMenuItem
            // 
            this.TIN模型ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.逐点插入法ToolStripMenuItem,
            this.toolStripSeparator4,
            this.生成等值线ToolStripMenuItem1,
            this.toolStripSeparator5,
            this.设置ToolStripMenuItem1});
            this.TIN模型ToolStripMenuItem.Name = "TIN模型ToolStripMenuItem";
            this.TIN模型ToolStripMenuItem.Size = new System.Drawing.Size(65, 21);
            this.TIN模型ToolStripMenuItem.Text = "TIN模型";
            // 
            // 逐点插入法ToolStripMenuItem
            // 
            this.逐点插入法ToolStripMenuItem.CheckOnClick = true;
            this.逐点插入法ToolStripMenuItem.Name = "逐点插入法ToolStripMenuItem";
            this.逐点插入法ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.逐点插入法ToolStripMenuItem.Text = "逐点插入法";
            this.逐点插入法ToolStripMenuItem.Click += new System.EventHandler(this.逐点插入法ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(133, 6);
            // 
            // 生成等值线ToolStripMenuItem1
            // 
            this.生成等值线ToolStripMenuItem1.CheckOnClick = true;
            this.生成等值线ToolStripMenuItem1.Name = "生成等值线ToolStripMenuItem1";
            this.生成等值线ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.生成等值线ToolStripMenuItem1.Text = "生成等值线";
            this.生成等值线ToolStripMenuItem1.CheckedChanged += new System.EventHandler(this.生成等值线ToolStripMenuItem1_CheckedChanged);
            this.生成等值线ToolStripMenuItem1.Click += new System.EventHandler(this.生成等值线ToolStripMenuItem1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(133, 6);
            // 
            // 设置ToolStripMenuItem1
            // 
            this.设置ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示隐藏TINToolStripMenuItem,
            this.清楚TINToolStripMenuItem});
            this.设置ToolStripMenuItem1.Name = "设置ToolStripMenuItem1";
            this.设置ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.设置ToolStripMenuItem1.Text = "设置";
            this.设置ToolStripMenuItem1.Click += new System.EventHandler(this.设置ToolStripMenuItem1_Click);
            // 
            // 显示隐藏TINToolStripMenuItem
            // 
            this.显示隐藏TINToolStripMenuItem.CheckOnClick = true;
            this.显示隐藏TINToolStripMenuItem.Name = "显示隐藏TINToolStripMenuItem";
            this.显示隐藏TINToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.显示隐藏TINToolStripMenuItem.Text = "显示/隐藏TIN";
            this.显示隐藏TINToolStripMenuItem.Click += new System.EventHandler(this.显示隐藏TINToolStripMenuItem_Click);
            // 
            // 清楚TINToolStripMenuItem
            // 
            this.清楚TINToolStripMenuItem.Name = "清楚TINToolStripMenuItem";
            this.清楚TINToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.清楚TINToolStripMenuItem.Text = "清除TIN";
            this.清楚TINToolStripMenuItem.Click += new System.EventHandler(this.清楚TINToolStripMenuItem_Click);
            // 
            // 拓扑关系ToolStripMenuItem
            // 
            this.拓扑关系ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生成拓扑关系ToolStripMenuItem,
            this.可视化ToolStripMenuItem,
            this.查询ToolStripMenuItem,
            this.导出拓扑关系表ToolStripMenuItem});
            this.拓扑关系ToolStripMenuItem.Name = "拓扑关系ToolStripMenuItem";
            this.拓扑关系ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.拓扑关系ToolStripMenuItem.Text = "拓扑关系";
            // 
            // 生成拓扑关系ToolStripMenuItem
            // 
            this.生成拓扑关系ToolStripMenuItem.Name = "生成拓扑关系ToolStripMenuItem";
            this.生成拓扑关系ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.生成拓扑关系ToolStripMenuItem.Text = "生成拓扑关系";
            this.生成拓扑关系ToolStripMenuItem.Click += new System.EventHandler(this.生成拓扑关系ToolStripMenuItem_Click);
            // 
            // 可视化ToolStripMenuItem
            // 
            this.可视化ToolStripMenuItem.CheckOnClick = true;
            this.可视化ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.拓扑点ToolStripMenuItem,
            this.拓扑边ToolStripMenuItem,
            this.拓扑多边形ToolStripMenuItem});
            this.可视化ToolStripMenuItem.Name = "可视化ToolStripMenuItem";
            this.可视化ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.可视化ToolStripMenuItem.Text = "可视化";
            this.可视化ToolStripMenuItem.Click += new System.EventHandler(this.可视化ToolStripMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.查询ToolStripMenuItem.Text = "查询";
            this.查询ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.查询ToolStripMenuItem_CheckedChanged);
            this.查询ToolStripMenuItem.Click += new System.EventHandler(this.查询ToolStripMenuItem_Click);
            // 
            // 导出拓扑关系表ToolStripMenuItem
            // 
            this.导出拓扑关系表ToolStripMenuItem.Name = "导出拓扑关系表ToolStripMenuItem";
            this.导出拓扑关系表ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.导出拓扑关系表ToolStripMenuItem.Text = "导出拓扑关系表";
            this.导出拓扑关系表ToolStripMenuItem.Click += new System.EventHandler(this.导出拓扑关系表ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.作者信息ToolStripMenuItem,
            this.程序信息ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 作者信息ToolStripMenuItem
            // 
            this.作者信息ToolStripMenuItem.Name = "作者信息ToolStripMenuItem";
            this.作者信息ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.作者信息ToolStripMenuItem.Text = "作者信息";
            this.作者信息ToolStripMenuItem.Click += new System.EventHandler(this.作者信息ToolStripMenuItem_Click);
            // 
            // 程序信息ToolStripMenuItem
            // 
            this.程序信息ToolStripMenuItem.Name = "程序信息ToolStripMenuItem";
            this.程序信息ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.程序信息ToolStripMenuItem.Text = "程序信息";
            this.程序信息ToolStripMenuItem.Click += new System.EventHandler(this.程序信息ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_X,
            this.StatusLabel_X,
            this.toolStripStatusLabel_Y,
            this.StatusLabel_Y,
            this.toolStripStatusLabelScreenX,
            this.StatusLabelScreenX,
            this.toolStripStatusLabelScreenY,
            this.StatusLabelScreenY});
            this.statusStrip1.Location = new System.Drawing.Point(0, 712);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(995, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_X
            // 
            this.toolStripStatusLabel_X.Name = "toolStripStatusLabel_X";
            this.toolStripStatusLabel_X.Size = new System.Drawing.Size(19, 17);
            this.toolStripStatusLabel_X.Text = "X:";
            // 
            // StatusLabel_X
            // 
            this.StatusLabel_X.Name = "StatusLabel_X";
            this.StatusLabel_X.Size = new System.Drawing.Size(25, 17);
            this.StatusLabel_X.Text = "0.0";
            // 
            // toolStripStatusLabel_Y
            // 
            this.toolStripStatusLabel_Y.Name = "toolStripStatusLabel_Y";
            this.toolStripStatusLabel_Y.Size = new System.Drawing.Size(18, 17);
            this.toolStripStatusLabel_Y.Text = "Y:";
            // 
            // StatusLabel_Y
            // 
            this.StatusLabel_Y.Name = "StatusLabel_Y";
            this.StatusLabel_Y.Size = new System.Drawing.Size(25, 17);
            this.StatusLabel_Y.Text = "0.0";
            // 
            // toolStripStatusLabelScreenX
            // 
            this.toolStripStatusLabelScreenX.Name = "toolStripStatusLabelScreenX";
            this.toolStripStatusLabelScreenX.Size = new System.Drawing.Size(58, 17);
            this.toolStripStatusLabelScreenX.Text = "ScreenX:";
            // 
            // StatusLabelScreenX
            // 
            this.StatusLabelScreenX.Name = "StatusLabelScreenX";
            this.StatusLabelScreenX.Size = new System.Drawing.Size(25, 17);
            this.StatusLabelScreenX.Text = "0.0";
            // 
            // toolStripStatusLabelScreenY
            // 
            this.toolStripStatusLabelScreenY.Name = "toolStripStatusLabelScreenY";
            this.toolStripStatusLabelScreenY.Size = new System.Drawing.Size(57, 17);
            this.toolStripStatusLabelScreenY.Text = "ScreenY:";
            // 
            // StatusLabelScreenY
            // 
            this.StatusLabelScreenY.Name = "StatusLabelScreenY";
            this.StatusLabelScreenY.Size = new System.Drawing.Size(25, 17);
            this.StatusLabelScreenY.Text = "0.0";
            // 
            // 拓扑点ToolStripMenuItem
            // 
            this.拓扑点ToolStripMenuItem.Name = "拓扑点ToolStripMenuItem";
            this.拓扑点ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.拓扑点ToolStripMenuItem.Text = "拓扑点";
            this.拓扑点ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.拓扑点ToolStripMenuItem_CheckedChanged);
            this.拓扑点ToolStripMenuItem.Click += new System.EventHandler(this.拓扑点ToolStripMenuItem_Click);
            // 
            // 拓扑边ToolStripMenuItem
            // 
            this.拓扑边ToolStripMenuItem.Name = "拓扑边ToolStripMenuItem";
            this.拓扑边ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.拓扑边ToolStripMenuItem.Text = "拓扑边";
            this.拓扑边ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.拓扑边ToolStripMenuItem_CheckedChanged);
            this.拓扑边ToolStripMenuItem.Click += new System.EventHandler(this.拓扑边ToolStripMenuItem_Click);
            // 
            // 拓扑多边形ToolStripMenuItem
            // 
            this.拓扑多边形ToolStripMenuItem.Name = "拓扑多边形ToolStripMenuItem";
            this.拓扑多边形ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.拓扑多边形ToolStripMenuItem.Text = "拓扑多边形";
            this.拓扑多边形ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.拓扑多边形ToolStripMenuItem_CheckedChanged);
            this.拓扑多边形ToolStripMenuItem.Click += new System.EventHandler(this.拓扑多边形ToolStripMenuItem_Click);
            // 
            // agisControl
            // 
            this.agisControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.agisControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.agisControl.Location = new System.Drawing.Point(0, 25);
            this.agisControl.Name = "agisControl";
            this.agisControl.Size = new System.Drawing.Size(995, 684);
            this.agisControl.TabIndex = 1;
            this.agisControl.Load += new System.EventHandler(this.agisControl_Load);
            this.agisControl.Paint += new System.Windows.Forms.PaintEventHandler(this.agisControl_Paint);
            this.agisControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.agisControl_MouseClick);
            this.agisControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.agisControl_MouseDoubleClick);
            this.agisControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.agisControl_MouseDown);
            this.agisControl.MouseHover += new System.EventHandler(this.agisControl_MouseHover);
            this.agisControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.agisControl_MouseMove);
            // 
            // 平滑ToolStripMenuItem
            // 
            this.平滑ToolStripMenuItem.CheckOnClick = true;
            this.平滑ToolStripMenuItem.Name = "平滑ToolStripMenuItem";
            this.平滑ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.平滑ToolStripMenuItem.Text = "平滑";
            this.平滑ToolStripMenuItem.Click += new System.EventHandler(this.平滑ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 734);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.agisControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "高级GIS 课程作业";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 格网模型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TIN模型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拓扑关系ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 距离平方倒数法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按方位加权平均法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 加密网格toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询节点属性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 生成等值线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示隐藏格网ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除格网ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 逐点插入法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 生成等值线ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 显示隐藏TINToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清楚TINToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成拓扑关系ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 可视化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出拓扑关系表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 作者信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 程序信息ToolStripMenuItem;
        private AgisControl agisControl;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_X;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_X;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Y;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_Y;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelScreenX;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelScreenX;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelScreenY;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelScreenY;
        private System.Windows.Forms.ToolStripMenuItem 生成格网ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拓扑点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拓扑边ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拓扑多边形ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 平滑ToolStripMenuItem;
    }
}

