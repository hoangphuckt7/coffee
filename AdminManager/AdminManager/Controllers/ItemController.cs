using AdminManager.Models;
using BlueBirdCoffeManager.DataAccessLayer;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AdminManager.Controllers
{
    public class ItemController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var rawData = await ApiBuilder.SendRequest<object>("api/Item", null, RequestMethod.GET, true, Request.GetDisplayUrl(), HttpContext.Session);
            ViewBag.Items = (await ApiBuilder.ParseToData<List<ItemViewModel>>(rawData)).OrderBy(f => f.Category!.Description).ToList();
            return View();
        }

        public async Task<IActionResult> Remove(Guid id)
        {
            var rawData = await ApiBuilder.SendRequest<object>($"api/Item/{id}", null, RequestMethod.DELETE, true, Request.GetDisplayUrl(), HttpContext.Session);
            return RedirectToAction("Index", "Item");
        }

        public async Task<IActionResult> Add(string? mes, string? mesColor)
        {
            var rawData = await ApiBuilder.SendRequest<object>($"api/Category", null, RequestMethod.GET, true, Request.GetDisplayUrl(), HttpContext.Session);
            ViewBag.Categories = (await ApiBuilder.ParseToData<List<DescriptionViewModel>>(rawData)).OrderBy(f => f.Description).ToList();

            ViewBag.Mes = mes;
            ViewBag.MesColor = mesColor;

            return View();
        }

        public async Task<IActionResult> AddItem(ItemAddModel model)
        {
            var rawData = await ApiBuilder.SendRequest<ItemAddModel>($"api/Item", model, RequestMethod.MULTIPART_POST, true, Request.GetDisplayUrl(), HttpContext.Session);
            string mes;
            string mesColor;
            if (rawData.IsSuccessStatusCode)
            {
                mes = "Thêm thành công";
                mesColor = "green";
            }
            else
            {
                mes = "Thất bại, mã lỗi: " + await rawData.Content.ReadAsStringAsync();
                mesColor = "red";
            }
            return RedirectToAction("Add", "Item", new { mes = mes, mesColor = mesColor });
        }
    }
}
