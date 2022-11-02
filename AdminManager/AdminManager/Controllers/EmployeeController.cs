using AdminManager.Models;
using BlueBirdCoffeManager.DataAccessLayer;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdminManager.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Index(string? mess, string? tableMes)
        {
            var rawData = await ApiBuilder.SendRequest<object>("api/User", null, RequestMethod.GET, true, Request.GetDisplayUrl(), HttpContext.Session);
            ViewBag.Users = await ApiBuilder.ParseToData<List<UserViewModel>>(rawData);
            ViewBag.Mes = mess;
            ViewBag.TableMes = tableMes;

            return View();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(UserRegisterModel model)
        {
            var rawData = await ApiBuilder.SendRequest<object>("api/User/Register", model, RequestMethod.POST, true, Request.GetDisplayUrl(), HttpContext.Session);
            string mes = "";
            if (!rawData.IsSuccessStatusCode)
            {
                mes = await rawData.Content.ReadAsStringAsync();
            }
            return RedirectToAction("index", "employee", new { mess = mes });
        }

        public async Task<IActionResult> ResetPassword(string username)
        {
            ResetPasswordModel model = new ResetPasswordModel() { Username = username };
            var rawData = await ApiBuilder.SendRequest<object>("api/User/ResetPassword", model, RequestMethod.PUT, true, Request.GetDisplayUrl(), HttpContext.Session);
            string mes = rawData.IsSuccessStatusCode ? "Cập nhật thành công" : await rawData.Content.ReadAsStringAsync();
            return RedirectToAction("index", "employee", new { tableMes = mes });
        }

        public async Task<IActionResult> Remove(string username)
        {
            var rawData = await ApiBuilder.SendRequest<object>($"api/User/{username}", null, RequestMethod.DELETE, true, Request.GetDisplayUrl(), HttpContext.Session);
            return RedirectToAction("index", "employee");
        }
    }
}
