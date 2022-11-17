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
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult Get(Guid? id, string? name, Guid? categoryId)
        {
            return Ok(_itemService.Search(id, name, categoryId));
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        [Consumes("multipart/form-data")]
        public IActionResult Add([FromForm] ItemAddModel model)
        {
            return Ok(_itemService.Add(model));
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        public IActionResult Update(Guid id, [FromBody] ItemUpdateModel model)
        {
            return Ok(_itemService.Update(id, model));
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        public IActionResult Delete(Guid id)
        {
            return Ok(_itemService.Delete(id));
        }

        [HttpGet("Image/{imageId}")]
        public IActionResult GetImage(Guid imageId)
        {
            var rs = _itemService.GetItemImage(imageId);
            return File(rs.Data, rs.FileType);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        [HttpPut("Image/{itemId}")]
        [Consumes("multipart/form-data")]
        public IActionResult AddImages(Guid itemId, [FromForm] ItemImageUpdateModel images)
        {
            return Ok(_itemService.AddImages(itemId, images.Images));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        [HttpDelete("Image/{imageId}")]
        public IActionResult RemoveImage(Guid imageId)
        {
            return Ok(_itemService.RemoveImage(imageId));
        }
    }
}
