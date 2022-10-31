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
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet("Check")]
        public IActionResult Check(string coupon, double total)
        {
            return Ok(_couponService.CheckCoupon(coupon, total));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
        [HttpGet("Default")]
        public IActionResult GetDefault()
        {
            return Ok(_couponService.GetDefault());
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        [HttpGet]
        public IActionResult GetAll(string? searchValue)
        {
            return Ok(_couponService.Get(searchValue));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        [HttpPost]
        public IActionResult Add([FromBody] CouponAddModel model)
        {
            return Ok(_couponService.Add(model));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] CouponAddModel model)
        {
            return Ok(_couponService.Update(id, model));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_couponService.Delete(id));
        }
    }
}
