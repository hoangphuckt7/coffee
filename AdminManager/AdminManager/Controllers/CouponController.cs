using AdminManager.Models;
using BlueBirdCoffeManager.DataAccessLayer;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AdminManager.Controllers
{
    public class CouponController : Controller
    {
        public async Task<IActionResult> Index(string? mess)
        {
            var rawData = await ApiBuilder.SendRequest<object>("api/Coupon", null, RequestMethod.GET, true, Request.GetDisplayUrl(), HttpContext.Session);
            ViewBag.Coupons = (await ApiBuilder.ParseToData<List<CouponViewModel>>(rawData)).OrderByDescending(f => f.Default).ThenByDescending(f => f.FromDate).ToList();
            ViewBag.Mes = mess;

            return View();
        }

        public async Task<IActionResult> Add(CouponAddModel model)
        {
            var rawData = await ApiBuilder.SendRequest<object>("api/Coupon", model, RequestMethod.POST, true, Request.GetDisplayUrl(), HttpContext.Session);
            string mes = "";
            if (!rawData.IsSuccessStatusCode)
            {
                mes = await rawData.Content.ReadAsStringAsync();
            }
            return RedirectToAction("index", "coupon", new { mess = mes });
        }

        public async Task<IActionResult> Remove(Guid id)
        {
            var rawData = await ApiBuilder.SendRequest<object>($"api/Coupon/{id}", null, RequestMethod.DELETE, true, Request.GetDisplayUrl(), HttpContext.Session);
            return RedirectToAction("index", "coupon");
        }
    }
}
