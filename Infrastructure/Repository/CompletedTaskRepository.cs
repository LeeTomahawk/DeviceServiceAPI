using AutoMapper;
using Domain;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CompletedTaskRepository : ICompletedTaskRepository
    {
        protected readonly DSMDbContext _dbcontext;
        protected readonly IMapper _mapper;

        public CompletedTaskRepository(DSMDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public async Task<CompletedTask> Add(CompletedTask task)
        {
            await _dbcontext.Set<CompletedTask>().AddAsync(task);
            await _dbcontext.SaveChangesAsync();
            return task;
        }

        public async void Delete(CompletedTask completedTask)
        {
            _dbcontext.Remove(completedTask);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<CompletedTask> GetCompletedTaskById(Guid id)
        {
            var completedtask = await _dbcontext.Set<CompletedTask>().FindAsync(id);
            if(completedtask == null)
            {
                throw new Exception("CompltetedTask does not exist");
            }
            return completedtask;

        }

        public async Task<IEnumerable<CompletedTask>> GetCompletedTasks()
        {
            var completedtasks = await _dbcontext.Set<CompletedTask>().ToListAsync();
            return completedtasks;
        }

        public async void Update(CompletedTask completedTask)
        {
            var excompletedtask = await _dbcontext.Set<CompletedTask>().FindAsync(completedTask.Id);
            if (excompletedtask == null)
            {
                throw new Exception("CompltetedTask does not exist");
            }
            _mapper.Map(completedTask, excompletedtask);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
