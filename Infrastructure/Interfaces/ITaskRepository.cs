using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Domain.Entities.Task;


namespace Infrastructure.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Task>> GetTasks();
        Task<Task> GetTaskById(Guid id);
        Task<Task> Add(Task task);
        void Update(Task task);
        void Delete(Task task);
    }
}
