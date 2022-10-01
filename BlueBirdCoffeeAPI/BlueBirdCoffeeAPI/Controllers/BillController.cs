using Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

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

        [HttpPost("Checkout")]
        public IActionResult Checkout([FromBody] CheckoutModel model)
        {
            return Ok(_billService.Checkout(model));
        }

        [HttpGet("History/{count}")]
        public IActionResult History(int count)
        {
            return Ok(_billService.History(count));
        }
    }
}
