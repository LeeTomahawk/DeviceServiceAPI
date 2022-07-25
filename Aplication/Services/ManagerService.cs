using Aplication.Interfaces;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public ManagerService(IManagerRepository managerRepository, ITaskRepository taskRepository, IEmployeeRepository employeeRepository)
        {
            _managerRepository = managerRepository;
            _taskRepository = taskRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task AddTaskToEmployee(Guid taskId, Guid employeeId)
        {
            var employee = await _employeeRepository.GetEmployeeById(employeeId);
            var task = await _taskRepository.GetTaskById(taskId);
            await _taskRepository.UpdateTaskEmployee(task, employee);
        }
    }
}
