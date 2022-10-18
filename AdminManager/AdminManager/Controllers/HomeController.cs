﻿using AdminManager.Models;
using BlueBirdCoffeManager.DataAccessLayer;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AdminManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var request = await ApiBuilder.SendRequest<object>("api/Bill/Chart", null, RequestMethod.GET, true, Request.GetDisplayUrl());
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
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            await ApiBuilder.SendRequest<object>("x", null, RequestMethod.GET, true, Request.GetDisplayUrl());
            return View();
        }
    }
}