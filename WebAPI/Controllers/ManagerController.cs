﻿using Aplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Dtos;

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
        [HttpPost("TaskAprove")]
        public async Task<ActionResult> TaskAprove([FromQuery] Guid taskId)
        {
            await _managerService.TaskAprove(taskId);
            return Ok();
        }
        [HttpPost("AddTaskToEmployee")]
        public async Task<ActionResult> AddTaskToEmployee([FromQuery] Guid taskId, [FromQuery] Guid employeeId)
        {
            await _managerService.AddTaskToEmployee(taskId, employeeId);
            return Ok();
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<ManagerDto>> GetManagerByUserId([FromRoute] Guid userId)
        {
            var manager = await _managerService.GetManager(userId);
            return Ok(manager);
        }
        [HttpGet]
        public async Task<ActionResult<PageResult<ManagerDto>>> GetAllMenagers([FromQuery] PageableModel query)
        {
            var managers = await _managerService.GetAllManager(query);
            return Ok(managers);
        }
    }
}
