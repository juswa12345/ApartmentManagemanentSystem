using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Infrastructure.Data.Configuration
{
    public class PropertyOwnershipConfiguration : IEntityTypeConfiguration<PropertyOwnership>
    {
        public void Configure(EntityTypeBuilder<PropertyOwnership> po)
        {
            po.HasKey(po => po.Id);
            po.Property(o => o.Id)
                .HasConversion(o => o.Value, value => new PropertyOwnershipId(value));

            po.Property(o => o.OwnerId)
                .HasConversion(o => o.Value, value => new OwnerId(value));

            po.Property(o => o.UnitId)
                .HasConversion(o => o.Value, value => new UnitId(value));

        }
    }
}
