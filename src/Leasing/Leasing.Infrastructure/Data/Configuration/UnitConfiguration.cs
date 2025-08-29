using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leasing.Infrastructure.Data.Configuration
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

            unit.Property(u => u.UnitNumber)
                .IsRequired()
                .HasMaxLength(50);

            unit.Property(u => u.MonthlyRent)
                .HasColumnType("decimal(18,2)");

        }
    }
}
