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

        public async Task<PageResult<EmployeeDto>> GetAllEmployees(PageableModel query)
        {
            var employees = await _employeeRepository.GetEmployees(query);
            return employees;
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

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesWithoutWokrplace()
        {
            var employees = await _employeeRepository.GetEmployeeListWithoutWorkplace();
            var employeesdto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return employeesdto;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesWithWorkplace(Guid id)
        {
            var employees = await _employeeRepository.GetEmployeeWithWorkplace(id);
            var employeesdto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return employeesdto;
        }
    }
}
