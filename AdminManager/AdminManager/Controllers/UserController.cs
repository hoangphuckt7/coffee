using AdminManager.Models;
using AdminManager.Utils;
using BlueBirdCoffeManager.DataAccessLayer;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace AdminManager.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login(string mes, string returnUrl)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Token")))
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
            HttpContext.Session.SetString("FullName", "");
            HttpContext.Session.SetString("Role", "");
            HttpContext.Session.SetString("Token", "");
            return RedirectToAction("Login", "User");
        }

        public async Task<IActionResult> Authenitcation(UserLoginModel model)
        {
            HttpContext.Session.SetString("LoginErrorMessage", "");
            var result = await ApiBuilder.SendRequest<object>("api/User/Login", new { Phone = model.Username, PassWord = model.Password }, RequestMethod.POST, false, model.ReturnUrl!, HttpContext.Session);

            if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                return RedirectToAction("login", "user", new { mes = result.Content.ReadAsStringAsync().Result });
            }

            if (!result.IsSuccessStatusCode)
            {
                return RedirectToAction("login", "user", new { mes = "Lỗi" });
            }

            var data = await ApiBuilder.ParseToData<LoginSuccessViewModel>(result);

            var x = HttpContext.Session;

            HttpContext.Session.SetString("FullName", data?.FullName!);
            HttpContext.Session.SetString("Role", data?.Role!);
            HttpContext.Session.SetString("Token", data?.Token.ToString()!);

            if (string.IsNullOrEmpty(model.ReturnUrl))
            {
                return RedirectToAction("index", "home");
            }

            return Redirect(model.ReturnUrl);
        }
    }
}
