﻿using Repositories.Dtos;
using Aplication.Interfaces;
using AutoMapper;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Aplication.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public TaskService(ITaskRepository repository, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }
        public async Task<TaskCreateDto> AddTask(TaskCreateDto taskdto)
        {
            var task = _mapper.Map<Domain.Entities.Task>(taskdto);
            await _repository.Add(task);
            return taskdto;
        }

        public async System.Threading.Tasks.Task DeleteTask(Guid id)
        {
            var task = await _repository.GetTaskById(id);
            await _repository.Delete(task);
        }

        public async Task<IEnumerable<TaskDto>> GetAllClientTasks(Guid id)
        {
            var tasks = await _repository.GetAllClientTasks(id);
            var taskdto = _mapper.Map<IEnumerable<TaskDto>>(tasks);
            return taskdto;
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasks()
        {
            var tasks = await _repository.GetTasks();
            var tasksdto = _mapper.Map<IEnumerable<TaskDto>>(tasks);
            return tasksdto;
        }


        public async Task<IEnumerable<TaskDto>> GetAllTasksBetweenDates(DateTime startDate, DateTime endDate)
        {
            var tasks = await _repository.GetTasksQuery($"SELECT * FROM Tasks Where startDate BETWEEN '{startDate.ToString("yyyy-MM-dd hh:mm:ss")}' AND '{endDate.ToString("yyyy-MM-dd hh:mm:ss")}'");
            var taskdto = _mapper.Map<IEnumerable<TaskDto>>(tasks);
            return taskdto;
        }

        public async Task<IEnumerable<TaskEmployeeDto>> GetToAproveTasks()
        {
            var tasks = await _repository.GetTaskEmployees();
            var tasksdto = _mapper.Map<IEnumerable<TaskEmployeeDto>>(tasks);
            return tasksdto;
        }

        public async Task<IEnumerable<TaskDto>> GetAvailableTasks()
        {
            var tasks = await _repository.GetTasksQuery("SELECT * FROM Tasks Where taskStatus=0 OR taskStatus=3");
            var tasksdto = _mapper.Map<IEnumerable<TaskDto>>(tasks);
            return tasksdto;
        }

        public async Task<TaskDto> GetTaskById(Guid id)
        {
            var task = await _repository.GetTaskById(id);
            var taskdto = _mapper.Map<TaskDto>(task);
            return taskdto;
        }

        public async System.Threading.Tasks.Task UpdateTask(TaskUpdateDto task)
        {
            await _repository.Update(task);
        }

        public async System.Threading.Tasks.Task EndTask(Guid taskId)
        {
            await _repository.EndTask(taskId);
        }
    }
}
