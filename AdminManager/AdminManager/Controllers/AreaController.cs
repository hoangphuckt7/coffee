using AdminManager.Models;
using BlueBirdCoffeManager.DataAccessLayer;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AdminManager.Controllers
{
    public class AreaController : Controller
    {
        public async Task<IActionResult> Index(string? mess)
        {
            var rawData = await ApiBuilder.SendRequest<object>("api/Floor", null, RequestMethod.GET, true, Request.GetDisplayUrl(), HttpContext.Session);
            ViewBag.Categories = (await ApiBuilder.ParseToData<List<DescriptionViewModel>>(rawData)).OrderBy(f => f.Description).ToList();
            ViewBag.Mes = mess;

            return View();
        }

        public async Task<IActionResult> Update(Guid id, string description)
        {
            await ApiBuilder.SendRequest<object>($"api/Floor/{id}", new DescriptionModel() { Description = description }, RequestMethod.PUT, true, Request.GetDisplayUrl(), HttpContext.Session);
            return RedirectToAction("index", "area");
        }

        public async Task<IActionResult> Remove(Guid id)
        {
            await ApiBuilder.SendRequest<object>($"api/Floor/{id}", null, RequestMethod.DELETE, true, Request.GetDisplayUrl(), HttpContext.Session);
            return RedirectToAction("index", "area");
        }

        public async Task<IActionResult> Add(string description)
        {
            await ApiBuilder.SendRequest<object>($"api/Floor", new DescriptionModel() { Description = description }, RequestMethod.POST, true, Request.GetDisplayUrl(), HttpContext.Session);
            return RedirectToAction("index", "area");
        }
    }
}
