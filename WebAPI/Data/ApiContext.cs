using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;

namespace WebApi.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Identiti> Identities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }

        public ApiContext(DbContextOptions options) : base(options)
        {

        }
    }
}
