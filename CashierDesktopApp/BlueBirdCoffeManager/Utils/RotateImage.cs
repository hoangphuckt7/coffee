﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdCoffeManager.Utils
{
    public class ImagUtils
    {
        public static Bitmap RotateImage(Bitmap b, float angle)
        {
            if (angle == 90) b.RotateFlip(RotateFlipType.Rotate90FlipY);
            if (angle == 180) b.RotateFlip(RotateFlipType.Rotate180FlipY);
            if (angle == 270) b.RotateFlip(RotateFlipType.Rotate270FlipY);

            return b;

            ////create a new empty bitmap to hold rotated image
            //Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            ////make a graphics object from the empty bitmap
            //using (Graphics g = Graphics.FromImage(returnBitmap))
            //{
            //    //move rotation point to center of image
            //    g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            //    //rotate
            //    g.RotateTransform(angle);
            //    //move image back
            //    g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            //    //draw passed in image onto graphics object
            //    g.DrawImage(b, new Point(0, 0));
            //}
            //return returnBitmap;
        }
    }
}
