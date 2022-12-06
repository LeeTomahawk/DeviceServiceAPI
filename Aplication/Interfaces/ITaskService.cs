using Repositories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface ITaskService
    {
        Task<PageResult<TaskDto>> GetAllTasks(PageableModel query);
        Task<IEnumerable<TaskDto>> GetAllClientTasks(Guid id);
        Task<PageResult<TaskDto>> GetAvailableTasks(PageableModel query);
        Task<PageResult<TaskEmployeeDto>> GetToAproveTasks(PageableModel query);
        Task<IEnumerable<TaskDto>> GetAllTasksBetweenDates(DateTime startDate, DateTime endDate);
        Task<TaskDto> GetTaskById(Guid id);
        Task<TaskCreateDto> AddTask(TaskCreateDto task);
        Task DeleteTask(Guid id);
        Task UpdateTask(TaskUpdateDto task);
        Task EndTask(Guid taskId);
    }
}
