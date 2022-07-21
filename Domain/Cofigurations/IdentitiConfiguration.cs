using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cofigurations
{
    public class IdentitiConfiguration : IEntityTypeConfiguration<Identiti>
    {
        public void Configure(EntityTypeBuilder<Identiti> builder)
        {
            builder.HasIndex(x => x.PhoneNumber).IsUnique();
        }
    }
}
