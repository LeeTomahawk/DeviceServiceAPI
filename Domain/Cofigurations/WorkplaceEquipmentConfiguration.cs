using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Cofigurations
{
    internal class WorkplaceEquipmentConfiguration : IEntityTypeConfiguration<WorkplaceEquipment>
    {
        public void Configure(EntityTypeBuilder<WorkplaceEquipment> builder)
        {
            builder.HasKey(e => e.Id);
            builder
                .HasOne(e => e.Workplace)
                .WithMany(e => e.Equipments)
                .HasForeignKey(e => e.WorkplaceId);
            builder
                .HasOne(e => e.Equipment)
                .WithMany(e => e.Workplaces)
                .HasForeignKey(e => e.EquipmentId);
        }
    }
}
