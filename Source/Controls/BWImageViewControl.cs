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
using System.Drawing.Imaging;

namespace MCUCapture
{
    // Display BW image
    public partial class BWImageViewControl : UserControl
    {
        ParseBWImageDataClass ParseBWImageDataObj;
        SettingsHandlingClass SettingsHandlingRefObj;

        Color ImageBackColor = Color.LightGray;
        Color ImageActiveColor = Color.Black;

        Bitmap LastImage;

        string FileSavePath = "";

        public BWImageViewControl()
        {
            InitializeComponent();
            ParseBWImageDataObj = new ParseBWImageDataClass();

            ParseBWImageDataObj.SetImageSize(
                (int)nudImageWidth.Value, (int)nudImageHeight.Value);
        }

        public void InitSavingSystem(ref SettingsHandlingClass settingsHandlingObj)
        {
            SettingsHandlingRefObj = settingsHandlingObj;
            ReadSavedSettings();
            ParseBWImageDataObj.SetColors(ImageBackColor, ImageActiveColor);
        }

        public void ProcessData(byte[] rxData)
        {
            Bitmap img = ParseBWImageDataObj.ParseData(
                rxData, ParseBWImageDataClass.BWImageType.TYPE1);

            if (img != null)
            {
                Invoke((MethodInvoker)(() =>
                {
                    lblErrorState.Visible = false;
                    imageBox1.Image = img;
                    LastImage = img;
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
            string str_width = SettingsHandlingRefObj.GetSetting("BW_IMAGE_SETTINGS", "width");
            string str_height = SettingsHandlingRefObj.GetSetting("BW_IMAGE_SETTINGS", "height");

            string str_back_color = SettingsHandlingRefObj.GetSetting("BW_IMAGE_SETTINGS", "back_color");
            string str_active_color = SettingsHandlingRefObj.GetSetting("BW_IMAGE_SETTINGS", "active_color");

            ImageBackColor = ColorTranslator.FromHtml(str_back_color);
            ImageActiveColor = ColorTranslator.FromHtml(str_active_color);

            nudImageWidth.Value = Convert.ToDecimal(str_width);
            nudImageHeight.Value = Convert.ToDecimal(str_height);
        }

        private static String ConvertColorToHex(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public void SaveSettings()
        {
            if (SettingsHandlingRefObj == null)
                return;

            SettingsHandlingRefObj.AddSetting("BW_IMAGE_SETTINGS", "width", nudImageWidth.Value.ToString());
            SettingsHandlingRefObj.AddSetting("BW_IMAGE_SETTINGS", "height", nudImageHeight.Value.ToString());

            SettingsHandlingRefObj.AddSetting("BW_IMAGE_SETTINGS", "back_color",
                ConvertColorToHex(ImageBackColor));
            SettingsHandlingRefObj.AddSetting("BW_IMAGE_SETTINGS", "active_color",
                ConvertColorToHex(ImageActiveColor));

            SettingsHandlingRefObj.SaveSettings();
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

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PNG file|*.png|All files|*.*";
            saveFileDialog1.Title = "Select file for saving data";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                if (FileSavePath != saveFileDialog1.FileName)
                {
                    FileSavePath = saveFileDialog1.FileName;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string tmp_path = FileSavePath;
                if (chkAddTime.Checked)
                {
                    int tmp_pos = FileSavePath.Length - 4;
                    string extension = FileSavePath.Substring(tmp_pos, 4);

                    tmp_path = FileSavePath.Substring(0, tmp_pos);
                    tmp_path += "_" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + extension;
                }

                if (LastImage != null)
                {
                    LastImage.Save(tmp_path, ImageFormat.Png);
                }
            }
            catch (Exception)
            {

            }
        }
    }//end of class
}
