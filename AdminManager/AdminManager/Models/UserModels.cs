using System.ComponentModel.DataAnnotations;

namespace AdminManager.Models
{
    public class UserLoginModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? ReturnUrl { get; set; }
    }

    public class LoginSuccessViewModel
    {
        public object Token { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Role { get; set; } = null!;
    }

    public class UserViewModel
    {
        public string Id { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public string Role { get; set; } = null!;
    }

    public class UserRegisterModel
    {
        [Required]
        public string FullName { get; set; } = null!;
        [Required]
        public string Username { get; set; } = null!;
        public string Role { get; set; } = null!;
    }

    public class ResetPasswordModel
    {
        public string Username { get; set; } = null!;
    }
}
