using BlueBirdCoffeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdCoffeManager.Utils
{
    public class BillPrinter
    {
        public static Bitmap SetupBill(OrderCreateModel models)
        {
            var line = 175;
            DateTime orderDate = DateTime.Now;
            #region print
            Font font = new Font("Calibri", 10F, GraphicsUnit.Point);
            Font boldFont = new Font("Calibri", 13, FontStyle.Bold, GraphicsUnit.Point);

            Bitmap bmp = new(302, line + 20 + 50 + 20 + models.OrderDetail.Count * 20 * 5);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                string date = DateTime.Now.Hour + ":" + DateTime.Now.Minute + "p - " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

                g.Clear(Color.White);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                //Compositing Mode can't be set since string needs source over to be valid
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                //And an additional step to make sure text is proper anti-aliased and takes advantage
                //of clear type as necessary
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                g.DrawImage(Properties.Resources.logo, -20, -10, 130, 130);
                g.DrawString("THE SUN COFFEE", boldFont, Brushes.Black, 95, 0);
                g.DrawString("Hotline: 0964101825", font, Brushes.Black, 100, 20);
                g.DrawString("Đc:359-Trần Khánh Dư,", font, Brushes.Black, 100, 40);
                g.DrawString("P.Duy Tân, TP Kon Tum.", font, Brushes.Black, 100, 60);
                g.DrawString($"Thời gian: {FormatDate(orderDate)}", font, Brushes.Black, 100, 80);

                g.DrawString("PHIẾU THANH TOÁN", new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point), Brushes.Black, 70, 120);

                g.DrawString("TT", font, Brushes.Black, 0, 145);
                g.DrawString("Tên món", font, Brushes.Black, 25, 145);
                g.DrawString("SL", font, Brushes.Black, 120, 145);
                g.DrawString("Đơn giá", font, Brushes.Black, 150, 145);
                g.DrawString("T.Tiền", font, Brushes.Black, 230, 145);
                g.DrawString("───────────────────────────────────────────────────────", font, Brushes.Black, 0, 155);

                for (int i = 0; i < models.OrderDetail.Count; i++)
                {
                    var itemData = Sessions.ItemSession.ItemData.First(f => f.Id == models.OrderDetail[i].ItemId);

                    g.DrawString(i + 1 + "", font, Brushes.Black, 0, line);

                    var nameLines = BreakLines(new List<string>() { itemData.Name }, 15);

                    int nLine = line;
                    foreach (var item in nameLines)
                    {
                        g.DrawString(item, font, Brushes.Black, 25, nLine);
                        nLine += 20;
                    }

                    g.DrawString(models.OrderDetail[i].Quantity + "", font, Brushes.Black, 120, line);
                    g.DrawString(FormatPrice(itemData.Price), font, Brushes.Black, 150, line);
                    g.DrawString(FormatPrice(itemData.Price * models.OrderDetail[i].Quantity), font, Brushes.Black, 220, line);
                    line = line + 20 + (nameLines.Count - 1) * 20;
                }

                g.DrawString("───────────────────────────────────────────────────────", font, Brushes.Black, 0, line);
                line += 20;
                g.DrawString("Tổng: ", boldFont, Brushes.Black, 0, line);

                var total = models.OrderDetail.Select(s => Sessions.ItemSession.ItemData.First(f => f.Id == s.ItemId).Price * s.Quantity).Sum();
                var stringTotal = FormatPrice(total);
                g.DrawString(stringTotal, boldFont, Brushes.Black, 295 - stringTotal.Length * 13, line);

                line += 50;
                g.DrawString("Cảm ơn quý khách, hẹn gặp lại!", new Font("Calibri", 11, FontStyle.Italic, GraphicsUnit.Point), Brushes.Black, 35, line);
                line += 20;
            }
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
            Bitmap newBitmap = new(302, line, bmpData.Stride, System.Drawing.Imaging.PixelFormat.Format1bppIndexed, bmpData.Scan0);
            return newBitmap;
        }

        public static string FormatDate(DateTime date)
        {
            return date.ToString("HH:mm dd-MM-yyyy");
            //return date.Hour + ":" + String.Format("{00}", date.Minute) + " " + date.Day + "-" + String.Format("{00}", date.Month) + "-" + date.Year;
        }

        public static string FormatPrice(double price)
        {
            return price.ToString("#,###", Application.CurrentCulture.NumberFormat);
        }

        public static List<string> BreakLines(List<string> lines, int limit)
        {
            var result = new List<string>();

            bool continueBreak = false;

            foreach (var item in lines)
            {
                if (item.Length <= limit)
                {
                    result.Add(item);
                }
                else
                {
                    for (int i = limit; limit > 0; i--)
                    {
                        if (item[i] == ' ')
                        {
                            var br = item.Substring(0, i);
                            result.Add(br);
                            result.Add(item.Substring(item.Length - (item.Length - br.Length - 1)));

                            continueBreak = true;
                            break;
                        }
                    }
                }
            }

            if (continueBreak) { return BreakLines(result, limit); }

            return result;
        }
    }
    #endregion
}