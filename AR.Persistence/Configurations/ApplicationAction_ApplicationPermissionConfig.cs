using AR.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Persistence.Configurations
{
    public class ApplicationAction_ApplicationPermissionConfig : IEntityTypeConfiguration<ApplicationAction_ApplicationPermission>
    {
        public void Configure(EntityTypeBuilder<ApplicationAction_ApplicationPermission> builder)
        {
            builder.HasOne(pt => pt.ApplicationPermission)
               .WithMany(t => t.ApplicationAction_ApplicationPermissions)
               .HasForeignKey(pt => pt.ApplicationPermissionId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.ApplicationAction)
                .WithMany(t => t.ApplicationAction_ApplicationPermissions)
                .HasForeignKey(pt => pt.ApplicationActionId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
