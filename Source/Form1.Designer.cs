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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblConnectionSate = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHaltState = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDataReceivedCnt = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLinesReceived = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWatchpointActive = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSelectedELFItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSelectedTriggerELFItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerUpdateGUI = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTaketriggerAddressFromELF = new System.Windows.Forms.Button();
            this.comboBoxTrigSize = new System.Windows.Forms.ComboBox();
            this.btnWaitForTrigger = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxTriggerValue = new System.Windows.Forms.TextBox();
            this.txtBoxTriggerAddr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnHaltMCU = new System.Windows.Forms.Button();
            this.btnTakeDataFromELF = new System.Windows.Forms.Button();
            this.btnCleanWatchpoints = new System.Windows.Forms.Button();
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
            this.tabPageDataSaving = new System.Windows.Forms.TabPage();
            this.dataSavingControl1 = new MCUCapture.DataSavingControl();
            this.tabPageBWImage = new System.Windows.Forms.TabPage();
            this.bwImageViewControl1 = new MCUCapture.BWImageViewControl();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPagePlot.SuspendLayout();
            this.tabPageDataSaving.SuspendLayout();
            this.tabPageBWImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConnectionSate,
            this.lblHaltState,
            this.lblDataReceivedCnt,
            this.lblLinesReceived,
            this.lblWatchpointActive,
            this.lblSelectedELFItem,
            this.lblSelectedTriggerELFItem});
            this.statusStrip1.Location = new System.Drawing.Point(0, 549);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(897, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblConnectionSate
            // 
            this.lblConnectionSate.AutoSize = false;
            this.lblConnectionSate.Name = "lblConnectionSate";
            this.lblConnectionSate.Size = new System.Drawing.Size(100, 17);
            this.lblConnectionSate.Text = "Connection: N/A";
            // 
            // lblHaltState
            // 
            this.lblHaltState.AutoSize = false;
            this.lblHaltState.Name = "lblHaltState";
            this.lblHaltState.Size = new System.Drawing.Size(70, 17);
            this.lblHaltState.Text = "MCU: N/A";
            // 
            // lblDataReceivedCnt
            // 
            this.lblDataReceivedCnt.Name = "lblDataReceivedCnt";
            this.lblDataReceivedCnt.Size = new System.Drawing.Size(82, 17);
            this.lblDataReceivedCnt.Text = "Data RX Cnt: 0";
            // 
            // lblLinesReceived
            // 
            this.lblLinesReceived.Name = "lblLinesReceived";
            this.lblLinesReceived.Size = new System.Drawing.Size(63, 17);
            this.lblLinesReceived.Text = "Lines RX: 0";
            // 
            // lblWatchpointActive
            // 
            this.lblWatchpointActive.Name = "lblWatchpointActive";
            this.lblWatchpointActive.Size = new System.Drawing.Size(97, 17);
            this.lblWatchpointActive.Text = "Watchpoint: N/A";
            // 
            // lblSelectedELFItem
            // 
            this.lblSelectedELFItem.Name = "lblSelectedELFItem";
            this.lblSelectedELFItem.Size = new System.Drawing.Size(109, 17);
            this.lblSelectedELFItem.Text = "Curr. ELF Item: N/A";
            // 
            // lblSelectedTriggerELFItem
            // 
            this.lblSelectedTriggerELFItem.Name = "lblSelectedTriggerELFItem";
            this.lblSelectedTriggerELFItem.Size = new System.Drawing.Size(149, 17);
            this.lblSelectedTriggerELFItem.Text = "Curr. Trigger ELF Item: N/A";
            // 
            // timerUpdateGUI
            // 
            this.timerUpdateGUI.Tick += new System.EventHandler(this.timerUpdateGUI_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnTaketriggerAddressFromELF);
            this.groupBox1.Controls.Add(this.comboBoxTrigSize);
            this.groupBox1.Controls.Add(this.btnWaitForTrigger);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBoxTriggerValue);
            this.groupBox1.Controls.Add(this.txtBoxTriggerAddr);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnHaltMCU);
            this.groupBox1.Controls.Add(this.btnTakeDataFromELF);
            this.groupBox1.Controls.Add(this.btnCleanWatchpoints);
            this.groupBox1.Controls.Add(this.btnResumeMCU);
            this.groupBox1.Controls.Add(this.btnWaitEndWatchpoint);
            this.groupBox1.Controls.Add(this.chkIsBigEndian);
            this.groupBox1.Controls.Add(this.btnManualRead);
            this.groupBox1.Controls.Add(this.txtBoxDataSize);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBoxDataStartAddr);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(104, 537);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Source";
            // 
            // btnTaketriggerAddressFromELF
            // 
            this.btnTaketriggerAddressFromELF.Location = new System.Drawing.Point(4, 271);
            this.btnTaketriggerAddressFromELF.Margin = new System.Windows.Forms.Padding(2);
            this.btnTaketriggerAddressFromELF.Name = "btnTaketriggerAddressFromELF";
            this.btnTaketriggerAddressFromELF.Size = new System.Drawing.Size(96, 22);
            this.btnTaketriggerAddressFromELF.TabIndex = 27;
            this.btnTaketriggerAddressFromELF.Text = "Addr. From ELF";
            this.btnTaketriggerAddressFromELF.UseVisualStyleBackColor = true;
            this.btnTaketriggerAddressFromELF.Click += new System.EventHandler(this.btnTaketriggerAddressFromELF_Click);
            // 
            // comboBoxTrigSize
            // 
            this.comboBoxTrigSize.FormattingEnabled = true;
            this.comboBoxTrigSize.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8"});
            this.comboBoxTrigSize.Location = new System.Drawing.Point(45, 339);
            this.comboBoxTrigSize.Name = "comboBoxTrigSize";
            this.comboBoxTrigSize.Size = new System.Drawing.Size(49, 21);
            this.comboBoxTrigSize.TabIndex = 26;
            this.comboBoxTrigSize.Text = "4";
            // 
            // btnWaitForTrigger
            // 
            this.btnWaitForTrigger.Location = new System.Drawing.Point(7, 365);
            this.btnWaitForTrigger.Margin = new System.Windows.Forms.Padding(2);
            this.btnWaitForTrigger.Name = "btnWaitForTrigger";
            this.btnWaitForTrigger.Size = new System.Drawing.Size(87, 28);
            this.btnWaitForTrigger.TabIndex = 23;
            this.btnWaitForTrigger.Text = "Wait Trigger";
            this.btnWaitForTrigger.UseVisualStyleBackColor = true;
            this.btnWaitForTrigger.Click += new System.EventHandler(this.btnWaitForTrigger_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 342);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Size:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 297);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Variable value:";
            // 
            // txtBoxTriggerValue
            // 
            this.txtBoxTriggerValue.Location = new System.Drawing.Point(11, 314);
            this.txtBoxTriggerValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxTriggerValue.Name = "txtBoxTriggerValue";
            this.txtBoxTriggerValue.Size = new System.Drawing.Size(83, 20);
            this.txtBoxTriggerValue.TabIndex = 17;
            this.txtBoxTriggerValue.Text = "1";
            // 
            // txtBoxTriggerAddr
            // 
            this.txtBoxTriggerAddr.Location = new System.Drawing.Point(11, 244);
            this.txtBoxTriggerAddr.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxTriggerAddr.Name = "txtBoxTriggerAddr";
            this.txtBoxTriggerAddr.Size = new System.Drawing.Size(83, 20);
            this.txtBoxTriggerAddr.TabIndex = 16;
            this.txtBoxTriggerAddr.Text = "0x20001428";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 229);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Variable address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(2, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "   Capture Trigger   ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(4, 416);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 21);
            this.button2.TabIndex = 13;
            this.button2.Text = "wp info";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 416);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 21);
            this.button1.TabIndex = 12;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnHaltMCU
            // 
            this.btnHaltMCU.BackColor = System.Drawing.Color.Yellow;
            this.btnHaltMCU.Location = new System.Drawing.Point(7, 473);
            this.btnHaltMCU.Margin = new System.Windows.Forms.Padding(2);
            this.btnHaltMCU.Name = "btnHaltMCU";
            this.btnHaltMCU.Size = new System.Drawing.Size(87, 28);
            this.btnHaltMCU.TabIndex = 11;
            this.btnHaltMCU.Text = "Halt MCU";
            this.btnHaltMCU.UseVisualStyleBackColor = false;
            this.btnHaltMCU.Click += new System.EventHandler(this.btnHaltMCU_Click);
            // 
            // btnTakeDataFromELF
            // 
            this.btnTakeDataFromELF.Location = new System.Drawing.Point(4, 19);
            this.btnTakeDataFromELF.Margin = new System.Windows.Forms.Padding(2);
            this.btnTakeDataFromELF.Name = "btnTakeDataFromELF";
            this.btnTakeDataFromELF.Size = new System.Drawing.Size(96, 22);
            this.btnTakeDataFromELF.TabIndex = 10;
            this.btnTakeDataFromELF.Text = "Addr. from ELF";
            this.btnTakeDataFromELF.UseVisualStyleBackColor = true;
            this.btnTakeDataFromELF.Click += new System.EventHandler(this.btnTakeDataFromELF_Click);
            // 
            // btnCleanWatchpoints
            // 
            this.btnCleanWatchpoints.Location = new System.Drawing.Point(7, 441);
            this.btnCleanWatchpoints.Margin = new System.Windows.Forms.Padding(2);
            this.btnCleanWatchpoints.Name = "btnCleanWatchpoints";
            this.btnCleanWatchpoints.Size = new System.Drawing.Size(87, 28);
            this.btnCleanWatchpoints.TabIndex = 9;
            this.btnCleanWatchpoints.Text = "Clean WP";
            this.btnCleanWatchpoints.UseVisualStyleBackColor = true;
            this.btnCleanWatchpoints.Click += new System.EventHandler(this.btnCleanWatchpoints_Click);
            // 
            // btnResumeMCU
            // 
            this.btnResumeMCU.Location = new System.Drawing.Point(7, 505);
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
            this.btnWaitEndWatchpoint.Location = new System.Drawing.Point(7, 178);
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
            this.chkIsBigEndian.Location = new System.Drawing.Point(10, 124);
            this.chkIsBigEndian.Name = "chkIsBigEndian";
            this.chkIsBigEndian.Size = new System.Drawing.Size(77, 17);
            this.chkIsBigEndian.TabIndex = 5;
            this.chkIsBigEndian.Text = "Big Endian";
            this.chkIsBigEndian.UseVisualStyleBackColor = true;
            // 
            // btnManualRead
            // 
            this.btnManualRead.Location = new System.Drawing.Point(7, 145);
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
            this.txtBoxDataSize.Location = new System.Drawing.Point(9, 96);
            this.txtBoxDataSize.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxDataSize.Name = "txtBoxDataSize";
            this.txtBoxDataSize.Size = new System.Drawing.Size(83, 20);
            this.txtBoxDataSize.TabIndex = 3;
            this.txtBoxDataSize.Text = "4096";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Array size, bytes:";
            // 
            // txtBoxDataStartAddr
            // 
            this.txtBoxDataStartAddr.Location = new System.Drawing.Point(9, 59);
            this.txtBoxDataStartAddr.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxDataStartAddr.Name = "txtBoxDataStartAddr";
            this.txtBoxDataStartAddr.Size = new System.Drawing.Size(83, 20);
            this.txtBoxDataStartAddr.TabIndex = 1;
            this.txtBoxDataStartAddr.Text = "0x20000428";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
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
            this.tabControl1.Controls.Add(this.tabPageDataSaving);
            this.tabControl1.Controls.Add(this.tabPageBWImage);
            this.tabControl1.Location = new System.Drawing.Point(117, 12);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 535);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPagePlot
            // 
            this.tabPagePlot.Controls.Add(this.plotControl1);
            this.tabPagePlot.Location = new System.Drawing.Point(4, 22);
            this.tabPagePlot.Margin = new System.Windows.Forms.Padding(2);
            this.tabPagePlot.Name = "tabPagePlot";
            this.tabPagePlot.Padding = new System.Windows.Forms.Padding(2);
            this.tabPagePlot.Size = new System.Drawing.Size(772, 509);
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
            this.plotControl1.Size = new System.Drawing.Size(768, 505);
            this.plotControl1.TabIndex = 0;
            // 
            // tabPageDataSaving
            // 
            this.tabPageDataSaving.Controls.Add(this.dataSavingControl1);
            this.tabPageDataSaving.Location = new System.Drawing.Point(4, 22);
            this.tabPageDataSaving.Name = "tabPageDataSaving";
            this.tabPageDataSaving.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDataSaving.Size = new System.Drawing.Size(772, 509);
            this.tabPageDataSaving.TabIndex = 2;
            this.tabPageDataSaving.Text = "Data Saving";
            this.tabPageDataSaving.UseVisualStyleBackColor = true;
            // 
            // dataSavingControl1
            // 
            this.dataSavingControl1.Location = new System.Drawing.Point(6, 6);
            this.dataSavingControl1.Name = "dataSavingControl1";
            this.dataSavingControl1.Size = new System.Drawing.Size(503, 200);
            this.dataSavingControl1.TabIndex = 0;
            // 
            // tabPageBWImage
            // 
            this.tabPageBWImage.Controls.Add(this.bwImageViewControl1);
            this.tabPageBWImage.Location = new System.Drawing.Point(4, 22);
            this.tabPageBWImage.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageBWImage.Name = "tabPageBWImage";
            this.tabPageBWImage.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageBWImage.Size = new System.Drawing.Size(772, 509);
            this.tabPageBWImage.TabIndex = 1;
            this.tabPageBWImage.Text = "BW Image View";
            this.tabPageBWImage.UseVisualStyleBackColor = true;
            // 
            // bwImageViewControl1
            // 
            this.bwImageViewControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bwImageViewControl1.Location = new System.Drawing.Point(8, 6);
            this.bwImageViewControl1.Name = "bwImageViewControl1";
            this.bwImageViewControl1.Size = new System.Drawing.Size(756, 480);
            this.bwImageViewControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 571);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MCUCapture v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing_1);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPagePlot.ResumeLayout(false);
            this.tabPageDataSaving.ResumeLayout(false);
            this.tabPageBWImage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.TabPage tabPageBWImage;
        private System.Windows.Forms.CheckBox chkIsBigEndian;
        private System.Windows.Forms.Button btnWaitEndWatchpoint;
        private System.Windows.Forms.Button btnResumeMCU;
        private System.Windows.Forms.Button btnCleanWatchpoints;
        private System.Windows.Forms.ToolStripStatusLabel lblDataReceivedCnt;
        private System.Windows.Forms.ToolStripStatusLabel lblLinesReceived;
        private System.Windows.Forms.Button btnTakeDataFromELF;
        private System.Windows.Forms.Button btnHaltMCU;
        private System.Windows.Forms.ToolStripStatusLabel lblSelectedELFItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private PlotControl plotControl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxTriggerAddr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxTriggerValue;
        private System.Windows.Forms.Button btnWaitForTrigger;
        private System.Windows.Forms.ComboBox comboBoxTrigSize;
        private System.Windows.Forms.ToolStripStatusLabel lblHaltState;
        private System.Windows.Forms.ToolStripStatusLabel lblWatchpointActive;
        private System.Windows.Forms.Button btnTaketriggerAddressFromELF;
        private System.Windows.Forms.ToolStripStatusLabel lblSelectedTriggerELFItem;
        private System.Windows.Forms.TabPage tabPageDataSaving;
        private DataSavingControl dataSavingControl1;
        private BWImageViewControl bwImageViewControl1;
    }
}

