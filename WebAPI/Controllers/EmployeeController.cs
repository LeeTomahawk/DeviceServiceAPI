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
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllEmployee()
        {
            var employees = await _employeeService.GetAllEmployees();
            return Ok(employees);
        }
        [HttpGet("EmployeeTasks/{userid}")]
        public async Task<ActionResult<EmployeeDto>> GetAllEmployeeTasks([FromRoute] Guid userid)
        {
            var tasks = await _employeeService.GetAllEmployeesTasks(userid);
            return Ok(tasks);
        }
    }
}
