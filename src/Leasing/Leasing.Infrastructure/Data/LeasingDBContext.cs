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

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Unit>  Units { get; set; }
    }
}
