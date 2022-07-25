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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, ITaskRepository taskRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> GetEmployee(Guid id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            var employeedto = _mapper.Map<EmployeeDto>(employee);
            return employeedto;
        }

        public async Task TakeTask(Guid taskId, Guid userId)
        {
            var employee = await _employeeRepository.GetEmployeeByUserId(userId);
            var task = await _taskRepository.GetTaskById(taskId);
            await _taskRepository.UpdateTaskEmployee(task, employee);
        }
    }
}
