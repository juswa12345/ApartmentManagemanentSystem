using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Infrastructure.Data.Configuration
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> unit)
        {

            unit.HasKey(u => u.Id);
            unit.Property(u => u.Id)
                .HasConversion(u => u.Value, value => new UnitId(value));

            unit.Property(u => u.BuildingId)
                .HasConversion(id => id.Value, value => new BuildingId(value))
                .IsRequired();

            unit.HasOne(u => u.Building)
                .WithMany(b => b.Units)
                .HasForeignKey(u => u.BuildingId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            unit.Property(u => u.OwnerId)
                .HasConversion(id => id.Value, value => new OwnerId(value))
                .IsRequired();

            unit.HasOne(u => u.Owner)
                .WithMany(b => b.Units)
                .HasForeignKey(u => u.OwnerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            unit.Property(u => u.UnitNumber)
                .IsRequired()
                .HasMaxLength(50);

            unit.Property(u => u.MonthlyRent)
                .HasColumnType("decimal(18,2)");

        }
    }
}
