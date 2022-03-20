using Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace BlueBirdCoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get(Guid? id)
        {
            return Ok(_categoryService.Get(id));
        }

        [HttpPost]
        public IActionResult Add(DescriptionModel model)
        {
            return Ok(_categoryService.Add(model));
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, DescriptionModel model)
        {
            return Ok(_categoryService.Update(id, model));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_categoryService.Delete(id));
        }
    }
}
