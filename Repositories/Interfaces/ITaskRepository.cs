using Domain.Entities;
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
        Task<IEnumerable<Domain.Entities.Task>> GetAllClientTasks(Guid id);
        Task<Domain.Entities.Task> GetTaskById(Guid id);
        Task<Domain.Entities.Task> Add(Domain.Entities.Task task);
        System.Threading.Tasks.Task Update(TaskUpdateDto task);
        System.Threading.Tasks.Task Delete(Domain.Entities.Task task);
        Task<IEnumerable<Domain.Entities.Task>> GetTasksQuery(string query);
        System.Threading.Tasks.Task UpdateTaskEmployee(Domain.Entities.Task task, Employee employee);
    }
}
