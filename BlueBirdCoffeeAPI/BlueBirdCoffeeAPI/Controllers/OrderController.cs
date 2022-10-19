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

        [HttpGet("UnknowLocaltion")]
        public IActionResult GetUnknowLocaltionOrders()
        {
            return Ok(_orderService.GetUnknowLocaltionOrders());
        }

        [HttpGet]
        public IActionResult GetByIds([FromQuery] List<Guid> ids)
        {
            return Ok(_orderService.GetByIds(ids));
        }


        [HttpGet("CurrentOrders")]
        public IActionResult CurrentOrders()
        {
            return Ok(_orderService.GetCurrentOrders());
        }

        [HttpGet("TodayCompletedOrders")]
        public IActionResult TodayCompletedOrders(int? count = 10)
        {
            return Ok(_orderService.TodayCompletedOrders(count!.Value));
        }

        [HttpPut("Complete/{id}")]
        public IActionResult CompleteOrders(Guid id)
        {
            return Ok(_orderService.SetCompletedOrder(id));
        }

        [HttpPut("UnComplete/{id}")]
        public IActionResult UnCompleteOrders(Guid id)
        {
            return Ok(_orderService.SetUnCompletedOrder(id));
        }
    }
}
