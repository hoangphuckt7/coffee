using AdminManager.Models;
using BlueBirdCoffeManager.DataAccessLayer;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace AdminManager.Controllers
{
    public class ItemController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var rawData = await ApiBuilder.SendRequest<object>("api/Item", null, RequestMethod.GET, true, Request.GetDisplayUrl(), HttpContext.Session);
            ViewBag.Items = (await ApiBuilder.ParseToData<List<ItemViewModel>>(rawData)).OrderBy(f => f.Category!.Description).ToList();

            try
            {
                var defaultItems = await ApiBuilder.SendRequest<object>("api/Item/DefaultItems", null, RequestMethod.GET, true, Request.GetDisplayUrl(), HttpContext.Session);
                ViewBag.DefaultItems = await ApiBuilder.ParseToData<List<Guid>>(defaultItems);
            }
            catch (Exception)
            {
                ViewBag.DefaultItems = new List<Guid>();
            }

            return View();
        }

        public async Task<IActionResult> Remove(Guid id)
        {
            var rawData = await ApiBuilder.SendRequest<object>($"api/Item/{id}", null, RequestMethod.DELETE, true, Request.GetDisplayUrl(), HttpContext.Session);
            return RedirectToAction("Index", "Item");
        }

        public async Task<IActionResult> SetDefault(Guid id)
        {
            var rawData = await ApiBuilder.SendRequest<object>($"api/Item/SetDefault/{id}", null, RequestMethod.PUT, true, Request.GetDisplayUrl(), HttpContext.Session);
            return RedirectToAction("Index", "Item");
        }

        public async Task<IActionResult> RemoveDefault(Guid id)
        {
            var rawData = await ApiBuilder.SendRequest<object>($"api/Item/RemoveDefault/{id}", null, RequestMethod.PUT, true, Request.GetDisplayUrl(), HttpContext.Session);
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

        public async Task<IActionResult> Edit(Guid id, string? mes)
        {
            var categoryRawData = await ApiBuilder.SendRequest<object>($"api/Category", null, RequestMethod.GET, true, Request.GetDisplayUrl(), HttpContext.Session);
            ViewBag.Categories = (await ApiBuilder.ParseToData<List<DescriptionViewModel>>(categoryRawData)).OrderBy(f => f.Description).ToList();

            var rawData = await ApiBuilder.SendRequest<object>($"api/Item?id={id}", null, RequestMethod.GET, true, Request.GetDisplayUrl(), HttpContext.Session);
            ViewBag.Item = (await ApiBuilder.ParseToData<List<ItemViewModel>>(rawData)).FirstOrDefault();
            ViewBag.Mes = mes;
            return View();
        }

        public async Task<IActionResult> Update(ItemUpdateModel model)
        {
            var rawData = await ApiBuilder.SendRequest<object>($"api/Item/{model.Id}", model, RequestMethod.PUT, true, Request.GetDisplayUrl(), HttpContext.Session);
            string mes = "";
            if (!rawData.IsSuccessStatusCode)
            {
                mes = await rawData.Content.ReadAsStringAsync();
            }

            return RedirectToAction("edit", "item", new { id = model.Id, mes = mes });
        }

        public async Task<IActionResult> RemoveImg(Guid id, Guid itemId)
        {
            await ApiBuilder.SendRequest<object>($"api/Item/Image/{id}", null, RequestMethod.DELETE, true, Request.GetDisplayUrl(), HttpContext.Session);
            return RedirectToAction("edit", "item", new { id = itemId });
        }

        public async Task<IActionResult> AddImg(Guid id, List<IFormFile> images)
        {
            var rawData = await ApiBuilder.SendRequest<object>($"api/Item/Image/{id}", new ItemImageUpdateModel() { Images = images }, RequestMethod.MULTIPART_PUT, true, Request.GetDisplayUrl(), HttpContext.Session);

            string mes = "";
            if (!rawData.IsSuccessStatusCode)
            {
                mes = await rawData.Content.ReadAsStringAsync();
            }

            return RedirectToAction("edit", "item", new { id = id, mes = mes });
        }
    }
}
