using BlueBirdCoffeManager.Models;
using Newtonsoft.Json;

namespace BlueBirdCoffeManager.Utils
{
    public class BillPrinter
    {
        public static Bitmap SetupBill(OrderCreateModel models, DateTime? orderDate)
        {
            var line = 175;
            if (orderDate == null) orderDate = DateTime.Now;
            Font font = new Font("Calibri", 10F, GraphicsUnit.Point);
            Font boldFont = new Font("Calibri", 13, FontStyle.Bold, GraphicsUnit.Point);

            Bitmap bmp = new(270, line + 20 + 50 + 20 + models.OrderDetail.Count * 20 * 5);

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

                var x = ImageUtils.ResizeImage(Properties.Resources.logo, 100, 100);
                g.DrawImage(ImageUtils.ResizeImage(Properties.Resources.logo, 110, 110), -5, 0, 110, 110);
                g.DrawString("HIGHLANDS COFFEE", boldFont, Brushes.Black, 95, 0);
                g.DrawString("Đc:455-Trần Khánh Dư,", font, Brushes.Black, 100, 40);
                g.DrawString($"Thời gian: {FormatDate(orderDate)}", font, Brushes.Black, 100, 80);

                g.DrawString("HÓA ĐƠN BÁN HÀNG", new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point), Brushes.Black, 70, 120);

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

                    double subTotal = itemData.Price * models.OrderDetail[i].Quantity;
                    g.DrawString(FormatPrice(subTotal), font, Brushes.Black, subTotal > 1000000 ? 210 : 220, line);
                    line = line + 20 + (nameLines.Count - 1) * 20;
                }

                g.DrawString("───────────────────────────────────────────────────────", font, Brushes.Black, 0, line);
                line += 20;
                g.DrawString("Tổng: ", boldFont, Brushes.Black, 0, line);

                var total = models.OrderDetail.Select(s => Sessions.ItemSession.ItemData.First(f => f.Id == s.ItemId).Price * s.Quantity).Sum();

                var stringTotal = FormatPrice(total) + "₫";
                g.DrawString(stringTotal, boldFont, Brushes.Black, 295 - GetLeft(stringTotal.Length), line);

                double totalDiscount = 0;
                if (models.Discount != null && models.Discount != 0)
                {
                    line += 30;
                    g.DrawString("Giảm giá: ", boldFont, Brushes.Black, 0, line);
                    totalDiscount += models.Discount.Value;
                    var stringDiscount = FormatPrice(models.Discount.Value) + "₫";
                    g.DrawString(stringDiscount, boldFont, Brushes.Black, 295 - GetLeft(stringDiscount.Length), line);
                }

                if (models.Coupon != null && models.Coupon != 0)
                {
                    line += 30;
                    g.DrawString("Mã giảm giá: ", boldFont, Brushes.Black, 0, line);

                    totalDiscount += models.Coupon.Value;
                    var stringDiscount = FormatPrice(models.Coupon.Value) + "₫";
                    g.DrawString(stringDiscount, boldFont, Brushes.Black, 295 - GetLeft(stringDiscount.Length), line);
                }

                if ((models.Discount != null && models.Discount != 0) || (models.Coupon != null && models.Coupon != 0))
                {
                    line += 30;
                    g.DrawString("Phải thanh toán: ", boldFont, Brushes.Black, 0, line);

                    var stringDiscount = (total - totalDiscount) > 0 ? (FormatPrice(total - totalDiscount) + "₫") : "0₫";

                    g.DrawString(stringDiscount, boldFont, Brushes.Black, 295 - GetLeft(stringDiscount.Length), line);
                }

                line += 50;
                g.DrawString("Cảm ơn quý khách, hẹn gặp lại!", new Font("Calibri", 11, FontStyle.Italic, GraphicsUnit.Point), Brushes.Black, 35, line);
                line += 20;
            }
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
            Bitmap newBitmap = new(270, line, bmpData.Stride, System.Drawing.Imaging.PixelFormat.Format1bppIndexed, bmpData.Scan0);
            return newBitmap;
        }
        public static Bitmap SetupPreBill(OrderCreateModel models, DateTime? orderDate)
        {
            var line = 175;
            if (orderDate == null) orderDate = DateTime.Now;
            Font font = new Font("Calibri", 10F, GraphicsUnit.Point);
            Font boldFont = new Font("Calibri", 13, FontStyle.Bold, GraphicsUnit.Point);

            Bitmap bmp = new(270, line + 20 + 50 + 20 + models.OrderDetail.Count * 20 * 5);

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

                var x = ImageUtils.ResizeImage(Properties.Resources.logo, 100, 100);
                g.DrawImage(ImageUtils.ResizeImage(Properties.Resources.logo, 110, 110), -5, 0, 110, 110);
                g.DrawString("HIGHLANDS COFFEE", boldFont, Brushes.Black, 95, 0);
                g.DrawString("Đc:455-Trần Khánh Dư,", font, Brushes.Black, 100, 40);
                g.DrawString($"Thời gian: {FormatDate(orderDate)}", font, Brushes.Black, 100, 80);

                g.DrawString("PHIẾU TẠM TÍNH", new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point), Brushes.Black, 70, 120);

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

                    double subTotal = itemData.Price * models.OrderDetail[i].Quantity;
                    g.DrawString(FormatPrice(subTotal), font, Brushes.Black, subTotal > 1000000 ? 210 : 220, line);
                    line = line + 20 + (nameLines.Count - 1) * 20;
                }

                g.DrawString("───────────────────────────────────────────────────────", font, Brushes.Black, 0, line);
                line += 20;
                g.DrawString("Tổng: ", boldFont, Brushes.Black, 0, line);

                var total = models.OrderDetail.Select(s => Sessions.ItemSession.ItemData.First(f => f.Id == s.ItemId).Price * s.Quantity).Sum();

                var stringTotal = FormatPrice(total) + "₫";
                g.DrawString(stringTotal, boldFont, Brushes.Black, 295 - GetLeft(stringTotal.Length), line);

                double totalDiscount = 0;
                if (models.Discount != null && models.Discount != 0)
                {
                    line += 30;
                    g.DrawString("Giảm giá: ", boldFont, Brushes.Black, 0, line);
                    totalDiscount += models.Discount.Value;
                    var stringDiscount = FormatPrice(models.Discount.Value) + "₫";
                    g.DrawString(stringDiscount, boldFont, Brushes.Black, 295 - GetLeft(stringDiscount.Length), line);
                }

                if (models.Coupon != null && models.Coupon != 0)
                {
                    line += 30;
                    g.DrawString("Mã giảm giá: ", boldFont, Brushes.Black, 0, line);

                    totalDiscount += models.Coupon.Value;
                    var stringDiscount = FormatPrice(models.Coupon.Value) + "₫";
                    g.DrawString(stringDiscount, boldFont, Brushes.Black, 295 - GetLeft(stringDiscount.Length), line);
                }

                if ((models.Discount != null && models.Discount != 0) || (models.Coupon != null && models.Coupon != 0))
                {
                    line += 30;
                    g.DrawString("Phải thanh toán: ", boldFont, Brushes.Black, 0, line);

                    var stringDiscount = (total - totalDiscount) > 0 ? (FormatPrice(total - totalDiscount) + "₫") : "0₫";

                    g.DrawString(stringDiscount, boldFont, Brushes.Black, 295 - GetLeft(stringDiscount.Length), line);
                }
                line += 50;
            }
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
            Bitmap newBitmap = new(270, line, bmpData.Stride, System.Drawing.Imaging.PixelFormat.Format1bppIndexed, bmpData.Scan0);
            return newBitmap;
        }
        private static int GetLeft(int length)
        {
            if (length == 4)
            {
                return (int)(14.5 * length);
            }
            if (length == 5)
            {
                return (int)(14 * length);
            }
            if (length == 6)
            {
                return (int)(13.5 * length);
            }
            if (length == 7)
            {
                return (int)(13 * length);
            }
            if (length == 8)
            {
                return (int)(12.5 * length);
            }
            if (length == 10)
            {
                return (int)(11.5 * length);
            }
            return 25 * length;
        }

        public static string FormatDate(DateTime? date)
        {
            return date.Value.ToString("HH:mm dd-MM-yyyy");
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

        public static OrderCreateModel MergeOldBill(BillViewModel? item)
        {
            var orderCreateModel = new OrderCreateModel()
            {
                OrderDetail = item.OrderDetailViewModels,
                Coupon = item.Coupon,
                Discount = item.Discount
            };

            //Remove lost items
            List<OrderDetailViewModel> removeList = new List<OrderDetailViewModel>();
            foreach (var detail in orderCreateModel.OrderDetail)
            {
                if (detail.Quantity == 0)
                {
                    removeList.Add(detail);
                }
            }
            foreach (var remove in removeList)
            {
                orderCreateModel.OrderDetail.Remove(remove);
            }

            //Merge duplicate items
            List<OrderDetailViewModel> finalList = new List<OrderDetailViewModel>();

            foreach (var detail in orderCreateModel.OrderDetail)
            {
                var exsitedItem = finalList.Any(f => f.ItemId == detail.ItemId);

                if (exsitedItem)
                {
                    continue;
                }

                var duplicateItems = orderCreateModel.OrderDetail.Where(f => f.ItemId == detail.ItemId).ToList();

                if (duplicateItems.Count < 2)
                {
                    finalList.AddRange(duplicateItems);
                }
                else
                {
                    var mergeItem = duplicateItems.First();
                    mergeItem.Quantity = duplicateItems.Sum(f => f.Quantity);

                    finalList.Add(mergeItem);
                }
            }

            orderCreateModel.OrderDetail = finalList;
            return orderCreateModel;
        }

        public static Bitmap SetupOrder(OrderReceiverModel model)
        {
            Font font = new Font("Calibri", 10F, GraphicsUnit.Point);
            Font boldFont = new Font("Calibri", 13, FontStyle.Bold, GraphicsUnit.Point);

            Bitmap bmp = new(270, 20 + model.OrderDetails.Count * 20 * 10);
            var line = 65;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                //Compositing Mode can't be set since string needs source over to be valid
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                //And an additional step to make sure text is proper anti-aliased and takes advantage
                //of clear type as necessary
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                g.DrawString("Bàn: " + (model.Table == null ? "Không rõ" : model.Table.Description), boldFont, Brushes.Black, 0, 0);
                g.DrawString("#" + model.OrderNumber.ToString() + $" - {model.DateCreated.ToString("HH:mm")}", boldFont, Brushes.Black, 0, 20);

                g.DrawString("SL", boldFont, Brushes.Black, 0, 40);
                g.DrawString("Tên món", boldFont, Brushes.Black, 25, 40);
                g.DrawString("───────────────────────────────────────────────────────", font, Brushes.Black, 0, 50);

                for (int i = 0; i < model.OrderDetails.Count; i++)
                {
                    var itemData = Sessions.ItemSession.ItemData.First(f => f.Id == model.OrderDetails[i].ItemId);

                    //g.DrawString(i + 1 + "", font, Brushes.Black, 0, line);
                    g.DrawString(model.OrderDetails[i].Quantity + "", boldFont, Brushes.Black, 0, line);

                    var nameLines = BreakLines(new List<string>() { itemData.Name }, 25);

                    foreach (var item in nameLines)
                    {
                        g.DrawString(item, boldFont, Brushes.Black, 25, line);
                        line += 20;
                    }

                    var data = JsonConvert.DeserializeObject<List<DetailValue>>(model.OrderDetails[i].Description);
                    foreach (var item in data)
                    {
                        if (item.Ice != 100 || item.Sugar != 100 || !string.IsNullOrEmpty(item.Note))
                        {
                            string noteLine = "●";
                            if (item.Sugar != 100)
                            {
                                noteLine += $"Đường: {item.Sugar}% ";
                            }
                            if (item.Ice != 100)
                            {
                                noteLine += $"Đá: {item.Ice}% ";
                            }
                            if (!string.IsNullOrEmpty(item.Note))
                            {
                                noteLine += $"Ghi chú: {item.Note}";
                            }
                            var noteLines = BreakLines(new List<string>() { noteLine }, 35);

                            foreach (var note in noteLines)
                            {
                                g.DrawString(note, font, Brushes.Black, 25, line);
                                line += 20;
                            }
                        }
                    }
                }
            }
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
            Bitmap newBitmap = new(270, line, bmpData.Stride, System.Drawing.Imaging.PixelFormat.Format1bppIndexed, bmpData.Scan0);
            return newBitmap;
        }
    }
}