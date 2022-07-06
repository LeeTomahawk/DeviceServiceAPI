using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Domain.Entities.Task;


namespace Domain.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetTasks();
        Task GetTaskById(Guid id);
        Task Add(Task task);
        void Update(Task task);
        void Delete(Task task);
    }
}
