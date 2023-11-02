using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdCoffeManager.Sessions
{
    public class Sessions
    {
        public static readonly string HOST = "http://192.168.1.6:8000/";

        public static string TOKEN = "";
        public static string USER_NAME = "";
        public static string ROLE = "";

        public static readonly Font NORMAL_BOLD_FONT = new Font("time new roman", 10, FontStyle.Bold);
        public static readonly Font NORMAL_FONT = new Font("time new roman", 10);

        public static readonly Color MENU_COLOR = Color.FromArgb(38, 37, 37);
        public static readonly Color BUTTON_COLOR = Color.FromArgb(35, 214, 15);
        //public static readonly Color SUB_BUTTON_COLOR = Color.FromArgb(197, 219, 200);
        public static readonly Color SUB_BUTTON_COLOR = Color.FromArgb(105, 179, 21);
        public static readonly CultureInfo CULTURE_INFO = new CultureInfo("vi-VN");

        public static int MINIMUM_HEIGH = 23;
        public static int MINIMUM_WIDTH = 32;

        public static bool SHOW_ORDER_ITEM_DETAILS = false;

        public static Point? TABLE_WORK_SPACE;
        public static string? DEFAULT_COUPON;
    }
}
