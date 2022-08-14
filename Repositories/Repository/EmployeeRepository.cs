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
using Repositories.Exceptions;

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
            var employee = await _dbcontext.Employees.Include(i => i.Tasks).Include(x => x.Identiti.Address).FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
                throw new NotFoundException("Employee does not exist");
            return employee;
        }

        public async Task<Employee> GetEmployeeByUserId(Guid userId)
        {
            var user = await _dbcontext.Users.Include(x => x.Identiti).FirstOrDefaultAsync(x => x.Id == userId);
            var employee = await _dbcontext.Employees.FirstOrDefaultAsync(x => x.IdentitiId == user.IdentitiId);
            if(user == null || employee == null)
                throw new NotFoundException("Employee not found");
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _dbcontext.Employees.Include(i => i.Tasks).Include(x => x.Identiti.Address).ToListAsync();
            return employees;
        }

        public async void Update(Employee employee)
        {
            var exemployee = await _dbcontext.Employees.FindAsync(employee.Id);
            if( exemployee == null)
                throw new NotFoundException("Employee does not exist");
            _mapper.Map(employee, exemployee);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<Domain.Entities.Employee> GetAllEmployeeTasks(Guid id)
        {
            var employee = await _dbcontext.Employees.Include(i => i.Identiti.Address).Include(w => w.Tasks).ThenInclude(w => w.Task.Client.Identiti.Address).FirstOrDefaultAsync(x => x.Id == id);
            if(employee == null)
                throw new NotFoundException("Employee does not exist");
            return employee;
        }
    }
}
