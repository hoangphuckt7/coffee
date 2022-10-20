using Data.Cache;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System.Data;

namespace BlueBirdCoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
        [HttpPost("Checkout")]
        public IActionResult Checkout([FromBody] CheckoutModel model)
        {
            return Ok(_billService.Checkout(model));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
        [HttpGet("History/{count}")]
        public IActionResult History(int count)
        {
            return Ok(_billService.History(count));
        }

        [HttpGet("MissingBillItemWithin48Hours")]
        public IActionResult TodateMissingItem()
        {
            return Ok(_billService.MissingBillItemWithin48Hours());
        }

        [HttpGet("Chart")]
        public IActionResult ChartData()
        {
            return Ok(_billService.ChartData());
        }

        [HttpGet("Statistics")]
        public IActionResult Statistics()
        {
            return Ok(_billService.Statistics());
        }
    }
}
