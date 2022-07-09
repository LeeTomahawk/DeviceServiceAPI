using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ICompletedTaskRepository
    {
        Task<IEnumerable<CompletedTask>> GetCompletedTasks();
        Task<CompletedTask> Add(CompletedTask task);
        Task<CompletedTask> GetCompletedTaskById(Guid id);
        void Update(CompletedTask completedTask);
        void Delete(CompletedTask completedTask);
    }
}
