using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ITaskDetailRepository
    {
        Task<IEnumerable<TaskDetails>> GetCompletedTasks();
        Task<TaskDetails> Add(TaskDetails task);
        Task<TaskDetails> GetCompletedTaskById(Guid id);
        void Update(TaskDetails completedTask);
        void Delete(TaskDetails completedTask);
    }
}
