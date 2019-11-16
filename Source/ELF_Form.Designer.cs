namespace MCUCapture
{
    partial class ELF_Form
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
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkMarkFlash = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblSelectedSize = new System.Windows.Forms.Label();
            this.lblSelectedAddress = new System.Windows.Forms.Label();
            this.lblSelectedName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(12, 12);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 28);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(8, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(348, 354);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Address";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Size";
            this.Column3.Name = "Column3";
            // 
            // chkMarkFlash
            // 
            this.chkMarkFlash.AutoSize = true;
            this.chkMarkFlash.Checked = true;
            this.chkMarkFlash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMarkFlash.Location = new System.Drawing.Point(371, 46);
            this.chkMarkFlash.Name = "chkMarkFlash";
            this.chkMarkFlash.Size = new System.Drawing.Size(120, 17);
            this.chkMarkFlash.TabIndex = 2;
            this.chkMarkFlash.Text = "Mark Cortex-M flash";
            this.chkMarkFlash.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.lblSelectedSize);
            this.groupBox1.Controls.Add(this.lblSelectedAddress);
            this.groupBox1.Controls.Add(this.lblSelectedName);
            this.groupBox1.Location = new System.Drawing.Point(362, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 137);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Item";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(9, 102);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(90, 25);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblSelectedSize
            // 
            this.lblSelectedSize.AutoSize = true;
            this.lblSelectedSize.Location = new System.Drawing.Point(9, 75);
            this.lblSelectedSize.Name = "lblSelectedSize";
            this.lblSelectedSize.Size = new System.Drawing.Size(53, 13);
            this.lblSelectedSize.TabIndex = 2;
            this.lblSelectedSize.Text = "Size: N/A";
            // 
            // lblSelectedAddress
            // 
            this.lblSelectedAddress.AutoSize = true;
            this.lblSelectedAddress.Location = new System.Drawing.Point(9, 46);
            this.lblSelectedAddress.Name = "lblSelectedAddress";
            this.lblSelectedAddress.Size = new System.Drawing.Size(71, 13);
            this.lblSelectedAddress.TabIndex = 1;
            this.lblSelectedAddress.Text = "Address: N/A";
            // 
            // lblSelectedName
            // 
            this.lblSelectedName.AutoSize = true;
            this.lblSelectedName.Location = new System.Drawing.Point(9, 21);
            this.lblSelectedName.Name = "lblSelectedName";
            this.lblSelectedName.Size = new System.Drawing.Size(61, 13);
            this.lblSelectedName.TabIndex = 0;
            this.lblSelectedName.Text = "Name: N/A";
            // 
            // ELF_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 412);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkMarkFlash);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnOpenFile);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ELF_Form";
            this.Text = "Data Source Selection";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.CheckBox chkMarkFlash;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSelectedSize;
        private System.Windows.Forms.Label lblSelectedAddress;
        private System.Windows.Forms.Label lblSelectedName;
        private System.Windows.Forms.Button btnSelect;
    }
}