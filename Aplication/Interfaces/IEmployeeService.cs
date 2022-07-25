using Repositories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface IEmployeeService
    {
        Task TakeTask(Guid taskId, Guid userId);
        Task<EmployeeDto> GetEmployee(Guid id);
    }
}
