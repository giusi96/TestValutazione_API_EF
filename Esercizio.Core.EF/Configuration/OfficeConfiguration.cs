using Esercizio.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizio.Core.EF.Configuration
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Nome).HasMaxLength(100).IsRequired();

            builder.HasMany(o => o.Employees).WithOne(e => e.Office).HasForeignKey(e => e.OfficeId)
                .HasConstraintName("FK_Office_Employees").OnDelete(DeleteBehavior.Cascade);
        }
    }
}
