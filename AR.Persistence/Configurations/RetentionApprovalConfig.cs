using AR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Persistence.Configurations
{
    public class RetentionApprovalConfig : IEntityTypeConfiguration<RetentionApproval>
    {
        public void Configure(EntityTypeBuilder<RetentionApproval> builder)
        {
            builder.HasOne(a => a.Retention)
                .WithMany(a => a.RetentionApproval)
                .HasForeignKey(a => a.RetentionId)
                .HasConstraintName("RetentionA");
        }
    }
}
