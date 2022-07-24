using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Repositories.Dtos;
using Repositories.Interfaces;

namespace Aplication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IManagerRepository _managerRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper, IEmployeeRepository employeeRepository, IManagerRepository managerRepository, IPasswordHasher<User> passwordHasher)
        {
            _repository = repository;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _managerRepository = managerRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<RegisterUserDto> Adduser(RegisterUserDto userdto)
        {
            var user = _mapper.Map<User>(userdto);
            var hashPassword = _passwordHasher.HashPassword(user, userdto.Password);
            user.Password = hashPassword;
            await _repository.Add(user);
            if(user.RoleType == RoleType.EMPLOYEE)
            {
                var employee = new Employee
                {
                    EmploymentDate = DateTime.Now,
                    Identiti = user.Identiti,
                };
                await _employeeRepository.Add(employee);
            }
            else if(user.RoleType == RoleType.MANAGER)
            {
                var manager = new Manager
                {
                    EmploymentDate = DateTime.Now,
                    Identiti = user.Identiti,
                };
                await _managerRepository.Add(manager);
            }
            return userdto;
        }
    }
}
