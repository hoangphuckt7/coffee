using Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace BlueBirdCoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateModel model)
        {
            return Ok(await _orderService.CreateOrder("93336e7f-4425-4c7a-948b-c4b8e18f5ff6", model));
        }

        [HttpGet("Table/{id}")]
        public IActionResult GetByTable(Guid id)
        {
            return Ok(_orderService.GetByTable(id));
        }

        [HttpGet("TodateMissingItem")]
        public IActionResult TodateMissingItem()
        {
            return Ok(_orderService.TodateMissingItem());
        }

        [HttpPut("MissingItem")]
        public IActionResult SetMissingItem([FromBody] SetMissingItemModel model)
        {
            _orderService.SetMissingItem(model);
            return Ok("ok");
        }

        [HttpPut("MissingOrder")]
        public IActionResult SetMissingOrder([FromBody] SetMissingOrders model)
        {
            return Ok(_orderService.SetMissingOrder(model, "93336e7f-4425-4c7a-948b-c4b8e18f5ff6"));
        }
    }
}
