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
using Repositories.Dtos;
using System.Linq.Expressions;

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

        public async Task<PageResult<EmployeeDto>> GetEmployees(PageableModel query)
        {
            var baseQuery = _dbcontext
                .Employees
                .Include(i => i.Tasks)
                .Include(x => x.Identiti.Address)
                .Where(r => query.SearchPharse == null || (r.Identiti.FirstName.ToLower().Contains(query.SearchPharse)
                                                     || r.Identiti.LastName.ToLower().Contains(query.SearchPharse)
                                                     || r.Identiti.PhoneNumber.ToLower().Contains(query.SearchPharse)));
            if(!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<Employee, object>>>
                {
                    {nameof(Employee.Identiti.FirstName), r => r.Identiti.FirstName },
                    {nameof(Employee.Identiti.LastName), r => r.Identiti.LastName },
                    {nameof(Employee.Identiti.PhoneNumber), r => r.Identiti.PhoneNumber },
                };

                var selectedColumn = columnsSelectors[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC ?
                    baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var employees = await baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToListAsync();

            var employeesdto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            foreach (var em in employeesdto)
            {
                em.TaskCount = em.Tasks.Count();
            }

            var result = new PageResult<EmployeeDto>(employeesdto, baseQuery.Count());

            return result;
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

        public async Task<IEnumerable<Employee>> GetEmployeeListWithoutWorkplace()
        {
            var employees = await _dbcontext.Employees.Include(x => x.Identiti.Address).Where(r => r.WorkplaceId == null).ToListAsync();
            if (employees == null)
                throw new NotFoundException("Employee does not exist");
            return employees;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeWithWorkplace(Guid id)
        {
            var employees = await _dbcontext.Employees.Include(x => x.Identiti.Address).Where(r => r.WorkplaceId == id).ToListAsync();
            if (employees == null)
                throw new NotFoundException("Employee does not exist");
            return employees;
        }
    }
}
