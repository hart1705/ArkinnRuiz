using AR.Domain.Entities;
using AR.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace AR.Persistence
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }
        public DbSet<ApplicationAction> ApplicationAction { get; set; }
        public DbSet<ApplicationPermission> ApplicationPermission { get; set; }
        public DbSet<ApplicationAction_ApplicationPermission> ApplicationAction_ApplicationPermission { get; set; }
        public DbSet<ApplicationRole_ApplicationPermission> ApplicationRole_ApplicationPermission { get; set; }
        public DbSet<Retention> Retentions { get; set; }
        public DbSet<RetentionApproval> RetentionApproval { get; set; }
        public DbSet<RetentionCollectionUnitPlan> RetentionCollectionUnitPlan { get; set; }
        public DbSet<RetentionUnit> RetentionUnit { get; set; }
        public DbSet<RetentionWaiver> RetentionWaiver { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
