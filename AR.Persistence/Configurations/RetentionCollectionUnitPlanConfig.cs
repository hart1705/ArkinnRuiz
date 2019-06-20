using AR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Persistence.Configurations
{
    public class RetentionCollectionUnitPlanConfig : IEntityTypeConfiguration<RetentionCollectionUnitPlan>
    {
        public void Configure(EntityTypeBuilder<RetentionCollectionUnitPlan> builder)
        {
            builder.HasOne(a => a.Retention)
                .WithMany(a => a.RetentionCollectionUnitPlan)
                .HasForeignKey(a => a.RetentionId)
                .HasConstraintName("RetentionC");
        }
    }
}
