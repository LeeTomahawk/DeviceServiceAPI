using Aplication.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAllTasks();
        Task<TaskDto> GetTaskById(Guid id);
        Task<TaskCreateDto> AddTask(TaskCreateDto task);
        Task DeleteTask(Guid id);
        Task UpdateTask(TaskDto task);
    }
}
