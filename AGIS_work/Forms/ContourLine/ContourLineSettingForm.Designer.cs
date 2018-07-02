namespace AGIS_work.Forms.ContourLine
{
    partial class ContourLineSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numUD_EleMin = new System.Windows.Forms.NumericUpDown();
            this.numUD_EleMax = new System.Windows.Forms.NumericUpDown();
            this.numUD_EleInt = new System.Windows.Forms.NumericUpDown();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_EleMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_EleMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_EleInt)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "等高线最小值";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "等高线最大值";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "等高线间隔";
            // 
            // numUD_EleMin
            // 
            this.numUD_EleMin.Location = new System.Drawing.Point(138, 38);
            this.numUD_EleMin.Minimum = new decimal(new int[] {
            480,
            0,
            0,
            -2147483648});
            this.numUD_EleMin.Name = "numUD_EleMin";
            this.numUD_EleMin.Size = new System.Drawing.Size(120, 21);
            this.numUD_EleMin.TabIndex = 3;
            this.numUD_EleMin.Value = new decimal(new int[] {
            480,
            0,
            0,
            -2147483648});
            // 
            // numUD_EleMax
            // 
            this.numUD_EleMax.Location = new System.Drawing.Point(138, 85);
            this.numUD_EleMax.Minimum = new decimal(new int[] {
            480,
            0,
            0,
            -2147483648});
            this.numUD_EleMax.Name = "numUD_EleMax";
            this.numUD_EleMax.Size = new System.Drawing.Size(120, 21);
            this.numUD_EleMax.TabIndex = 4;
            // 
            // numUD_EleInt
            // 
            this.numUD_EleInt.Location = new System.Drawing.Point(137, 127);
            this.numUD_EleInt.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numUD_EleInt.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUD_EleInt.Name = "numUD_EleInt";
            this.numUD_EleInt.Size = new System.Drawing.Size(120, 21);
            this.numUD_EleInt.TabIndex = 5;
            this.numUD_EleInt.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(137, 185);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(239, 185);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ContourLineSettingForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(343, 239);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.numUD_EleInt);
            this.Controls.Add(this.numUD_EleMax);
            this.Controls.Add(this.numUD_EleMin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ContourLineSettingForm";
            this.Text = "ContourLineSettingForm";
            ((System.ComponentModel.ISupportInitialize)(this.numUD_EleMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_EleMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_EleInt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numUD_EleMin;
        private System.Windows.Forms.NumericUpDown numUD_EleMax;
        private System.Windows.Forms.NumericUpDown numUD_EleInt;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}