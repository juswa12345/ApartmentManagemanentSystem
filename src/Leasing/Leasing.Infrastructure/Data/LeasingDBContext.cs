using Leasing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastructure.Data
{
    public class LeasingDBContext : DbContext
    {
        public LeasingDBContext(DbContextOptions<LeasingDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Leasing");
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(LeasingDBContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Unit>  Units { get; set; }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<LeasingRecord> LeasingRecords { get; set; }

        public DbSet<Owner> Owners { get; set; }

    }
}
