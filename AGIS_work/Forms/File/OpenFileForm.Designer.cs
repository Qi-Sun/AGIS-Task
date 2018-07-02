namespace AGIS_work.Forms.File
{
    partial class OpenFileForm
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
            this.txtBxFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bttnSelectFile = new System.Windows.Forms.Button();
            this.bttnOK = new System.Windows.Forms.Button();
            this.bttnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBxFilename
            // 
            this.txtBxFilename.Location = new System.Drawing.Point(71, 23);
            this.txtBxFilename.Name = "txtBxFilename";
            this.txtBxFilename.Size = new System.Drawing.Size(346, 21);
            this.txtBxFilename.TabIndex = 3;
            this.txtBxFilename.Text = "../../Data/TestData.csv";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "FileName";
            // 
            // bttnSelectFile
            // 
            this.bttnSelectFile.Location = new System.Drawing.Point(423, 21);
            this.bttnSelectFile.Name = "bttnSelectFile";
            this.bttnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.bttnSelectFile.TabIndex = 2;
            this.bttnSelectFile.Text = "Select";
            this.bttnSelectFile.UseVisualStyleBackColor = true;
            this.bttnSelectFile.Click += new System.EventHandler(this.bttnSelectFile_Click);
            // 
            // bttnOK
            // 
            this.bttnOK.Location = new System.Drawing.Point(342, 58);
            this.bttnOK.Name = "bttnOK";
            this.bttnOK.Size = new System.Drawing.Size(75, 23);
            this.bttnOK.TabIndex = 0;
            this.bttnOK.Text = "OK";
            this.bttnOK.UseVisualStyleBackColor = true;
            this.bttnOK.Click += new System.EventHandler(this.bttnOK_Click);
            // 
            // bttnCancel
            // 
            this.bttnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttnCancel.Location = new System.Drawing.Point(442, 58);
            this.bttnCancel.Name = "bttnCancel";
            this.bttnCancel.Size = new System.Drawing.Size(75, 23);
            this.bttnCancel.TabIndex = 4;
            this.bttnCancel.Text = "Cancel";
            this.bttnCancel.UseVisualStyleBackColor = true;
            this.bttnCancel.Click += new System.EventHandler(this.bttnCancel_Click);
            // 
            // OpenFileForm
            // 
            this.AcceptButton = this.bttnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bttnCancel;
            this.ClientSize = new System.Drawing.Size(540, 93);
            this.Controls.Add(this.bttnCancel);
            this.Controls.Add(this.bttnOK);
            this.Controls.Add(this.bttnSelectFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBxFilename);
            this.Name = "OpenFileForm";
            this.Text = "OpenFileForm";
            this.Load += new System.EventHandler(this.OpenFileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBxFilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttnSelectFile;
        private System.Windows.Forms.Button bttnOK;
        private System.Windows.Forms.Button bttnCancel;
    }
}