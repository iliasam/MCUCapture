using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MCUCapture
{
    public partial class BWImageViewControl : UserControl
    {
        ParseBWImageDataClass ParseBWImageDataObj;
        SettingsHandlingClass SettingsHandlingObj;

        Color ImageBackColor = Color.LightGray;
        Color ImageActiveColor = Color.Black;

        public BWImageViewControl()
        {
            InitializeComponent();
            ParseBWImageDataObj = new ParseBWImageDataClass();

            ParseBWImageDataObj.SetImageSize(
                (int)nudImageWidth.Value, (int)nudImageHeight.Value);

            string settings_file_path = Application.StartupPath + @"\config.ini";
            if (File.Exists(settings_file_path))
            {
                SettingsHandlingObj = new SettingsHandlingClass(settings_file_path);
                ReadSavedSettings();
            }
        }



        public void ProcessData(byte[] rxData)
        {
            Bitmap img = ParseBWImageDataObj.ParseData(rxData);
            if (img != null)
            {
                Invoke((MethodInvoker)(() =>
                {
                    lblErrorState.Visible = false;
                    imageBox1.Image = img;
                }));
            }
            else
            {
                Invoke((MethodInvoker)(() =>
                {
                    lblErrorState.Visible = true;
                }));
            }  
        }

        private void nudImageWidth_ValueChanged(object sender, EventArgs e)
        {
            ParseBWImageDataObj.SetImageSize(
                (int)nudImageWidth.Value, (int)nudImageHeight.Value);
        }

        private void nudImageHeight_ValueChanged(object sender, EventArgs e)
        {
            ParseBWImageDataObj.SetImageSize(
                (int)nudImageWidth.Value, (int)nudImageHeight.Value);
        }

        private void chkPixelGrid_CheckedChanged(object sender, EventArgs e)
        {
            imageBox1.ShowPixelGrid = chkPixelGrid.Checked;
        }

        private void imageBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);

            Point srcPoint = imageBox1.PointToImage(point);

            if ((srcPoint.X >= 0) && (srcPoint.Y >= 0))
            {
                lblPressedX.Text = $"X: {srcPoint.X} pix";
                lblPressedY.Text = $"Y: {srcPoint.Y} pix";
            }
            else
            {
                lblPressedX.Text = "N/A";
                lblPressedY.Text = "N/A";
            }
        }

        void ReadSavedSettings()
        {
            string str_width = SettingsHandlingObj.GetSetting("BW_IMAGE_SETTINGS", "width");
            string str_height = SettingsHandlingObj.GetSetting("BW_IMAGE_SETTINGS", "height");

            nudImageWidth.Value = Convert.ToDecimal(str_width);
            nudImageHeight.Value = Convert.ToDecimal(str_height);
        }

        public void SaveSettings()
        {
            if (SettingsHandlingObj == null)
                return;

            SettingsHandlingObj.AddSetting("BW_IMAGE_SETTINGS", "width", nudImageWidth.Value.ToString());
            SettingsHandlingObj.AddSetting("BW_IMAGE_SETTINGS", "height", nudImageHeight.Value.ToString());

            SettingsHandlingObj.SaveSettings();
        }

        private void btnSelectBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ImageBackColor = colorDialog1.Color;
            }
            ParseBWImageDataObj.SetColors(ImageBackColor, ImageActiveColor);
        }

        private void btnSelectActiveColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ImageActiveColor = colorDialog1.Color;
            }
            ParseBWImageDataObj.SetColors(ImageBackColor, ImageActiveColor);
        }
    }//end of class
}
