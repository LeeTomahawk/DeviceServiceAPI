using Aplication.Interfaces;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITaskRepository _taskRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, ITaskRepository taskRepository)
        {
            _employeeRepository = employeeRepository;
            _taskRepository = taskRepository;
        }

        public async Task TakeTask(Guid taskId, Guid userId)
        {
            var employee = await _employeeRepository.GetEmployeeByUserId(userId);
            var task = await _taskRepository.GetTaskById(taskId);
            await _taskRepository.UpdateTaskEmployee(task, employee);
        }
    }
}
