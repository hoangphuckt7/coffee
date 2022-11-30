using AdminManager.Models;
using BlueBirdCoffeManager.DataAccessLayer;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace AdminManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(NoStore = true, Duration = 0)]
        public async Task<IActionResult> Index(bool? billCountChart = false)
        {
            if (billCountChart == null) billCountChart = false;
            var request = await ApiBuilder.SendRequest<object>($"api/Bill/Chart?isBillCountChart={billCountChart!.Value}", null, RequestMethod.GET, true, Request.GetDisplayUrl(), HttpContext.Session);
            if (request.IsSuccessStatusCode)
            {
                var data = await ApiBuilder.ParseToData<List<ChartViewModel>>(request);
                string seriesData = "[";
                foreach (var item in data)
                {
                    string total;
                    if (billCountChart == true)
                    {
                        total = item.Total.ToString();
                    }
                    else
                    {
                        var sum = item.Total.ToString();
                        //var sum = item.Total.ToString("#,###", (new CultureInfo("vi-VN")).NumberFormat);
                        //if (string.IsNullOrEmpty(sum)) sum = "0";
                        //if (sum.ToCharArray().Count(f => f == '.') > 1)
                        //{

                        //}
                        total = sum;
                    }
                    seriesData += $"[{item.Date},{total}],";
                }
                seriesData += "]";
                ViewBag.SeriesData = seriesData;
            }

            var statisticsRaw = await ApiBuilder.SendRequest<object>("api/Bill/Statistics", null, RequestMethod.GET, true, Request.GetDisplayUrl(), HttpContext.Session);
            if (statisticsRaw.IsSuccessStatusCode)
            {
                var data = await ApiBuilder.ParseToData<StatisticsModels>(statisticsRaw);
                ViewBag.Statistics = data;
            }

            ViewBag.BillCountChart = billCountChart;
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            await ApiBuilder.SendRequest<object>("x", null, RequestMethod.GET, true, Request.GetDisplayUrl(), HttpContext.Session);
            return View();
        }
    }
}