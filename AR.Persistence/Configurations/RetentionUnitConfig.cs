using AR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Persistence.Configurations
{
    public class RetentionUnitConfig : IEntityTypeConfiguration<RetentionUnit>
    {
        public void Configure(EntityTypeBuilder<RetentionUnit> builder)
        {
            builder.HasOne(a => a.Retention)
                .WithMany(a => a.RetentionUnit)
                .HasForeignKey(a => a.RetentionId)
                .HasConstraintName("RetentionU");
        }
    }
}
