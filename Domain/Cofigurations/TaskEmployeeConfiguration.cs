using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Cofigurations
{
    public class TaskEmployeeConfiguration : IEntityTypeConfiguration<TaskEmployee>
    {
        public void Configure(EntityTypeBuilder<TaskEmployee> builder)
        {
            //builder.ToTable("","")
            builder.HasKey(x => x.Id);
            builder
                .HasOne(x => x.Task)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.TaskId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.Employee)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
            //builder.Property(x=> x.)
        }
    }
}
