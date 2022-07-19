using Repositories.Dtos;
using Aplication.Interfaces;
using AutoMapper;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<TaskCreateDto> AddTask(TaskCreateDto taskdto)
        {
            var task = _mapper.Map<Domain.Entities.Task>(taskdto);
            await _repository.Add(task);
            return taskdto;
        }

        public async Task DeleteTask(Guid id)
        {
            var task = await _repository.GetTaskById(id);
            await _repository.Delete(task);
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasks()
        {
            var tasks = await _repository.GetTasks();
            var tasksdto = _mapper.Map<IEnumerable<TaskDto>>(tasks);
            return tasksdto;
        }

        public async Task<TaskDto> GetTaskById(Guid id)
        {
            var task = await _repository.GetTaskById(id);
            var taskdto = _mapper.Map<TaskDto>(task);
            return taskdto;
        }

        public async Task UpdateTask(TaskUpdateDto task)
        {
            await _repository.Update(task);
        }
    }
}
