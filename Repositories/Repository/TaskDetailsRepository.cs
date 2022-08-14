using AutoMapper;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Exceptions;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class TaskDetailsRepository : ITaskDetailsRepository
    {
        protected readonly DSMDbContext _dbcontext;
        protected readonly IMapper _mapper;
        public TaskDetailsRepository(DSMDbContext dSMDbContext, IMapper mapper)
        {
            _dbcontext = dSMDbContext;
            _mapper = mapper;
        }
        public async Task<TaskDetails> Add(TaskDetails taskDetails)
        {
            await _dbcontext.TaskDetails.AddAsync(taskDetails);
            await _dbcontext.SaveChangesAsync();
            return taskDetails;
        }

        public async void Delete(TaskDetails taskDetails)
        {
            _dbcontext.Remove(taskDetails);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskDetails>> GetTaskDetails()
        {
            var tasks = await _dbcontext.TaskDetails.ToListAsync();
            return tasks;
        }

        public async Task<TaskDetails> GetTaskDetails(Guid id)
        {
            var task = await _dbcontext.TaskDetails.FindAsync(id);
            if (task == null)
                throw new NotFoundException("TaskDetails not found");
            return task;
        }

        public async void Update(TaskDetails taskDetails)
        {
            var extask = await _dbcontext.TaskDetails.FindAsync(taskDetails.Id);
            if (extask == null)
                throw new NotFoundException("TaskDetails not found");
            _mapper.Map(taskDetails, extask);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
