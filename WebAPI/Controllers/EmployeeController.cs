using Aplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost("TakeTask")]
        public async Task<ActionResult> TakeTask([FromQuery] Guid taskId, [FromQuery] Guid userId)
        {
            await _employeeService.TakeTask(taskId, userId);
            return Ok();
        }
    }
}
