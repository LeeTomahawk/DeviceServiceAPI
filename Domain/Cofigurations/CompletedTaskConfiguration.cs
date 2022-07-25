using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Cofigurations
{
    public class CompletedTaskConfiguration : IEntityTypeConfiguration<TaskDetails>
    {
        public void Configure(EntityTypeBuilder<TaskDetails> builder)
        {
            builder.HasKey(e => e.Id);
            //builder
            //    .HasOne(e => e.Employee)
            //    .WithOne(e => e.Task)
            //    .HasForeignKey<CompletedTask>(x => x.TaskId)
            //    .OnDelete(DeleteBehavior.Restrict);
            //builder
            //    .HasOne(e => e.Task)
            //    .WithOne(e => e.Employee)
            //    .HasForeignKey<CompletedTask>(e => e.EmployeeId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
