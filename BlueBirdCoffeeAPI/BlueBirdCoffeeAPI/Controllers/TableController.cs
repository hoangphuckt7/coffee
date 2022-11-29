using Data.Cache;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        public IActionResult Add(TableAddModel model)
        {
            return Ok(_tableService.Add(model));
        }

        [HttpPut("UpdateOrAdd")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        public IActionResult Update(List<TableUpdateModel> model)
        {
            return Ok(_tableService.UpdateOrAdd(model));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.ADMIN)]
        [HttpPut("Remove")]
        public IActionResult Delete(List<Guid> ids)
        {
            return Ok(_tableService.Delete(ids));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
        [HttpPut("Change/{oldTableId}/{newTableId}")]
        public async Task<IActionResult> Change(Guid oldTableId, Guid newTableId)
        {
            return Ok(await _tableService.ChangeTable(oldTableId, newTableId));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = SystemRoles.EXCEPT_CUSTOMER)]
        [HttpPut("ChangeOrders")]
        public async Task<IActionResult> ChangeOrdersTable(ChangeOrdersTable model)
        {
            return Ok(await _tableService.ChangeOrdersTable(model.OrderIds, model.NewTableId));
        }
    }
}
