using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdCoffeManager.Sessions
{
    public class Sessions
    {
        public static readonly string HOST = "https://localhost:7244/";

        public static string TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiIyMzQwNDc4My04OGVjLTRkYTMtYTA2Mi05YTc3MGYxN2Y3ZTAiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjkzMzM2ZTdmLTQ0MjUtNGM3YS05NDhiLWM0YjhlMThmNWZmNiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkNBU0hFUiIsImV4cCI6MTY1MTYzMjU0NiwiaXNzIjoiaHR0cHM6Ly9ibHVlYmlyZHh4Lnh4IiwiYXVkIjoiaHR0cHM6Ly9ibHVlYmlyZHh4Lnh4In0.UGWWcrpBZe78RWcYb2vooXZ09_BxUcwKloeYGHwMZQM";
        public static string USER_NAME = "Trần Vũ";
        public static string USER_USERNAME = "Null";

        public static readonly Font NOMAL_BOLD_FONT = new Font("time new roman", 10, FontStyle.Bold);
        public static readonly Font NOMAL_FONT = new Font("time new roman", 10);

        public static readonly Color MENU_COLOR = Color.FromArgb(38, 37, 37);
        public static readonly Color BUTTON_COLOR = Color.FromArgb(35, 214, 15);
    }
}
