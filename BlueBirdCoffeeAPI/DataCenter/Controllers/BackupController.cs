using DataCenter.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackupController : ControllerBase
    {
        private readonly IBackupService _backupService;

        public BackupController(IBackupService backupService)
        {
            _backupService = backupService;
        }

        [HttpGet]
        public IActionResult Backup()
        {
            return Ok(_backupService.BackupAllData());
        }

        [HttpGet("LastBackupDate")]
        public IActionResult LastBackupDate()
        {
            return Ok(_backupService.LastBackupDate());
        }
    }
}
