using AdminManager.Models;
using BlueBirdCoffeManager.DataAccessLayer;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdminManager.Controllers
{
    public class BillController : Controller
    {
        public async Task<IActionResult> Index(DateTime? singleDate)
        {
            string path = "api/Bill/ExportData?isNewest=true";
            if (singleDate != null)
            {
                path += "&date=" + singleDate;
            }
            var rawData = await ApiBuilder.SendRequest<object>(path, null, RequestMethod.GET, true, Request.GetDisplayUrl(), HttpContext.Session);

            var data = await ApiBuilder.ParseToData<BilPagingModel>(rawData);
            ViewBag.Bills = (JsonConvert.DeserializeObject<List<BillStatisticModel>>(data.Data.ToString()!))?.OrderBy(f => f.Description).ToList();

            ViewBag.Income = data.Income;
            ViewBag.EstimateIncome = data.EstimateIncome;
            ViewBag.CurrentDate = singleDate;
            return View();
        }
    }
}
