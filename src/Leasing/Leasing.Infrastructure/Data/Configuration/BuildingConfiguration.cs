using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Leasing.Infrastructure.Data.Configuration
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
