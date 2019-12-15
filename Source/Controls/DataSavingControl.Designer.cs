namespace MCUCapture
{
    partial class DataSavingControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblSelectedFileName = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblSaveCounter = new System.Windows.Forms.Label();
            this.chkAddTime = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblSelectedFileName
            // 
            this.lblSelectedFileName.AutoSize = true;
            this.lblSelectedFileName.Location = new System.Drawing.Point(12, 14);
            this.lblSelectedFileName.Name = "lblSelectedFileName";
            this.lblSelectedFileName.Size = new System.Drawing.Size(120, 13);
            this.lblSelectedFileName.TabIndex = 0;
            this.lblSelectedFileName.Text = "Selected Filename: N/A";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(15, 34);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(78, 27);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "Select  File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblSaveCounter
            // 
            this.lblSaveCounter.AutoSize = true;
            this.lblSaveCounter.Location = new System.Drawing.Point(12, 75);
            this.lblSaveCounter.Name = "lblSaveCounter";
            this.lblSaveCounter.Size = new System.Drawing.Size(98, 13);
            this.lblSaveCounter.TabIndex = 2;
            this.lblSaveCounter.Text = "Save Counter: N/A";
            // 
            // chkAddTime
            // 
            this.chkAddTime.AutoSize = true;
            this.chkAddTime.Checked = true;
            this.chkAddTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddTime.Location = new System.Drawing.Point(15, 97);
            this.chkAddTime.Name = "chkAddTime";
            this.chkAddTime.Size = new System.Drawing.Size(175, 17);
            this.chkAddTime.TabIndex = 3;
            this.chkAddTime.Text = "Add Date and Time to Filename";
            this.chkAddTime.UseVisualStyleBackColor = true;
            // 
            // DataSavingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkAddTime);
            this.Controls.Add(this.lblSaveCounter);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.lblSelectedFileName);
            this.Name = "DataSavingControl";
            this.Size = new System.Drawing.Size(503, 200);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectedFileName;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblSaveCounter;
        private System.Windows.Forms.CheckBox chkAddTime;
    }
}
