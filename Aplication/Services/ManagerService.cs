using Aplication.Interfaces;
using AutoMapper;
using Repositories.Dtos;
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
        private readonly IMapper _mapper;

        public ManagerService(IManagerRepository managerRepository, ITaskRepository taskRepository, IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _managerRepository = managerRepository;
            _taskRepository = taskRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task AddTaskToEmployee(Guid taskId, Guid employeeId)
        {
            var employee = await _employeeRepository.GetEmployeeById(employeeId);
            var task = await _taskRepository.GetTaskById(taskId);
            await _taskRepository.UpdateTaskEmployee(task, employee);
        }

        public async Task<PageResult<ManagerDto>> GetAllManager(PageableModel query)
        {
            var managers = await _managerRepository.GetManagers(query);
            return managers;
        }

        public async Task<ManagerDto> GetManager(Guid userId)
        {
            var manager = await _managerRepository.GetManagerByUserId(userId);
            var managerdto = _mapper.Map<ManagerDto>(manager);
            return managerdto;
        }

        public async Task TaskAprove(Guid taskId)
        {
            await _taskRepository.UpdateTaskEmployee(taskId);
        }
    }
}
