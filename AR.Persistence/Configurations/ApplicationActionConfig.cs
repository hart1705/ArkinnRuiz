using AR.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Persistence.Configurations
{
    public class ApplicationActionConfig : IEntityTypeConfiguration<ApplicationAction>
    {
        public void Configure(EntityTypeBuilder<ApplicationAction> builder)
        {
            ///builder.Property(a => a.Email).HasColumnType("emailaddress");
        }
    }
}
