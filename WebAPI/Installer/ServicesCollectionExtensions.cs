using Aplication.Interfaces;
using Aplication.Services;
using Domain;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositories.Dtos;
using Repositories.Interfaces;
using Repositories.Middleware;
using Repositories.Repository;
using Repositories.Validators;
using System.Text;
using System.Text.Json.Serialization;

namespace WebAPI.Installer
{
    public static class ServicesCollectionExtensions
    {
        public static void AddDbContextSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var dbcontextoptions = new DbContextOptions();
            configuration.GetSection("ConnectionStrings").Bind(dbcontextoptions);

            services.AddDbContext<DSMDbContext>(option => option.UseSqlServer(dbcontextoptions.DbConnection));

        }
        public static void AddInfasctructureServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddTransient<IEquipmentService, EquipmentService>();
            services.AddTransient<IWorkplaceService, WorkplaceService>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IUserService, UserService>();
        }
        public static void AddInfasctructureRepositories(this IServiceCollection services) 
        {
            services.AddTransient<IEquipmentRepository, EquipmentRepository>();
            services.AddTransient<IWorkplaceRepository, WorkplaceRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IManagerRepository, ManagerRepository>();
        }
        public static void AddInfasctructureValidators(this IServiceCollection services) 
        {
            services.AddScoped<ErrorHandlingMiddleware>();

            services.AddTransient<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
            services.AddTransient<IValidator<LoginDto>, LoginDtoValidator>();
        }
        public static void AddAuthenticationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var authenticationsetting = new SettingsOptionsClass();
            configuration.GetSection("Authentication").Bind(authenticationsetting);

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationsetting.JwtIssuer,
                    ValidAudience = authenticationsetting.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationsetting.JwtKey)),
                };
            });
        }
        public static void AddJsonSettings(this IServiceCollection services)
        {
            services.AddControllersWithViews().AddJsonOptions(o =>
            {
                var enums = new JsonStringEnumConverter(); o.JsonSerializerOptions.Converters.Add(enums);
            });
        }
    }
}
