using AdminManager.Models;
using AdminManager.Utils;
using BlueBirdCoffeManager.DataAccessLayer;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection;
using System.Text;

namespace AdminManager.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login(string mes, string returnUrl)
        {
            if (!string.IsNullOrEmpty(Sessions.TOKEN))
            {
                if (string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("index", "home");
                }
                return Redirect(returnUrl);
            }

            ViewBag.Mes = mes;
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            Sessions.TOKEN = "";
            Sessions.FULLNAME = "";
            Sessions.ROLE = "";
            return RedirectToAction("Login", "User");
        }

        public async Task<IActionResult> Authenitcation(UserLoginModel model)
        {
            Sessions.LOGIN_ERROR_MESSAGE = "";
            var result = await ApiBuilder.SendRequest<object>("api/User/Login", new { Phone = model.Username, PassWord = model.Password }, RequestMethod.POST, false, model.ReturnUrl!);

            if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                return RedirectToAction("login", "user", new { mes = result.Content.ReadAsStringAsync().Result });
            }

            if (!result.IsSuccessStatusCode)
            {
                return RedirectToAction("login", "user", new { mes = "Lỗi" });
            }

            var data = await ApiBuilder.ParseToData<LoginSuccessViewModel>(result);

            Sessions.TOKEN = data?.Token.ToString()!;
            Sessions.FULLNAME = data?.FullName!;
            Sessions.ROLE = data?.Role!;
            
            if (string.IsNullOrEmpty(model.ReturnUrl))
            {
                return RedirectToAction("index", "home");
            }

            return Redirect(model.ReturnUrl);
        }
    }
}
