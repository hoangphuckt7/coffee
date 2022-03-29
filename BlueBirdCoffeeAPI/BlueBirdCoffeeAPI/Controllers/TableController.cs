using Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace BlueBirdCoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        public IActionResult Get(Guid? id, Guid? floorId)
        {
            return Ok(_tableService.Get(id, floorId));
        }

        [HttpPost]
        public IActionResult Add(TableAddModel model)
        {
            return Ok(_tableService.Add(model));
        }

        [HttpPut("UpdateOrAdd")]
        public IActionResult Update(List<TableUpdateModel> model)
        {
            return Ok(_tableService.UpdateOrAdd(model));
        }

        [HttpPut("Remove")]
        public IActionResult Delete(List<Guid> ids)
        {
            return Ok(_tableService.Delete(ids));
        }
    }
}
