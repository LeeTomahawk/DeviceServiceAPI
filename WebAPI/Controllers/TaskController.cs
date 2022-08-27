using Repositories.Dtos;
using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;
        public TaskController(ITaskService service)
        {
            _service = service;
        }

        // GET: api/<TaskController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> Get()
        {
            var tasks = await _service.GetAllTasks();
            return Ok(tasks);
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> Get([FromRoute] Guid id)
        {
            var task = await _service.GetTaskById(id);
            return Ok(task);
        }

        // POST api/<TaskController>
        [HttpPost]
        public async Task<ActionResult<TaskCreateDto>> Post([FromBody] TaskCreateDto taskdto)
        {
            var task = await _service.AddTask(taskdto);
            return Ok(task);
        }

        // PUT api/<TaskController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] TaskUpdateDto task)
        {
            await _service.UpdateTask(task);
            return NoContent();
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _service.DeleteTask(id);
            return Ok();
        }
        [HttpGet("GetToAproveTasks")]
        public async Task<ActionResult<IEnumerable<TaskEmployeeDto>>> GetToAproveTasks()
        {
            var tasks = await _service.GetToAproveTasks();
            return Ok(tasks);
        }
        [HttpGet("GetAvailableTasks")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetAvailableTasks()
        {
            var tasks = await _service.GetAvailableTasks();
            return Ok(tasks);
        }
        [HttpGet("GetTasksBetweenDates")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasksBetweenDate(DateTime startDate, DateTime endDate)
        {
            var tasks = await _service.GetAllTasksBetweenDates(startDate, endDate);
            return Ok(tasks);
        }
        [HttpGet("client/{clientId}")]
        public async Task<ActionResult<TaskDto>> GetClientTasks([FromRoute] Guid clientId)
        {
            var tasks = await _service.GetAllClientTasks(clientId);
            return Ok(tasks);
        }
        [HttpPost("EndTask")]
        public async Task<ActionResult> EndTask([FromQuery] Guid taskId)
        {
            await _service.EndTask(taskId);
            return Ok();
        }
    }
}
