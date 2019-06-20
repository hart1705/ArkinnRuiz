using AR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Persistence.Configurations
{
    public class RetentionWaiverConfig : IEntityTypeConfiguration<RetentionWaiver>
    {
        public void Configure(EntityTypeBuilder<RetentionWaiver> builder)
        {
            builder.HasOne(a => a.Retention)
                .WithMany(a => a.RetentionWaiver)
                .HasForeignKey(a => a.RetentionId)
                .HasConstraintName("RetentionW");
        }
    }
}
