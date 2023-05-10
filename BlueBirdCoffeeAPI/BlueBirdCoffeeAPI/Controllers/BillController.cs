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

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN_CASHIER)]
        [HttpGet("ExportData")]
        public IActionResult ExportData(DateTime? date, DateTime? fromDate, DateTime? toDate, bool isNewest, int? pageIndex, int? pageSize)
        {
            return Ok(_billService.ExportData(date, fromDate, toDate, isNewest, pageIndex, pageSize));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
        [HttpPost("Checkout")]
        public IActionResult Checkout([FromBody] CheckoutModel model)
        {
            return Ok(_billService.Checkout(model, User.GetId()));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
        [HttpPost("PreCheck")]
        public IActionResult PreCheck([FromBody] CheckoutModel model)
        {
            return Ok(_billService.PreCheck(model, User.GetId()));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
        [HttpGet("History/{count}")]
        public IActionResult History(int count)
        {
            return Ok(_billService.History(count));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
        [HttpGet("MissingBillItemWithin48Hours")]
        public IActionResult TodateMissingItem()
        {
            return Ok(_billService.MissingBillItemWithin48Hours());
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        [HttpGet("Chart")]
        public IActionResult ChartData(bool? isBillCountChart = false)
        {
            return Ok(_billService.ChartData(isBillCountChart!.Value));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        [HttpGet("Statistics")]
        public IActionResult Statistics()
        {
            return Ok(_billService.Statistics());
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
        [HttpPut("Reason")]
        public IActionResult UpdateReason([FromBody] BillMissingItemUpdateModel model)
        {
            return Ok(_billService.UpdateReason(model));
        }
    }
}
