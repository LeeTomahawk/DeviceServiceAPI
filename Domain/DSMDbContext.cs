using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Cofigurations;

namespace Domain
{
    public class DSMDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Identiti> Identities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<TaskEmployee> TaskEmployees { get; set; }
        public DbSet<WorkplaceEquipment> WorkplaceEquipments { get; set; }
        public DbSet<CompletedTask> CompletedTasks { get; set; }

        public DSMDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskEmployeeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompletedTaskConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkplaceEquipmentConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentitiConfiguration).Assembly);
        }
    }
}
