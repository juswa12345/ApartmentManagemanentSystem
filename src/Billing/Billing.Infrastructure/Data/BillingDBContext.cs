using Billing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.Data
{
    public class BillingDBContext : DbContext
    {
        public BillingDBContext(DbContextOptions<BillingDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Billing");
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(BillingDBContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Payment> Payments { get; set; }
    }
}
