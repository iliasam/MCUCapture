using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUCapture
{
    class ParseBWImageDataClass
    {
        // Size in pixels
        int Width = 0;
        int Height = 0;

        Color ImageBackColor = Color.LightGray;
        Color ImageActiveColor = Color.Black;

        Bitmap ProcImage;

        public enum BWImageType
        {
            TYPE1 = 0,
            TYPE2, //for future
        };
 
        // Set image colors
        public void SetColors(Color back, Color active)
        {
            ImageBackColor = back;
            ImageActiveColor = active;
        }

        public void SetImageSize(int width, int height)
        {
            if ((width < 1) || (height < 1))
                return;

            Width = width;
            Height = height;
        }

        public Bitmap ParseData(byte[] data, BWImageType imageType)
        {
            int exp_bytes_cnt = Width * Height / 8;//every byte is 8 pixels
            if (data.Length != exp_bytes_cnt)
            {
                return null;//error
            }

            ProcImage = new Bitmap(Width, Height);

            // Processing every byte of the received data
            for (int i = 0; i < data.Length; i++)
            {
                if (imageType == BWImageType.TYPE1)
                    FillEightPixelsType1(data[i], i);
            }

            return ProcImage;
        }

        void FillEightPixelsType1(byte value, int position)
        {
            //bits are vertical

            int x = position % Width;
            int y_start = position / Width * 8;

            for (int i = 0; i < 8; i++)//bit and offset
            {
                int y = y_start + i;
                if ((value & (1 << i)) != 0)
                    ProcImage.SetPixel(x, y, ImageActiveColor);
                else
                    ProcImage.SetPixel(x, y, ImageBackColor);
            }
        }

    }//end of class
}
