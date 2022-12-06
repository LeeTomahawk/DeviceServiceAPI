using AutoMapper;
using Domain;
using Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Dtos;
using Repositories.Exceptions;
using Domain.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Repositories.Repository
{
    public class TaskRepository : ITaskRepository
    {
        protected readonly DSMDbContext _dbcontext;
        protected readonly IMapper _mapper;
        public TaskRepository(DSMDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.Task> Add(Domain.Entities.Task task)
        {
            await _dbcontext.Tasks.AddAsync(task);
            var client = await _dbcontext.Clients.FindAsync(task.ClientId);
            client.LastVisit = DateTime.Now;
            await _dbcontext.SaveChangesAsync();
            return task;
        }

        public async System.Threading.Tasks.Task Delete(Domain.Entities.Task task)
        {
            _dbcontext.Remove(task);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Domain.Entities.Task> GetTaskById(Guid id)
        {
            var task = await _dbcontext.Tasks.Include(x => x.Client.Identiti.Address).FirstOrDefaultAsync(x => x.Id == id);
            if(task == null)
                throw new NotFoundException("Task does not exist");
            return task;
        }

        public async Task<PageResult<TaskDto>> GetTasks(PageableModel query)
        {
            var baseQuery = _dbcontext.Tasks
                .Include(w => w.Client.Identiti.Address)
                .Where(r => query.SearchPharse == null || (r.Name.ToLower().Contains(query.SearchPharse)
                                                    || r.Description.ToLower().Contains(query.SearchPharse)
                                                    || r.Activities.ToLower().Contains(query.SearchPharse)
                                                    || r.startDate.ToString().ToLower().Contains(query.SearchPharse)
                                                    || r.Client.Identiti.FirstName.ToLower().Contains(query.SearchPharse)
                                                    || r.Client.Identiti.LastName.ToLower().Contains(query.SearchPharse)
                                                    || r.Client.Identiti.PhoneNumber.ToLower().Contains(query.SearchPharse)));
            if (baseQuery == null)
                throw new NotFoundException("Tasks not found");

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<Domain.Entities.Task, object>>>
                {
                    {nameof(Domain.Entities.Task.Name), r => r.Name },
                    {nameof(Domain.Entities.Task.TaskStatus), r => r.TaskStatus },
                    {nameof(Domain.Entities.Task.startDate), r => r.startDate },
                };

                var selectedColumn = columnsSelectors[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC ?
                    baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var tasks = await baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToListAsync();

            var tasksdto = _mapper.Map<IEnumerable<TaskDto>>(tasks);

            var result = new PageResult<TaskDto>(tasksdto, baseQuery.Count());

            return result;
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetTasksQuery(string query)
        {
            var tasks = await _dbcontext.Tasks.FromSqlRaw(query).Include(x => x.Client.Identiti.Address).ToListAsync();
            return tasks;
        }

        public async System.Threading.Tasks.Task UpdateTaskEmployee(Domain.Entities.Task task, Employee employee)
        {
            var te = new TaskEmployee
            {
                EmployeeId = employee.Id,
                TaskId = task.Id,
                TaskDetailStatus = TaskDetailStatus.DURING,
                TakeTaskDate = DateTime.Now,
            };
            task.TaskStatus = TaskStatus.IN_REPAIR;
            await _dbcontext.TaskEmployees.AddAsync(te);
            await _dbcontext.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task Update(TaskUpdateDto task)
        {
            var extask = await _dbcontext.Tasks.FindAsync(task.Id);
            if (extask == null)
                throw new NotFoundException("Task does not exist");
            _mapper.Map(task, extask);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetAllClientTasks(Guid id)
        {
            var tasks = await _dbcontext.Tasks.Where(w => w.ClientId == id).OrderByDescending(w => w.startDate).ToListAsync();
            return tasks;
        }

        public async System.Threading.Tasks.Task UpdateTaskEmployee(Guid taskId)
        {
            var employeeTask = await _dbcontext.TaskEmployees.FindAsync(taskId);
            var task = await _dbcontext.Tasks.FindAsync(employeeTask.TaskId);
            if (employeeTask == null || task == null)
                throw new NotFoundException("Task does not exist");
            employeeTask.TaskDetailStatus = TaskDetailStatus.DONE;
            employeeTask.DoneTaskDate = DateTime.Now;
            task.endDate = DateTime.Now;
            task.TaskStatus = TaskStatus.WAITING_FOR_CLIENT;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<PageResult<TaskEmployeeDto>> GetTaskEmployees(PageableModel query)
        {
            var baseQuery = _dbcontext.TaskEmployees
                .Include(w => w.Task.Client.Identiti.Address)
                .Where(x => x.Task.TaskStatus == TaskStatus.REPAIRED)
                .OrderByDescending(w => w.Task.startDate)
                .Where(r => query.SearchPharse == null || (r.Task.Name.ToLower().Contains(query.SearchPharse)
                                                    || r.Task.Description.ToLower().Contains(query.SearchPharse)
                                                    || r.Task.Activities.ToLower().Contains(query.SearchPharse)
                                                    || r.Task.Client.Identiti.FirstName.ToLower().Contains(query.SearchPharse)
                                                    || r.Task.Client.Identiti.LastName.ToLower().Contains(query.SearchPharse)
                                                    || r.Task.Client.Identiti.PhoneNumber.ToLower().Contains(query.SearchPharse)));
            if (baseQuery == null)
                throw new NotFoundException("Tasks not found");

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<TaskEmployee, object>>>
                {
                    {nameof(TaskEmployee.Task.Name), r => r.Task.Name },
                    {nameof(TaskEmployee.Task.Description), r => r.Task.Description },
                    {nameof(TaskEmployee.Task.Activities), r => r.Task.Activities },
                    {nameof(TaskEmployee.Task.Client.Identiti.FirstName), r => r.Task.Client.Identiti.FirstName },
                    {nameof(TaskEmployee.Task.Client.Identiti.LastName), r => r.Task.Client.Identiti.LastName },
                    {nameof(TaskEmployee.Task.Client.Identiti.PhoneNumber), r => r.Task.Client.Identiti.PhoneNumber },
                };

                var selectedColumn = columnsSelectors[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC ?
                    baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var tasks = await baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToListAsync();

            var tasksdto = _mapper.Map<IEnumerable<TaskEmployeeDto>>(tasks);

            var result = new PageResult<TaskEmployeeDto>(tasksdto, baseQuery.Count());

            return result;
        }

        public async System.Threading.Tasks.Task EndTask(Guid taskId)
        {
            var task = await _dbcontext.Tasks.FindAsync(taskId);
            if (task == null)
                throw new NotFoundException("Tasks not found");
            task.TaskStatus = TaskStatus.COLLECTED;
            task.endDate = DateTime.Now;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<PageResult<TaskDto>> GetAvailableTasks(PageableModel query)
        {
            var baseQuery = _dbcontext.Tasks
                .Include(w => w.Client.Identiti.Address)
                .Where(x => x.TaskStatus == TaskStatus.RECEIVED || x.TaskStatus == TaskStatus.NOT_REPAIRED)
                .Where(r => query.SearchPharse == null || (r.Name.ToLower().Contains(query.SearchPharse)
                                                    || r.Description.ToLower().Contains(query.SearchPharse)
                                                    || r.Activities.ToLower().Contains(query.SearchPharse)
                                                    || r.Client.Identiti.FirstName.ToLower().Contains(query.SearchPharse)
                                                    || r.Client.Identiti.LastName.ToLower().Contains(query.SearchPharse)
                                                    || r.Client.Identiti.PhoneNumber.ToLower().Contains(query.SearchPharse)));
            if (baseQuery == null)
                throw new NotFoundException("Tasks not found");

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<Domain.Entities.Task, object>>>
                {
                    {nameof(Domain.Entities.Task.Name), r => r.Name },
                    {nameof(Domain.Entities.Task.Description), r => r.Description },
                    {nameof(Domain.Entities.Task.Activities), r => r.Activities },
                    {nameof(Domain.Entities.Task.Client.Identiti.FirstName), r => r.Client.Identiti.FirstName },
                    {nameof(Domain.Entities.Task.Client.Identiti.LastName), r => r.Client.Identiti.LastName },
                    {nameof(Domain.Entities.Task.Client.Identiti.PhoneNumber), r => r.Client.Identiti.PhoneNumber },
                };

                var selectedColumn = columnsSelectors[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC ?
                    baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var tasks = await baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToListAsync();

            var tasksdto = _mapper.Map<IEnumerable<TaskDto>>(tasks);

            var result = new PageResult<TaskDto>(tasksdto, baseQuery.Count());

            return result;
        }
    }
}
