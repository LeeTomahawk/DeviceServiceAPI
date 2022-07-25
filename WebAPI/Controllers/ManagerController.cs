using Aplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }
        [HttpPost("AddTaskToEmployee")]
        public async Task<ActionResult> AddTaskToEmployee([FromQuery] Guid taskId, [FromQuery] Guid employeeId)
        {
            return Ok();
        }
    }
}
