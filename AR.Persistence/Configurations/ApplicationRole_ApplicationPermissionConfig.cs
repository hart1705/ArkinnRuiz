using AR.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Persistence.Configurations
{
    public class ApplicationRole_ApplicationPermissionConfig : IEntityTypeConfiguration<ApplicationRole_ApplicationPermission>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole_ApplicationPermission> builder)
        {
            builder.HasKey(t => new { t.RoleId, t.ApplicationPermissionId });

            builder.HasOne(pt => pt.ApplicationRole)
               .WithMany(t => t.ApplicationRole_ApplicationPermissions)
               .HasForeignKey(pt => pt.RoleId);

            builder.HasOne(pt => pt.ApplicationPermission)
                .WithMany(t => t.ApplicationRole_ApplicationPermissions)
                .HasForeignKey(pt => pt.ApplicationPermissionId);
        }
    }
}
