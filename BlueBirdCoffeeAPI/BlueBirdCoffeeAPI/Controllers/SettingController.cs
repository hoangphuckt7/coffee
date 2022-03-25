using Data.Cache;
using Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace BlueBirdCoffeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpGet]
        public IActionResult Get(string? key)
        {
            return Ok(_settingService.GetKeys(key));
        }

        [HttpPost]
        public IActionResult Add([FromBody] List<PairModel> models)
        {
            return Ok(_settingService.AddSetting(models));
        }

        [HttpPut("{key}")]
        public IActionResult Update(string key, [FromBody] StringModel model)
        {
            return Ok(_settingService.UpdateSetting(key, model));
        }

        [HttpDelete("{key}")]
        public IActionResult Delete(string key)
        {
            return Ok(_settingService.RemoveSetting(key));
        }
    }
}
