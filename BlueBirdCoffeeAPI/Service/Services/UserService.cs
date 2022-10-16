using Data.AppException;
using Data.Cache;
using Data.DataAccessLayer;
using Data.Entities;
using Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface IUserService
    {
        Task<string> Register(UserRegisterModel user, string role);
        Task<LoginSuccessViewModel> Login(UserLoginModel model);

        //Task<ResultModel> GetById(string userId, string currentUserId);
        //Task<ResultModel> UpdatePassword(EditPasswordViewModel model, string userId);
    }

    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(AppDbContext dbContext, SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> Register(UserRegisterModel model, string role)
        {
            var userEmail = _dbContext.Users.FirstOrDefault(u => u.UserName == model.Username);

            if (userEmail != null)
            {
                throw new Exception("Username already exist!");
            }

            var identUser = new User
            {
                Fullname = model.FullName,
                NormalizedUserName = model.Username,
                UserName = model.Username
            };

            var createRs = await _userManager.CreateAsync(identUser, model.Username);

            if (createRs.Succeeded)
            {
                await _signInManager.SignInAsync(identUser, false);

                await _userManager.AddToRoleAsync(identUser, role);

                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Can't create user");
            }
            return model.Username;
        }

        public async Task<LoginSuccessViewModel> Login(UserLoginModel model)
        {

            var signInResult = await _signInManager.PasswordSignInAsync(model.Phone, model.Password, false, false);

            if (signInResult.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.UserName == model.Phone);
                if (appUser == null) throw new AppException("Invalid user");
                var roles = await _userManager.GetRolesAsync(appUser);

                var fullname = _dbContext.Users.First(u => u.UserName == model.Phone).Fullname;
                object token = GenerateJwtToken(appUser, roles[0]);

                var successViewModel = new LoginSuccessViewModel()
                {
                    Token = token,
                    FullName = fullname,
                    Role = roles[0]
                };

                return successViewModel;
            }
            else
            {
                throw new AppException("Thông tin đăng nhập không hợp lệ.");
            }

        }

        private object GenerateJwtToken(IdentityUser user, string role)
        {
            var claims = new List<Claim>
            {
                //new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, role),
                //new Claim(ClaimTypes.GivenName, fullname)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuerOptions:Issuer"],
                _configuration["JwtIssuerOptions:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
