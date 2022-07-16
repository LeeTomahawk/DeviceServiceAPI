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

        public Task DeleteTask(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskDto>> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public Task<TaskDto> GetTaskById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTask(TaskDto task)
        {
            throw new NotImplementedException();
        }
    }
}
