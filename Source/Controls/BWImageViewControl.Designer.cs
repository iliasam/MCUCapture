namespace MCUCapture
{
    partial class BWImageViewControl
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
            this.imageBox1 = new Cyotek.Windows.Forms.ImageBox();
            this.nudImageWidth = new System.Windows.Forms.NumericUpDown();
            this.nudImageHeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkPixelGrid = new System.Windows.Forms.CheckBox();
            this.lblPressedX = new System.Windows.Forms.Label();
            this.lblPressedY = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblErrorState = new System.Windows.Forms.Label();
            this.btnSelectBackgroundColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnSelectActiveColor = new System.Windows.Forms.Button();
            this.chkAddTime = new System.Windows.Forms.CheckBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox1.Location = new System.Drawing.Point(3, 36);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(627, 441);
            this.imageBox1.TabIndex = 0;
            this.imageBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imageBox1_MouseClick);
            // 
            // nudImageWidth
            // 
            this.nudImageWidth.Location = new System.Drawing.Point(44, 5);
            this.nudImageWidth.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudImageWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudImageWidth.Name = "nudImageWidth";
            this.nudImageWidth.Size = new System.Drawing.Size(59, 20);
            this.nudImageWidth.TabIndex = 1;
            this.nudImageWidth.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nudImageWidth.ValueChanged += new System.EventHandler(this.nudImageWidth_ValueChanged);
            // 
            // nudImageHeight
            // 
            this.nudImageHeight.Location = new System.Drawing.Point(155, 5);
            this.nudImageHeight.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudImageHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudImageHeight.Name = "nudImageHeight";
            this.nudImageHeight.Size = new System.Drawing.Size(59, 20);
            this.nudImageHeight.TabIndex = 2;
            this.nudImageHeight.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nudImageHeight.ValueChanged += new System.EventHandler(this.nudImageHeight_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Width:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Height:";
            // 
            // chkPixelGrid
            // 
            this.chkPixelGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPixelGrid.AutoSize = true;
            this.chkPixelGrid.Location = new System.Drawing.Point(651, 8);
            this.chkPixelGrid.Name = "chkPixelGrid";
            this.chkPixelGrid.Size = new System.Drawing.Size(98, 17);
            this.chkPixelGrid.TabIndex = 5;
            this.chkPixelGrid.Text = "Draw Pixel Grid";
            this.chkPixelGrid.UseVisualStyleBackColor = true;
            this.chkPixelGrid.CheckedChanged += new System.EventHandler(this.chkPixelGrid_CheckedChanged);
            // 
            // lblPressedX
            // 
            this.lblPressedX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPressedX.AutoSize = true;
            this.lblPressedX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPressedX.Location = new System.Drawing.Point(648, 86);
            this.lblPressedX.Name = "lblPressedX";
            this.lblPressedX.Size = new System.Drawing.Size(45, 16);
            this.lblPressedX.TabIndex = 6;
            this.lblPressedX.Text = "X: N/A";
            // 
            // lblPressedY
            // 
            this.lblPressedY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPressedY.AutoSize = true;
            this.lblPressedY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPressedY.Location = new System.Drawing.Point(648, 108);
            this.lblPressedY.Name = "lblPressedY";
            this.lblPressedY.Size = new System.Drawing.Size(46, 16);
            this.lblPressedY.TabIndex = 7;
            this.lblPressedY.Text = "Y: N/A";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(637, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "  Pressed Pos:  ";
            // 
            // lblErrorState
            // 
            this.lblErrorState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErrorState.AutoSize = true;
            this.lblErrorState.BackColor = System.Drawing.Color.OrangeRed;
            this.lblErrorState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblErrorState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblErrorState.Location = new System.Drawing.Point(233, 7);
            this.lblErrorState.Name = "lblErrorState";
            this.lblErrorState.Size = new System.Drawing.Size(134, 18);
            this.lblErrorState.TabIndex = 9;
            this.lblErrorState.Text = "ERROR: Wrong Size";
            this.lblErrorState.Visible = false;
            // 
            // btnSelectBackgroundColor
            // 
            this.btnSelectBackgroundColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectBackgroundColor.Location = new System.Drawing.Point(643, 169);
            this.btnSelectBackgroundColor.Name = "btnSelectBackgroundColor";
            this.btnSelectBackgroundColor.Size = new System.Drawing.Size(85, 25);
            this.btnSelectBackgroundColor.TabIndex = 10;
            this.btnSelectBackgroundColor.Text = "Background";
            this.btnSelectBackgroundColor.UseVisualStyleBackColor = true;
            this.btnSelectBackgroundColor.Click += new System.EventHandler(this.btnSelectBackgroundColor_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(642, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "  Select Color: ";
            // 
            // btnSelectActiveColor
            // 
            this.btnSelectActiveColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectActiveColor.Location = new System.Drawing.Point(643, 200);
            this.btnSelectActiveColor.Name = "btnSelectActiveColor";
            this.btnSelectActiveColor.Size = new System.Drawing.Size(85, 25);
            this.btnSelectActiveColor.TabIndex = 12;
            this.btnSelectActiveColor.Text = "Active Pixels";
            this.btnSelectActiveColor.UseVisualStyleBackColor = true;
            this.btnSelectActiveColor.Click += new System.EventHandler(this.btnSelectActiveColor_Click);
            // 
            // chkAddTime
            // 
            this.chkAddTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAddTime.Checked = true;
            this.chkAddTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddTime.Location = new System.Drawing.Point(645, 352);
            this.chkAddTime.Name = "chkAddTime";
            this.chkAddTime.Size = new System.Drawing.Size(93, 50);
            this.chkAddTime.TabIndex = 14;
            this.chkAddTime.Text = "Add Date and Time to Filename";
            this.chkAddTime.UseVisualStyleBackColor = true;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.Location = new System.Drawing.Point(645, 280);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(78, 27);
            this.btnSelectFile.TabIndex = 13;
            this.btnSelectFile.Text = "Select  File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(642, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Save image: ";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(645, 313);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 27);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BWImageViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkAddTime);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.btnSelectActiveColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSelectBackgroundColor);
            this.Controls.Add(this.lblErrorState);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPressedY);
            this.Controls.Add(this.lblPressedX);
            this.Controls.Add(this.chkPixelGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudImageHeight);
            this.Controls.Add(this.nudImageWidth);
            this.Controls.Add(this.imageBox1);
            this.Name = "BWImageViewControl";
            this.Size = new System.Drawing.Size(756, 480);
            ((System.ComponentModel.ISupportInitialize)(this.nudImageWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImageHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cyotek.Windows.Forms.ImageBox imageBox1;
        private System.Windows.Forms.NumericUpDown nudImageWidth;
        private System.Windows.Forms.NumericUpDown nudImageHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkPixelGrid;
        private System.Windows.Forms.Label lblPressedX;
        private System.Windows.Forms.Label lblPressedY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblErrorState;
        private System.Windows.Forms.Button btnSelectBackgroundColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnSelectActiveColor;
        private System.Windows.Forms.CheckBox chkAddTime;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
