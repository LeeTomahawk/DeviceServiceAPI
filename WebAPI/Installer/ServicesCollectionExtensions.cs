using Aplication.Interfaces;
using Aplication.Services;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Repositories.Dtos;
using Repositories.Interfaces;
using Repositories.Repository;
using Repositories.Validators;

namespace WebAPI.Installer
{
    public static class ServicesCollectionExtensions
    {
        public static void AddInfasctructureServices(this IServiceCollection services)
        {
            services.AddTransient<IEquipmentRepository, EquipmentRepository>();
            services.AddTransient<IEquipmentService, EquipmentService>();
            services.AddTransient<IWorkplaceRepository, WorkplaceRepository>();
            services.AddTransient<IWorkplaceService, WorkplaceService>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<IClientRepository,ClientRepository>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IManagerRepository, ManagerRepository>();
            services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddTransient<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
        }
    }
}
