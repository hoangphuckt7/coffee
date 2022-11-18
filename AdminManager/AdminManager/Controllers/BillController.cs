using AdminManager.Models;
using BlueBirdCoffeManager.DataAccessLayer;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AdminManager.Controllers
{
    public class BillController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var rawData = await ApiBuilder.SendRequest<object>("api/Bill/ExportData?isNewest=true", null, RequestMethod.GET, true, Request.GetDisplayUrl(), HttpContext.Session);
            ViewBag.Bills = (await ApiBuilder.ParseToData<List<BillStatisticModel>>(rawData)).OrderBy(f => f.Description).ToList();

            return View();
        }
    }
}
