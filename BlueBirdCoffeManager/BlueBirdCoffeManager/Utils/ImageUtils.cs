using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdCoffeManager.Utils
{
    public class ImageUtils
    {
        public static Image ByteArrayToImage(byte[] input)
        {
            using (var ms = new MemoryStream(input))
            {
                return Image.FromStream(ms);
            }
        }

        public static Image ResizeImage(Image img, int tarWidth, int tarHeigh)
        {
            int x, y, w, h;

            // Vertical
            if (img.Height > img.Width)
            {
                w = (img.Width * tarHeigh) / img.Height;
                h = tarHeigh;
                x = (tarWidth - w) / 2;
                y = 0;
            }
            else
            {
                //Horizontal
                w = tarWidth;
                h = (img.Height * tarWidth) / img.Width;
                x = 0;
                y = (tarHeigh - h) / 2;
            }

            var bmp = new Bitmap(tarWidth, tarHeigh);
            try
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(img, x, y, w, h);
                }
            }
            catch (Exception)
            {
                throw new Exception("Bitmap faild");
            }
            return bmp;
        }
    }
}