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
                    seriesData += $"[{item.Date},{item.Total}],";
                }
                seriesData += "]";
                ViewBag.SeriesData = seriesData;
            }

            var statisticsRaw = await ApiBuilder.SendRequest<object>("api/Bill/Statistics", null, RequestMethod.GET, true, Request.GetDisplayUrl(), HttpContext.Session);
            if (statisticsRaw.IsSuccessStatusCode)
            {
                var data = await ApiBuilder.ParseToData<StatisticsModels>(statisticsRaw);
                ViewBag.Statistics = data;

                //Current date
                if (data.ChartTodateIncome > data.ChartLastDateIncome)
                {
                    ViewBag.UpChartTodateIncome = true;
                    ViewBag.ChartTodateIncome = data.ChartTodateIncome == 0 ? 0 : Math.Round((data.ChartTodateIncome - data.ChartLastDateIncome) * 100 / data.ChartTodateIncome, 2);
                }
                else
                {
                    ViewBag.UpChartTodateIncome = false;
                    ViewBag.ChartTodateIncome = data.ChartLastDateIncome == 0 ? 0 : Math.Round((data.ChartLastDateIncome - data.ChartTodateIncome) * 100 / data.ChartLastDateIncome, 2);
                }

                //this week
                if (data.ChartThisWeekIncome > data.ChartLastWeekIncome)
                {
                    ViewBag.UpChartThisWeekIncome = true;
                    ViewBag.ChartThisWeekIncome = data.ChartThisWeekIncome == 0 ? 0 : Math.Round((data.ChartThisWeekIncome - data.ChartLastWeekIncome) * 100 / data.ChartThisWeekIncome, 2);
                }
                else
                {
                    ViewBag.UpChartThisWeekIncome = false;
                    ViewBag.ChartThisWeekIncome = data.ChartLastWeekIncome == 0 ? 0 : Math.Round((data.ChartLastWeekIncome - data.ChartThisWeekIncome) * 100 / data.ChartLastWeekIncome, 2);
                }

                //this month
                if (data.ChartThisMonthIncome > data.ChartLastMonthIncome)
                {
                    ViewBag.UpChartThisMonthIncome = true;
                    ViewBag.ChartThisMonthIncome = data.ChartThisMonthIncome == 0 ? 0 : Math.Round((data.ChartThisMonthIncome - data.ChartLastMonthIncome) * 100 / data.ChartThisMonthIncome, 2);
                }
                else
                {
                    ViewBag.UpChartThisMonthIncome = false;
                    ViewBag.ChartThisMonthIncome = data.ChartLastMonthIncome == 0 ? 0 : Math.Round((data.ChartLastMonthIncome - data.ChartThisMonthIncome) * 100 / data.ChartLastMonthIncome, 2);
                }

                ViewBag.BillCountChart = billCountChart;
            }
            return View();
        }
    }
}