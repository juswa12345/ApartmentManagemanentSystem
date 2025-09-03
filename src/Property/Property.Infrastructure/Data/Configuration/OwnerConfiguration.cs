using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Infrastructure.Data.Configuration
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> owner)
        {
            owner.HasKey(o => o.Id);
            owner.Property(o => o.Id)
                .HasConversion(o => o.Value, value => new OwnerId(value));

            owner.OwnsOne(x => x.FullName, a =>
            {
                a.Property(p => p.FirstName);
                a.Property(p => p.LastName);
            });

            owner.OwnsOne(x => x.Address, a =>
            {
                a.Property(p => p.Street);
                a.Property(p => p.City);
                a.Property(p => p.State);
                a.Property(p => p.ZipCode);
            });
        }
    }
}
