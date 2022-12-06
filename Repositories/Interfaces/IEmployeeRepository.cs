using Domain.Entities;
using Repositories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<PageResult<EmployeeDto>> GetEmployees(PageableModel query);
        Task<Employee> GetEmployeeById(Guid id);
        Task<Employee> GetEmployeeByUserId(Guid userId);
        Task<Employee> GetAllEmployeeTasks(Guid id);
        Task<Employee> Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        Task<IEnumerable<Employee>> GetEmployeeListWithoutWorkplace();
        Task<IEnumerable<Employee>> GetEmployeeWithWorkplace(Guid id);
    }
}
