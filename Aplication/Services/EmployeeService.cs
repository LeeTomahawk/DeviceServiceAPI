using Aplication.Interfaces;
using AutoMapper;
using Repositories.Dtos;
using Repositories.Interfaces;

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

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetEmployees();
            var employeesdto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            foreach(var em in employeesdto)
            {
                em.TaskCount = em.Tasks.Count();
            }
            return employeesdto;
        }

        public async Task<EmployeeDto> GetAllEmployeesTasks(Guid userId)
        {
            var employee = await _employeeRepository.GetEmployeeByUserId(userId);
            var employeeTask = await _employeeRepository.GetAllEmployeeTasks(employee.Id);
            var tasksdto = _mapper.Map<EmployeeDto>(employeeTask);
            tasksdto.TaskCount = employeeTask.Tasks.Count();
            return tasksdto;
        }

        public async Task<EmployeeDto> GetEmployee(Guid id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            var employeedto = _mapper.Map<EmployeeDto>(employee);
            employeedto.TaskCount = employeedto.Tasks.Count();
            return employeedto;
        }
    }
}
