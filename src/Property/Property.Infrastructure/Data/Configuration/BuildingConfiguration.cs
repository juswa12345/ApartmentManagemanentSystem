using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Infrastructure.Data.Configuration
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> building)
        {
            building.HasKey(u => u.Id);
            building.Property(u => u.Id)
                .HasConversion(u => u.Value, value => new BuildingId(value));

            building.OwnsOne(x => x.BuildingAddress, a =>
            {
                a.Property(p => p.Street);
                a.Property(p => p.City);
                a.Property(p => p.State);
                a.Property(p => p.ZipCode);
            });

            building.Navigation(x => x.Units)
                    .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
