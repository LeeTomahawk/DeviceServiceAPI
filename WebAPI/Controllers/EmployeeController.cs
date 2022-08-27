using Aplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Dtos;

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
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee([FromRoute] Guid id)
        {
            var employee = await _employeeService.GetEmployee(id);
            return Ok(employee);
        }
        [HttpGet]
        public async Task<ActionResult<PageResult<EmployeeDto>>> GetAllEmployee([FromQuery] PageableModel query)
        {
            var employees = await _employeeService.GetAllEmployees(query);
            return Ok(employees);
        }
        [HttpGet("Tasks/{userid}")]
        public async Task<ActionResult<EmployeeDto>> GetAllEmployeeTasks([FromRoute] Guid userid)
        {
            var tasks = await _employeeService.GetAllEmployeesTasks(userid);
            return Ok(tasks);
        }
    }
}
