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
        Task<EmployeeDto> GetEmployee(Guid id);
        Task<PageResult<EmployeeDto>> GetAllEmployees(PageableModel query);
        Task<EmployeeDto> GetAllEmployeesTasks(Guid userId);
        Task<IEnumerable<EmployeeDto>> GetEmployeesWithoutWokrplace();
        Task<IEnumerable<EmployeeDto>> GetEmployeesWithWorkplace(Guid id);
    }
}
