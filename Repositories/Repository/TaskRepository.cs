using AutoMapper;
using Domain;
using Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class TaskRepository : ITaskRepository
    {
        protected readonly DSMDbContext _dbcontext;
        protected readonly IMapper _mapper;
        public TaskRepository(DSMDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.Task> Add(Domain.Entities.Task task)
        {
            await _dbcontext.Tasks.AddAsync(task);
            await _dbcontext.SaveChangesAsync();
            return task;
        }

        public async void Delete(Domain.Entities.Task task)
        {
            _dbcontext.Remove(task);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Domain.Entities.Task> GetTaskById(Guid id)
        {
            var task = await _dbcontext.Tasks.FindAsync(id);
            if(task == null)
            {
                throw new Exception("Task does not exist");
            }
            return task;
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetTasks()
        {
            var tasks = await _dbcontext.Tasks.Include(x => x.Client.Identiti.Address).ToListAsync();
            return tasks;
        }

        public async void Update(Domain.Entities.Task task)
        {
            var extask = await _dbcontext.Tasks.FindAsync(task.Id);
            if (extask == null)
            {
                throw new Exception("Task does not exist");
            }
            _mapper.Map(task, extask);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
