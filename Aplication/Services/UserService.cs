using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repositories.Dtos;
using Repositories.Exceptions;
using Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aplication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IManagerRepository _managerRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper, IEmployeeRepository employeeRepository, IManagerRepository managerRepository, IPasswordHasher<User> passwordHasher, IConfiguration configuration)
        {
            _userRepository = repository;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _managerRepository = managerRepository;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        public async Task<RegisterUserDto> Adduser(RegisterUserDto userdto)
        {
            var user = _mapper.Map<User>(userdto);
            var hashPassword = _passwordHasher.HashPassword(user, userdto.Password);
            user.Password = hashPassword;
            await _userRepository.Add(user);
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

        public async Task<string> GenerateJwt(LoginDto logindto)
        {
            var user = await _userRepository.GetByEmail(logindto.Email);
            if(user == null)
            {
                throw new BadRequestException("Invalid user email or password!");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password,logindto.Password); 
            if(result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid user email or password!");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Authentication:JwtKey").Get<string>()));
            var tokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, $"{user.Identiti.FirstName} {user.Identiti.LastName}"),
                    new Claim(ClaimTypes.Role, user.RoleType.ToString()),
                }),
                Expires = DateTime.Now.AddDays(_configuration.GetSection("Authentication:JwtExpireDays").Get<int>()),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDecriptor);
            return tokenHandler.WriteToken(token);
            
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            var user = await _userRepository.GetById(id);
            var userdto = _mapper.Map<UserDto>(user);
            return userdto;
        }
    }
}
