namespace MCUCapture
{
    partial class FormOpenOCD_Selector
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
            this.dataGridViewPaths = new System.Windows.Forms.DataGridView();
            this.radioButtonPath = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletePathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAddPath = new System.Windows.Forms.Button();
            this.dataGridViewCommands = new System.Windows.Forms.DataGridView();
            this.radioButtonCommand = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.commandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteCommandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtNewCommand = new System.Windows.Forms.TextBox();
            this.btnAddCommand = new System.Windows.Forms.Button();
            this.btnRunOpenOCD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPaths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCommands)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPaths
            // 
            this.dataGridViewPaths.AllowUserToAddRows = false;
            this.dataGridViewPaths.AllowUserToDeleteRows = false;
            this.dataGridViewPaths.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPaths.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.radioButtonPath,
            this.pathDataGridViewTextBoxColumn,
            this.deletePathDataGridViewTextBoxColumn});
            this.dataGridViewPaths.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewPaths.Name = "dataGridViewPaths";
            this.dataGridViewPaths.RowHeadersVisible = false;
            this.dataGridViewPaths.Size = new System.Drawing.Size(600, 150);
            this.dataGridViewPaths.TabIndex = 0;
            this.dataGridViewPaths.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPaths_CellClick);
            // 
            // radioButtonPath
            // 
            this.radioButtonPath.HeaderText = "Select";
            this.radioButtonPath.Name = "radioButtonPath";
            this.radioButtonPath.Width = 50;
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pathDataGridViewTextBoxColumn.HeaderText = "OpenOCD Path";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            // 
            // deletePathDataGridViewTextBoxColumn
            // 
            this.deletePathDataGridViewTextBoxColumn.HeaderText = "Delete";
            this.deletePathDataGridViewTextBoxColumn.Name = "deletePathDataGridViewTextBoxColumn";
            this.deletePathDataGridViewTextBoxColumn.Text = "Delete";
            this.deletePathDataGridViewTextBoxColumn.Width = 60;
            // 
            // btnAddPath
            // 
            this.btnAddPath.Location = new System.Drawing.Point(630, 12);
            this.btnAddPath.Name = "btnAddPath";
            this.btnAddPath.Size = new System.Drawing.Size(75, 23);
            this.btnAddPath.TabIndex = 1;
            this.btnAddPath.Text = "Add Path";
            this.btnAddPath.UseVisualStyleBackColor = true;
            this.btnAddPath.Click += new System.EventHandler(this.btnAddPath_Click);
            // 
            // dataGridViewCommands
            // 
            this.dataGridViewCommands.AllowUserToAddRows = false;
            this.dataGridViewCommands.AllowUserToDeleteRows = false;
            this.dataGridViewCommands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCommands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.radioButtonCommand,
            this.commandDataGridViewTextBoxColumn,
            this.deleteCommandDataGridViewTextBoxColumn});
            this.dataGridViewCommands.Location = new System.Drawing.Point(12, 180);
            this.dataGridViewCommands.Name = "dataGridViewCommands";
            this.dataGridViewCommands.RowHeadersVisible = false;
            this.dataGridViewCommands.Size = new System.Drawing.Size(600, 150);
            this.dataGridViewCommands.TabIndex = 2;
            this.dataGridViewCommands.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCommands_CellClick);
            // 
            // radioButtonCommand
            // 
            this.radioButtonCommand.HeaderText = "Select";
            this.radioButtonCommand.Name = "radioButtonCommand";
            this.radioButtonCommand.Width = 50;
            // 
            // commandDataGridViewTextBoxColumn
            // 
            this.commandDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.commandDataGridViewTextBoxColumn.HeaderText = "Command";
            this.commandDataGridViewTextBoxColumn.Name = "commandDataGridViewTextBoxColumn";
            // 
            // deleteCommandDataGridViewTextBoxColumn
            // 
            this.deleteCommandDataGridViewTextBoxColumn.HeaderText = "Delete";
            this.deleteCommandDataGridViewTextBoxColumn.Name = "deleteCommandDataGridViewTextBoxColumn";
            this.deleteCommandDataGridViewTextBoxColumn.Text = "Delete";
            this.deleteCommandDataGridViewTextBoxColumn.Width = 60;
            // 
            // txtNewCommand
            // 
            this.txtNewCommand.Location = new System.Drawing.Point(12, 340);
            this.txtNewCommand.Name = "txtNewCommand";
            this.txtNewCommand.Size = new System.Drawing.Size(500, 20);
            this.txtNewCommand.TabIndex = 3;
            // 
            // btnAddCommand
            // 
            this.btnAddCommand.Location = new System.Drawing.Point(520, 340);
            this.btnAddCommand.Name = "btnAddCommand";
            this.btnAddCommand.Size = new System.Drawing.Size(92, 23);
            this.btnAddCommand.TabIndex = 4;
            this.btnAddCommand.Text = "Add Command";
            this.btnAddCommand.UseVisualStyleBackColor = true;
            this.btnAddCommand.Click += new System.EventHandler(this.btnAddCommand_Click);
            // 
            // btnRunOpenOCD
            // 
            this.btnRunOpenOCD.BackColor = System.Drawing.Color.Yellow;
            this.btnRunOpenOCD.Location = new System.Drawing.Point(12, 380);
            this.btnRunOpenOCD.Name = "btnRunOpenOCD";
            this.btnRunOpenOCD.Size = new System.Drawing.Size(100, 30);
            this.btnRunOpenOCD.TabIndex = 5;
            this.btnRunOpenOCD.Text = "Run OpenOCD";
            this.btnRunOpenOCD.UseVisualStyleBackColor = false;
            this.btnRunOpenOCD.Click += new System.EventHandler(this.btnRunOpenOCD_Click);
            // 
            // FormOpenOCD_Selector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 421);
            this.Controls.Add(this.btnRunOpenOCD);
            this.Controls.Add(this.btnAddCommand);
            this.Controls.Add(this.txtNewCommand);
            this.Controls.Add(this.dataGridViewCommands);
            this.Controls.Add(this.btnAddPath);
            this.Controls.Add(this.dataGridViewPaths);
            this.Name = "FormOpenOCD_Selector";
            this.Text = "OpenOCD Selector";
            this.Load += new System.EventHandler(this.FormOpenOCD_Selector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPaths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCommands)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPaths;
        private System.Windows.Forms.DataGridViewCheckBoxColumn radioButtonPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn deletePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnAddPath;
        private System.Windows.Forms.DataGridView dataGridViewCommands;
        private System.Windows.Forms.DataGridViewCheckBoxColumn radioButtonCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn commandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn deleteCommandDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtNewCommand;
        private System.Windows.Forms.Button btnAddCommand;
        private System.Windows.Forms.Button btnRunOpenOCD;
    }
}