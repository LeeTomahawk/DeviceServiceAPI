using Repositories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface IManagerService
    {
        Task AddTaskToEmployee(Guid taskId, Guid employeeId);
        Task TaskAprove(Guid taskId);
        Task<ManagerDto> GetManager(Guid userId);
        Task<PageResult<ManagerDto>> GetAllManager(PageableModel query);
    }
}
