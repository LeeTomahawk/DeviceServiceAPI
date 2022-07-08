using Domain;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly DSMDbContext _dbcontext;
        public EmployeeRepository(DSMDbContext dSMDbContext)
        {
            _dbcontext = dSMDbContext;
        }
        public async Task<Employee> Add(Employee employee)
        {
            await _dbcontext.Set<Employee>().AddAsync(employee);
            await _dbcontext.SaveChangesAsync();
            return employee;
        }

        public async void Delete(Employee employee)
        {
            _dbcontext.Remove(employee);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeById(Guid id)
        {
            var employee = await _dbcontext.Set<Employee>().FindAsync(id);
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _dbcontext.Set<Employee>().ToListAsync();
            return employees;
        }

        public async void Update(Employee employee)
        {
            var exemployee = await _dbcontext.Set<Employee>().FindAsync(employee.Id);
            if( exemployee == null)
            {
                throw new Exception("Employee does not exist");
            }
        }

    }
}
