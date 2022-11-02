using Data.Cache;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace BlueBirdCoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            return Ok(await _userService.Register(model, model.Role));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            return Ok(await _userService.Login(model));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        [HttpGet]
        public IActionResult GetAllUser()
        {
            return Ok(_userService.GetAllUser());
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        [HttpPut("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            return Ok(await _userService.ReNewPassword(model));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        [HttpDelete("{username}")]
        public IActionResult RemoveUser(string username)
        {
            return Ok(_userService.RemoveUser(username));
        }
    }
}
