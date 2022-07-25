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
        Task<IEnumerable<TaskDto>> GetAllTasks();
        Task<IEnumerable<TaskDto>> GetAvailableTasks();
        Task<IEnumerable<TaskDto>> GetAllTasksBetweenDates(DateTime startDate, DateTime endDate);
        Task<TaskCreateDetailDto> AddTaskDetails(TaskCreateDetailDto taskDetailDto);
        Task<TaskDto> GetTaskById(Guid id);
        Task<TaskCreateDto> AddTask(TaskCreateDto task);
        Task DeleteTask(Guid id);
        Task UpdateTask(TaskUpdateDto task);
        Task PickTask(Guid taskId, Guid employeeId);
    }
}
