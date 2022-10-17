using AdminManager.Models;
using BlueBirdCoffeManager.DataAccessLayer;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            await ApiBuilder.SendRequest<object>("x", null, RequestMethod.GET, true, Request.GetDisplayUrl());
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            await ApiBuilder.SendRequest<object>("x", null, RequestMethod.GET, true, Request.GetDisplayUrl());
            return View();
        }
    }
}