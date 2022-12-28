using DataCenter.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestoreController : ControllerBase
    {
        private readonly IRestoreService _restoreService;

        public RestoreController(IRestoreService restoreService)
        {
            _restoreService = restoreService;
        }

        [HttpGet("ClearAndRestore")]
        public IActionResult ClearAndRestore()
        {
            return Ok(_restoreService.RestoreFromMongo());
        }
    }
}
