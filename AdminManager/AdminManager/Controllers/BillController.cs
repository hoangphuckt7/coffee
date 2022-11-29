using AdminManager.Models;
using BlueBirdCoffeManager.DataAccessLayer;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdminManager.Controllers
{
    public class BillController : Controller
    {
        public async Task<IActionResult> Index(DateTime? singleDate, DateTime? fromDate, DateTime? toDate, int? pageSize = 10, int? pageIndex = 1, bool? isNewest = true)
        {
            string path = "api/Bill/ExportData?isNewest=" + isNewest;
            if (singleDate != null)
            {
                path += "&date=" + singleDate;
            }
            if (pageSize != null)
            {
                if (pageSize != -1) path += "&pageSize=" + pageSize;
            }

            if (fromDate != null)
            {
                path += "&fromDate=" + fromDate;
            }

            if (toDate != null)
            {
                path += "&toDate=" + toDate;
            }

            path += "&pageIndex=" + pageIndex;

            var rawData = await ApiBuilder.SendRequest<object>(path, null, RequestMethod.GET, true, Request.GetDisplayUrl(), HttpContext.Session);

            var data = await ApiBuilder.ParseToData<BilPagingModel>(rawData);
            ViewBag.Bills = (JsonConvert.DeserializeObject<List<BillStatisticModel>>(data.Data.ToString()!))?.OrderBy(f => f.Description).ToList();

            ViewBag.Income = data.Income;
            ViewBag.EstimateIncome = data.EstimateIncome;

            ViewBag.CurrentDate = singleDate;
            ViewBag.PageSize = pageSize;
            ViewBag.IsNewest = isNewest;

            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;

            ViewBag.PageIndex = pageIndex;
            ViewBag.TotalPage = Math.Ceiling((decimal)data.Total / (decimal)pageSize!.Value);

            return View();
        }

        public async Task<IActionResult> Item(DateTime? singleDate, DateTime? fromDate, DateTime? toDate)
        {
            if (singleDate == null && fromDate == null && toDate == null)
            {
                fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                toDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            }

            string path = "api/Item/Statistic";
            bool first = false;
            if (singleDate != null)
            {
                first = true;
                path += "?date=" + singleDate.Value.ToShortDateString();
            }

            if (fromDate != null)
            {
                path += !first ? "?fromDate=" : "&fromDate=";
                path += fromDate.Value.ToShortDateString();
                first = true;
            }

            if (toDate != null)
            {
                path += !first ? "?toDate=" : "&toDate=";
                path += toDate.Value.ToShortDateString();
            }

            var rawData = await ApiBuilder.SendRequest<object>(path, null, RequestMethod.GET, true, Request.GetDisplayUrl(), HttpContext.Session);

            var result = await ApiBuilder.ParseToData<List<ItemStatisticModel>>(rawData);
            ViewBag.Items = result;

            var total = result.Sum(s => s.Total);
            ViewBag.TotalS = total > 0 ? total : 1;

            var selled = result.Sum(s => s.Selled);
            ViewBag.SelledS = selled > 0 ? selled : 1;

            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;
            ViewBag.CurrentDate = singleDate;
            return View();
        }
    }
}
