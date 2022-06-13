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
        public static readonly string HOST = "https://localhost:7244/";

        public static string TOKEN = "";
        public static string USER_NAME = "";
        public static string ROLE = "";

        public static readonly Font NOMAL_BOLD_FONT = new Font("time new roman", 10, FontStyle.Bold);
        public static readonly Font NOMAL_FONT = new Font("time new roman", 10);

        public static readonly Color MENU_COLOR = Color.FromArgb(38, 37, 37);
        public static readonly Color BUTTON_COLOR = Color.FromArgb(35, 214, 15);
        public static readonly CultureInfo CULTURE_INFO = new CultureInfo("vi-VN");
    }
}
