using AutoMapper;
using Domain;
using Domain.Entities;
using Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly DSMDbContext _dbcontext;
        protected readonly IMapper _mapper;
        public EmployeeRepository(DSMDbContext dSMDbContext, IMapper mapper)
        {
            _dbcontext = dSMDbContext;
            _mapper = mapper;
        }
        public async Task<Employee> Add(Employee employee)
        {
            await _dbcontext.Employees.AddAsync(employee);
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
            var employee = await _dbcontext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee does not exist");
            }
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _dbcontext.Employees.ToListAsync();
            return employees;
        }

        public async void Update(Employee employee)
        {
            var exemployee = await _dbcontext.Employees.FindAsync(employee.Id);
            if( exemployee == null)
            {
                throw new Exception("Employee does not exist");
            }
            _mapper.Map(employee, exemployee);
            await _dbcontext.SaveChangesAsync();
        }

    }
}
