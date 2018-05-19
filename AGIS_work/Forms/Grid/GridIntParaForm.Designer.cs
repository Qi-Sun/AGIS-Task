namespace AGIS_work.Forms.Grid
{
    partial class GridIntParaForm
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
            this.label_Pare = new System.Windows.Forms.Label();
            this.numericUpDown_Para = new System.Windows.Forms.NumericUpDown();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Para)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Pare
            // 
            this.label_Pare.AutoSize = true;
            this.label_Pare.Location = new System.Drawing.Point(40, 39);
            this.label_Pare.Name = "label_Pare";
            this.label_Pare.Size = new System.Drawing.Size(41, 12);
            this.label_Pare.TabIndex = 0;
            this.label_Pare.Text = "label1";
            // 
            // numericUpDown_Para
            // 
            this.numericUpDown_Para.Location = new System.Drawing.Point(179, 37);
            this.numericUpDown_Para.Name = "numericUpDown_Para";
            this.numericUpDown_Para.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown_Para.TabIndex = 1;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(195, 78);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 2;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(291, 78);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 3;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // GridIntParaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 119);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.numericUpDown_Para);
            this.Controls.Add(this.label_Pare);
            this.Name = "GridIntParaForm";
            this.Text = "GridIntParaForm";
            this.Load += new System.EventHandler(this.GridIntParaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Para)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Pare;
        private System.Windows.Forms.NumericUpDown numericUpDown_Para;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
    }
}