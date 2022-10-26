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
    public class FloorController : ControllerBase
    {
        private readonly IFloorService _floorService;

        public FloorController(IFloorService floorService)
        {
            _floorService = floorService;
        }

        [HttpGet]
        public IActionResult Get(Guid? id)
        {
            return Ok(_floorService.Get(id));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        [HttpPost]
        public IActionResult Add(DescriptionModel model)
        {
            return Ok(_floorService.Add(model));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, DescriptionModel model)
        {
            return Ok(_floorService.Update(id, model));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_floorService.Delete(id));
        }
    }
}
