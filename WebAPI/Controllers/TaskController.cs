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

        [HttpGet("~/api/Task/GetAvailableTasks")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetAvailableTasks()
        {
            var tasks = await _service.GetAllTasks("SELECT * FROM Tasks Where taskStatus=0 OR taskStatus=3");
            return Ok(tasks);
        }
        [HttpGet("~/api/Task/GetTasksBetweenDate")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasksBetweenDate(string startDate, string endDate)
        {
            var tasks = await _service.GetAllTasks($"SELECT * FROM Tasks Where startDate BETWEEN '{startDate}' AND '{endDate}'");
            return Ok(tasks);
        }

    }
}
