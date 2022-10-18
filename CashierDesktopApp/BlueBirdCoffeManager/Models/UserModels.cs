using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdCoffeManager.Models
{
    public class UserLoginModel
    {
        public string Phone { get; set; }
        public string Password { get; set; }
    }

    public class LoginSuccessViewModel
    {
        public object Token { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}
