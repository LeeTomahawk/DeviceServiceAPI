using Repositories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Domain.Entities.Task>> GetTasks();
        Task<Domain.Entities.Task> GetTaskById(Guid id);
        Task<Domain.Entities.Task> Add(Domain.Entities.Task task);
        Task Update(TaskUpdateDto task);
        Task Delete(Domain.Entities.Task task);
    }
}
