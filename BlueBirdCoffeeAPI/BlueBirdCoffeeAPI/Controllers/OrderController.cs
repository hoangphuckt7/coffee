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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateModel model)
        {
            return Ok(await _orderService.CreateOrder(User.GetId(), model));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
        [HttpGet("Table/{id}")]
        public IActionResult GetByTable(Guid id)
        {
            return Ok(_orderService.GetByTable(id));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
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

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
        [HttpGet("CurrentOrders")]
        public IActionResult CurrentOrders()
        {
            return Ok(_orderService.GetCurrentOrders());
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
        [HttpGet("TodayCompletedOrders")]
        public IActionResult TodayCompletedOrders(int? count = 10)
        {
            return Ok(_orderService.TodayCompletedOrders(count!.Value));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
        [HttpGet("BartenderOrders")]
        public IActionResult GetBartenderOrders(int? count = 10)
        {
            return Ok(_orderService.GetBartenderOrders(count!.Value));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
        [HttpPut("Complete/{id}")]
        public IActionResult CompleteOrders(Guid id)
        {
            return Ok(_orderService.SetCompletedOrder(id));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
        [HttpPut("UnComplete/{id}")]
        public IActionResult UnCompleteOrders(Guid id)
        {
            return Ok(_orderService.SetUnCompletedOrder(id));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
        [HttpDelete("MissingOrders")]
        public IActionResult RemoveMissingOrders()
        {
            _orderService.RemoveMissingOrders();
            return Ok();
        }
    }
}
