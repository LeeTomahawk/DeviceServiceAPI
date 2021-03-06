using Aplication.Interfaces;
using Aplication.Services;
using Repositories.Interfaces;
using Repositories.Repository;

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
        }
    }
}
