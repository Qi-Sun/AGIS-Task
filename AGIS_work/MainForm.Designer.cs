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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            AGIS_work.DataStructure.MinBoundRect minBoundRect1 = new AGIS_work.DataStructure.MinBoundRect();
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
            this.agisControl = new AGIS_work.AgisControl();
            this.menuStrip1.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(762, 25);
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
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            // 
            // 另存为ToolStripMenuItem
            // 
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
            // 
            // 按方位加权平均法ToolStripMenuItem
            // 
            this.按方位加权平均法ToolStripMenuItem.Name = "按方位加权平均法ToolStripMenuItem";
            this.按方位加权平均法ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.按方位加权平均法ToolStripMenuItem.Text = "按方位加权平均法";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // 加密网格toolStripMenuItem
            // 
            this.加密网格toolStripMenuItem.Name = "加密网格toolStripMenuItem";
            this.加密网格toolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.加密网格toolStripMenuItem.Text = "加密网格";
            // 
            // 查询节点属性ToolStripMenuItem
            // 
            this.查询节点属性ToolStripMenuItem.Name = "查询节点属性ToolStripMenuItem";
            this.查询节点属性ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.查询节点属性ToolStripMenuItem.Text = "查询节点属性";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // 生成等值线ToolStripMenuItem
            // 
            this.生成等值线ToolStripMenuItem.Name = "生成等值线ToolStripMenuItem";
            this.生成等值线ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.生成等值线ToolStripMenuItem.Text = "生成等值线";
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
            // 
            // 显示隐藏格网ToolStripMenuItem
            // 
            this.显示隐藏格网ToolStripMenuItem.Name = "显示隐藏格网ToolStripMenuItem";
            this.显示隐藏格网ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.显示隐藏格网ToolStripMenuItem.Text = "显示/隐藏格网";
            // 
            // 清除格网ToolStripMenuItem
            // 
            this.清除格网ToolStripMenuItem.Name = "清除格网ToolStripMenuItem";
            this.清除格网ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.清除格网ToolStripMenuItem.Text = "清除格网";
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
            this.逐点插入法ToolStripMenuItem.Name = "逐点插入法ToolStripMenuItem";
            this.逐点插入法ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.逐点插入法ToolStripMenuItem.Text = "逐点插入法";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(133, 6);
            // 
            // 生成等值线ToolStripMenuItem1
            // 
            this.生成等值线ToolStripMenuItem1.Name = "生成等值线ToolStripMenuItem1";
            this.生成等值线ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.生成等值线ToolStripMenuItem1.Text = "生成等值线";
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
            // 
            // 显示隐藏TINToolStripMenuItem
            // 
            this.显示隐藏TINToolStripMenuItem.Name = "显示隐藏TINToolStripMenuItem";
            this.显示隐藏TINToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.显示隐藏TINToolStripMenuItem.Text = "显示/隐藏TIN";
            // 
            // 清楚TINToolStripMenuItem
            // 
            this.清楚TINToolStripMenuItem.Name = "清楚TINToolStripMenuItem";
            this.清楚TINToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.清楚TINToolStripMenuItem.Text = "清楚TIN";
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
            // 
            // 可视化ToolStripMenuItem
            // 
            this.可视化ToolStripMenuItem.Name = "可视化ToolStripMenuItem";
            this.可视化ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.可视化ToolStripMenuItem.Text = "可视化";
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.查询ToolStripMenuItem.Text = "查询";
            // 
            // 导出拓扑关系表ToolStripMenuItem
            // 
            this.导出拓扑关系表ToolStripMenuItem.Name = "导出拓扑关系表ToolStripMenuItem";
            this.导出拓扑关系表ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.导出拓扑关系表ToolStripMenuItem.Text = "导出拓扑关系表";
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
            // 
            // 程序信息ToolStripMenuItem
            // 
            this.程序信息ToolStripMenuItem.Name = "程序信息ToolStripMenuItem";
            this.程序信息ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.程序信息ToolStripMenuItem.Text = "程序信息";
            // 
            // agisControl
            // 
            this.agisControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.agisControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.agisControl.CenterPoint = ((System.Drawing.PointF)(resources.GetObject("agisControl.CenterPoint")));
            this.agisControl.Location = new System.Drawing.Point(0, 25);
            this.agisControl.MBR = minBoundRect1;
            this.agisControl.Name = "agisControl";
            this.agisControl.Scale = 1D;
            this.agisControl.Size = new System.Drawing.Size(762, 487);
            this.agisControl.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 512);
            this.Controls.Add(this.agisControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "高级GIS 课程作业";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}

