namespace MCUCapture
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblConnectionSate = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDataReceivedCnt = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerUpdateGUI = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCleanWatchpoints = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnResumeMCU = new System.Windows.Forms.Button();
            this.btnWaitEndWatchpoint = new System.Windows.Forms.Button();
            this.chkIsBigEndian = new System.Windows.Forms.CheckBox();
            this.btnManualRead = new System.Windows.Forms.Button();
            this.txtBoxDataSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxDataStartAddr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPagePlot = new System.Windows.Forms.TabPage();
            this.plotControl1 = new MCUCapture.PlotControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblLinesReceived = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPagePlot.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConnectionSate,
            this.lblDataReceivedCnt,
            this.lblLinesReceived});
            this.statusStrip1.Location = new System.Drawing.Point(0, 504);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(897, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblConnectionSate
            // 
            this.lblConnectionSate.Name = "lblConnectionSate";
            this.lblConnectionSate.Size = new System.Drawing.Size(97, 17);
            this.lblConnectionSate.Text = "Connection: N/A";
            // 
            // lblDataReceivedCnt
            // 
            this.lblDataReceivedCnt.Name = "lblDataReceivedCnt";
            this.lblDataReceivedCnt.Size = new System.Drawing.Size(115, 17);
            this.lblDataReceivedCnt.Text = "Data Received Cnt: 0";
            // 
            // timerUpdateGUI
            // 
            this.timerUpdateGUI.Tick += new System.EventHandler(this.timerUpdateGUI_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnCleanWatchpoints);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnResumeMCU);
            this.groupBox1.Controls.Add(this.btnWaitEndWatchpoint);
            this.groupBox1.Controls.Add(this.chkIsBigEndian);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnManualRead);
            this.groupBox1.Controls.Add(this.txtBoxDataSize);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBoxDataStartAddr);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(104, 492);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Source";
            // 
            // btnCleanWatchpoints
            // 
            this.btnCleanWatchpoints.Location = new System.Drawing.Point(10, 422);
            this.btnCleanWatchpoints.Margin = new System.Windows.Forms.Padding(2);
            this.btnCleanWatchpoints.Name = "btnCleanWatchpoints";
            this.btnCleanWatchpoints.Size = new System.Drawing.Size(87, 28);
            this.btnCleanWatchpoints.TabIndex = 9;
            this.btnCleanWatchpoints.Text = "Clean WP";
            this.btnCleanWatchpoints.UseVisualStyleBackColor = true;
            this.btnCleanWatchpoints.Click += new System.EventHandler(this.btnCleanWatchpoints_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 302);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 24);
            this.button2.TabIndex = 8;
            this.button2.Text = "test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnResumeMCU
            // 
            this.btnResumeMCU.Location = new System.Drawing.Point(10, 458);
            this.btnResumeMCU.Margin = new System.Windows.Forms.Padding(2);
            this.btnResumeMCU.Name = "btnResumeMCU";
            this.btnResumeMCU.Size = new System.Drawing.Size(87, 28);
            this.btnResumeMCU.TabIndex = 7;
            this.btnResumeMCU.Text = "Resume MCU";
            this.btnResumeMCU.UseVisualStyleBackColor = true;
            this.btnResumeMCU.Click += new System.EventHandler(this.btnResumeMCU_Click);
            // 
            // btnWaitEndWatchpoint
            // 
            this.btnWaitEndWatchpoint.Location = new System.Drawing.Point(7, 182);
            this.btnWaitEndWatchpoint.Margin = new System.Windows.Forms.Padding(2);
            this.btnWaitEndWatchpoint.Name = "btnWaitEndWatchpoint";
            this.btnWaitEndWatchpoint.Size = new System.Drawing.Size(87, 28);
            this.btnWaitEndWatchpoint.TabIndex = 6;
            this.btnWaitEndWatchpoint.Text = "Wait End WP";
            this.btnWaitEndWatchpoint.UseVisualStyleBackColor = true;
            this.btnWaitEndWatchpoint.Click += new System.EventHandler(this.btnWaitEndWatchpoint_Click);
            // 
            // chkIsBigEndian
            // 
            this.chkIsBigEndian.AutoSize = true;
            this.chkIsBigEndian.Location = new System.Drawing.Point(10, 120);
            this.chkIsBigEndian.Name = "chkIsBigEndian";
            this.chkIsBigEndian.Size = new System.Drawing.Size(77, 17);
            this.chkIsBigEndian.TabIndex = 5;
            this.chkIsBigEndian.Text = "Big Endian";
            this.chkIsBigEndian.UseVisualStyleBackColor = true;
            // 
            // btnManualRead
            // 
            this.btnManualRead.Location = new System.Drawing.Point(7, 143);
            this.btnManualRead.Margin = new System.Windows.Forms.Padding(2);
            this.btnManualRead.Name = "btnManualRead";
            this.btnManualRead.Size = new System.Drawing.Size(87, 28);
            this.btnManualRead.TabIndex = 4;
            this.btnManualRead.Text = "Manual Read";
            this.btnManualRead.UseVisualStyleBackColor = true;
            this.btnManualRead.Click += new System.EventHandler(this.btnManualRead_Click);
            // 
            // txtBoxDataSize
            // 
            this.txtBoxDataSize.Location = new System.Drawing.Point(7, 91);
            this.txtBoxDataSize.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxDataSize.Name = "txtBoxDataSize";
            this.txtBoxDataSize.Size = new System.Drawing.Size(83, 20);
            this.txtBoxDataSize.TabIndex = 3;
            this.txtBoxDataSize.Text = "4096";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Array size, bytes:";
            // 
            // txtBoxDataStartAddr
            // 
            this.txtBoxDataStartAddr.Location = new System.Drawing.Point(7, 46);
            this.txtBoxDataStartAddr.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxDataStartAddr.Name = "txtBoxDataStartAddr";
            this.txtBoxDataStartAddr.Size = new System.Drawing.Size(83, 20);
            this.txtBoxDataStartAddr.TabIndex = 1;
            this.txtBoxDataStartAddr.Text = "0x20000428";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start address:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPagePlot);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(117, 12);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 486);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPagePlot
            // 
            this.tabPagePlot.Controls.Add(this.plotControl1);
            this.tabPagePlot.Location = new System.Drawing.Point(4, 22);
            this.tabPagePlot.Margin = new System.Windows.Forms.Padding(2);
            this.tabPagePlot.Name = "tabPagePlot";
            this.tabPagePlot.Padding = new System.Windows.Forms.Padding(2);
            this.tabPagePlot.Size = new System.Drawing.Size(772, 460);
            this.tabPagePlot.TabIndex = 0;
            this.tabPagePlot.Text = "Plot";
            this.tabPagePlot.UseVisualStyleBackColor = true;
            // 
            // plotControl1
            // 
            this.plotControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotControl1.Location = new System.Drawing.Point(2, 2);
            this.plotControl1.Margin = new System.Windows.Forms.Padding(2);
            this.plotControl1.Name = "plotControl1";
            this.plotControl1.Size = new System.Drawing.Size(768, 456);
            this.plotControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(772, 460);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Testing";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblLinesReceived
            // 
            this.lblLinesReceived.Name = "lblLinesReceived";
            this.lblLinesReceived.Size = new System.Drawing.Size(96, 17);
            this.lblLinesReceived.Text = "Lines Received: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 526);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MCUCapture";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPagePlot.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionSate;
        private System.Windows.Forms.Timer timerUpdateGUI;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBoxDataStartAddr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxDataSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnManualRead;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPagePlot;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox chkIsBigEndian;
        private System.Windows.Forms.Button btnWaitEndWatchpoint;
        private PlotControl plotControl1;
        private System.Windows.Forms.Button btnResumeMCU;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCleanWatchpoints;
        private System.Windows.Forms.ToolStripStatusLabel lblDataReceivedCnt;
        private System.Windows.Forms.ToolStripStatusLabel lblLinesReceived;
    }
}

