﻿using Repositories.Dtos;
using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkplaceController : ControllerBase
    {
        private readonly IWorkplaceService _service;
        public WorkplaceController(IWorkplaceService service)
        {
            _service = service;
        }

        // GET: api/<WorplaceController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkplaceDto>>> GetAll()
        {
            var workplaces = await _service.GetWorkplaces();
            return Ok(workplaces);
        }

        // GET api/<WorplaceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkplaceDto>> Get([FromRoute] Guid id)
        {
            var workplace = await _service.GetWorkPlaceById(id);
            return Ok(workplace);
        }

        // POST api/<WorplaceController>
        [HttpPost]
        public async Task<ActionResult<WorkplaceCreateDto>> Add([FromBody] WorkplaceCreateDto workplace)
        {
            var cworkplace = await _service.AddWorkplace(workplace);
            return Ok(cworkplace);
        }

        // PUT api/<WorplaceController>/5
        [HttpPut]
        public async Task<ActionResult<WorkplaceCreateDto>> Put([FromBody] WorkplaceUpdateDto workplace)
        {
            await _service.UpdateWorkplace(workplace);
            return NoContent();
        }

        // DELETE api/<WorplaceController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _service.DeleteWorkplace(id);
            return Ok();
        }

        [HttpPost("~/api/Workplace/AddEquipment")]
        public async Task<ActionResult> AddEquipment([FromQuery] Guid workplaceId, [FromQuery] Guid equipmentId)
        {
            await _service.AddWorkplaceEquipment(workplaceId, equipmentId);
            return Ok();
        }

        [HttpDelete("~/api/Workplace/DeleteEquipment/{id}")]
        public async Task<ActionResult> DeleteEquipment([FromRoute] Guid id)
        {
            await _service.DeleteWorkplaceEquipment(id);
            return Ok();
        }

        [HttpPost("WokrplaceAddEmployee")]
        public async Task<ActionResult> WokrplaceAddEmployee([FromQuery] Guid workplaceId, Guid employeeId)
        {
            await _service.AddEmployee(workplaceId, employeeId);
            return Ok();
        }
    }
}
