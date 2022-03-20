using Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

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
        [Consumes("multipart/form-data")]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public IActionResult Add([FromForm] ItemAddModel model)
        {
            return Ok(_itemService.Add(model));
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public IActionResult Update(Guid id, [FromForm] ItemAddModel model)
        {
            return Ok(_itemService.Update(id, model));
        }

        [HttpDelete("{id}")]
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

        [HttpPut("Image/{itemId}")]
        [Consumes("multipart/form-data")]
        public IActionResult AddImages(Guid itemId, [FromForm] List<IFormFile> images)
        {
            return Ok(_itemService.AddImages(itemId, images));
        }

        [HttpDelete("Image/{imageId}")]
        public IActionResult RemoveImage(Guid imageId)
        {
            return Ok(_itemService.RemoveImage(imageId));
        }
    }
}
