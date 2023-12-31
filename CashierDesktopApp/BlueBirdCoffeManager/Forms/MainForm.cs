﻿using BlueBirdCoffeManager.DataAccessLayer;
using BlueBirdCoffeManager.Models;
using BlueBirdCoffeManager.Sessions;
using BlueBirdCoffeManager.Utils;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueBirdCoffeManager.Forms
{
    public partial class MainForm : Form
    {
        private readonly Font MAIN_MENU_BUTTON_FONT = new Font("time new roman", 10, FontStyle.Bold);
        HubConnection connection;
        public MainForm()
        {
            InitializeComponent();

            var urlSignalR = Sessions.Sessions.HOST + "notificationHub";

            connection = new HubConnectionBuilder()
          .WithUrl(urlSignalR, opt =>
          {
              opt.AccessTokenProvider = () => Task.FromResult(Sessions.Sessions.TOKEN);
          })
          .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 100);
                await connection.StartAsync();
            };

            connection.On<OrderReceiverModel>("newNotify", (model) =>
            {
                this.Invoke((Action)(() =>
                {
                    current = model;
                    printDocument1.Print();

                    SoundPlayer snd = new SoundPlayer(Properties.Resources.notification_sound_7062);
                    snd.Play();
                }));
            });

        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            #region Setup Data
            if (ItemSession.ItemData.Count == 0)
            {
                var itemsRequest = await ApiBuilder.SendRequest<object>("api/Item", null, RequestMethod.GET);
                ItemSession.ItemData = JsonConvert.DeserializeObject<List<ItemViewModel>>(itemsRequest);
            }
            if (ItemSession.Categories.Count == 0)
            {
                var categoriesRequest = await ApiBuilder.SendRequest<List<DescriptionViewModel>>("api/Category", null, RequestMethod.GET);
                ItemSession.Categories = JsonConvert.DeserializeObject<List<DescriptionViewModel>>(categoriesRequest);
            }
            if (ItemSession.Items.Count == 0)
            {
                List<ItemImages> items = new List<ItemImages>();
                foreach (var item in ItemSession.ItemData)
                {
                    var itemImage = new ItemImages() { Id = item.Id };
                    foreach (var imageId in item.Images)
                    {
                        var imageRequest = await ApiBuilder.SendImageRequest("api/Item/Image/" + imageId);
                        Image image = ImageUtils.ByteArrayToImage(imageRequest);
                        itemImage.Images.Add(image);
                    }
                    items.Add(itemImage);
                }
                ItemSession.Items = items;
            }

            var rawCoupon = await ApiBuilder.SendRequest<object>("api/Coupon/Default", null, RequestMethod.GET);
            var coupon = JsonConvert.DeserializeObject<CouponUseableModel>(rawCoupon);
            if (coupon != null && !string.IsNullOrEmpty(coupon.Description))
            {
                Sessions.Sessions.DEFAULT_COUPON = coupon.Description;
            }
            #endregion

            #region screen setup
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //this.ControlBox = false;
            //this.Text = String.Empty;

            this.menuPanel.Left = 0;
            this.menuPanel.Top = 0;
            this.menuPanel.Size = new Size(Width, this.Height * 5 / 100);
            this.menuPanel.BackColor = Sessions.Sessions.MENU_COLOR;

            this.dataPanel.Left = 0;
            this.dataPanel.Top = menuPanel.Height;
            this.dataPanel.Size = new Size(Width, (Height - menuPanel.Height));

            this.btnTable.Top = 0;
            this.btnTable.ForeColor = Color.White;
            this.btnTable.Size = new Size(menuPanel.Width * 10 / 100, menuPanel.Height);
            this.btnTable.BackColor = Sessions.Sessions.MENU_COLOR;
            this.btnTable.FlatAppearance.BorderSize = 0;
            this.btnTable.TabStop = false;
            this.btnTable.FlatStyle = FlatStyle.Flat;
            this.btnTable.Font = MAIN_MENU_BUTTON_FONT;

            #region split
            Panel sp1 = new Panel()
            {
                Top = 0,
                Width = 1,
                Height = menuPanel.Height,
                Left = btnTable.Left + btnTable.Width,
                BackColor = Color.White
            };

            menuPanel.Controls.Add(sp1);
            #endregion

            this.btnOrder.Top = 0;
            this.btnOrder.Left = btnTable.Left + btnTable.Width + (int)((0.07 * Width) / 100);
            this.btnOrder.ForeColor = Color.White;
            this.btnOrder.Size = new Size(menuPanel.Width * 10 / 100, menuPanel.Height);
            this.btnOrder.BackColor = Sessions.Sessions.MENU_COLOR;
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.TabStop = false;
            this.btnOrder.FlatStyle = FlatStyle.Flat;
            this.btnOrder.Font = MAIN_MENU_BUTTON_FONT;

            #region split
            Panel sp2 = new Panel()
            {
                Top = 0,
                Width = 1,
                Height = menuPanel.Height,
                Left = btnOrder.Left + btnOrder.Width,
                BackColor = Color.White
            };

            menuPanel.Controls.Add(sp2);
            #endregion

            this.btnBill.Top = 0;
            this.btnBill.Left = btnOrder.Left + btnOrder.Width + (int)((0.07 * Width) / 100);
            this.btnBill.ForeColor = Color.White;
            this.btnBill.Size = new Size(menuPanel.Width * 10 / 100, menuPanel.Height);
            this.btnBill.BackColor = Sessions.Sessions.MENU_COLOR;
            this.btnBill.FlatAppearance.BorderSize = 0;
            this.btnBill.TabStop = false;
            this.btnBill.FlatStyle = FlatStyle.Flat;
            this.btnBill.Font = MAIN_MENU_BUTTON_FONT;

            pictureBox1.Height = Height * 2 / 100;
            pictureBox1.Width = Width * 1 / 100;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Left = Width - pictureBox1.Width - (int)(0.5 * Width / 100);
            pictureBox1.Top = 57 * menuPanel.Height / 100 - lbDot.Height;

            lbDot.Font = new Font("", 10, FontStyle.Bold);
            lbDot.Text = "●";
            lbDot.ForeColor = Color.Green;
            lbDot.Top = 63 * menuPanel.Height / 100 - lbDot.Height;
            lbDot.Left = pictureBox1.Left - lbDot.Width - (int)(0.5 * Width / 100);

            lbUsername.Font = Sessions.Sessions.NORMAL_BOLD_FONT;
            lbUsername.Top = 63 * menuPanel.Height / 100 - lbDot.Height;
            lbUsername.Text = Sessions.Sessions.USER_NAME;
            lbUsername.ForeColor = Color.White;
            lbUsername.Left = lbDot.Left - lbUsername.Width - (int)(0.5 * Width / 100);
            #endregion

            dataPanel.Controls.Clear();
            TableForm myForm = new TableForm(dataPanel, null);
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            dataPanel.Controls.Add(myForm);
            myForm.Show();

            try
            {
                await connection.StartAsync();
            }
            catch (Exception)
            {
                //listBox1.Items.Add(ex.Message);
            }
            ActiveButton(this.btnTable);
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            ActiveButton(this.btnTable);
            DeactiveButton(this.btnOrder);
            DeactiveButton(this.btnBill);

            dataPanel.Controls.Clear();
            TableForm myForm = new TableForm(dataPanel, null);
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            dataPanel.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            ActiveButton(this.btnOrder);
            DeactiveButton(this.btnTable);
            DeactiveButton(this.btnBill);

            dataPanel.Controls.Clear();

            OrderForm myForm = new OrderForm(null);
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            dataPanel.Controls.Add(myForm);
            myForm.Show();
        }

        #region Helper
        private void DeactiveButton(Button btn)
        {
            btn.ForeColor = Color.White;
            btn.BackColor = Sessions.Sessions.MENU_COLOR;
        }

        private void ActiveButton(Button btn)
        {
            btn.ForeColor = Color.Black;
            btn.BackColor = Color.White;
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            const string messageEx = "Bạn có thật sự muốn thoát ứng dụng?";
            const string captionEx = "Thông báo";
            var result = MessageBox.Show(messageEx, captionEx, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // If the no button was pressed ...
            if (result == DialogResult.OK)
            {
                this.Close();
                //MainForm mainScreen = (MainForm)Application.OpenForms["MainForm"];
                //mainScreen.Close();
            }
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            ActiveButton(this.btnBill);
            DeactiveButton(this.btnOrder);
            DeactiveButton(this.btnTable);

            dataPanel.Controls.Clear();

            BillForm myForm = new BillForm(null);
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            dataPanel.Controls.Add(myForm);
            myForm.Show();
        }
        OrderReceiverModel current;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var curImg = BillPrinter.SetupOrder(current);
            //var final = ImageUtils.ResizeImage(curImg, curImg.Width / 2, curImg.Height / 2);
            e.Graphics.DrawImage(curImg, 0, 0);
        }
    }
}
