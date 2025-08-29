using Microsoft.EntityFrameworkCore;
using Property.Domain.Entities;

namespace Property.Infrastructure.Data
{
    public class PropertyDBContext : DbContext
    {
        public PropertyDBContext(DbContextOptions<PropertyDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Property");
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(PropertyDBContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Unit>  Units { get; set; }

        public DbSet<Owner> Owners { get; set; }

        }
}
