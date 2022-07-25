using AutoMapper;
using Domain;
using Domain.Entities;
using Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Exceptions;

namespace Repositories.Repository
{
    public class TaskDetailRepository : ITaskDetailRepository
    {
        protected readonly DSMDbContext _dbcontext;
        protected readonly IMapper _mapper;

        public TaskDetailRepository(DSMDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public async Task<TaskDetails> Add(TaskDetails task)
        {
            await _dbcontext.TaskDetails.AddAsync(task);
            await _dbcontext.SaveChangesAsync();
            return task;
        }

        public async void Delete(TaskDetails completedTask)
        {
            _dbcontext.Remove(completedTask);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<TaskDetails> GetCompletedTaskById(Guid id)
        {
            var completedtask = await _dbcontext.TaskDetails.FindAsync(id);
            if(completedtask == null)
            {
                throw new NotFoundException("TaskDetails does not exist");
            }
            return completedtask;

        }

        public async Task<IEnumerable<TaskDetails>> GetCompletedTasks()
        {
            var completedtasks = await _dbcontext.TaskDetails.ToListAsync();
            return completedtasks;
        }

        public async void Update(TaskDetails completedTask)
        {
            var excompletedtask = await _dbcontext.TaskDetails.FindAsync(completedTask.Id);
            if (excompletedtask == null)
            {
                throw new NotFoundException("CompltetedTask does not exist");
            }
            _mapper.Map(completedTask, excompletedtask);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
