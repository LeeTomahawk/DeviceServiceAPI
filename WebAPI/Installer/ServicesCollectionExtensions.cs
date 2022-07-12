using Repositories.Interfaces;
using Repositories.Repository;

namespace WebAPI.Installer
{
    public static class ServicesCollectionExtensions
    {
        public static void AddInfasctructureServices(this IServiceCollection services)
        {
            services.AddTransient<IAddressRepository, AddressRepository>();
        }
    }
}
