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
    }
}
