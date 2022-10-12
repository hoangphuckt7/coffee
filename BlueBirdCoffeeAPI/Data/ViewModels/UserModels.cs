using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class UserRegisterModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Username { get; set; }
        public string Role { get; set; }
    }

    public class UserLoginModel
    {
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class LoginSuccessViewModel
    {
        public object Token { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}
