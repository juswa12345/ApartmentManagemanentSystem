using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leasing.Infrastructure.Data.Configuration
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasConversion(u => u.Value, value => new OwnerId(value));
            builder.OwnsOne(x => x.OwnerName, a =>
            {
                a.Property(p => p.FirstName);
                a.Property(p => p.LastName);
            });

            //builder.OwnsOne(x => x.Address, a =>
            //{
            //    a.Property(p => p.Street);
            //    a.Property(p => p.City);
            //    a.Property(p => p.State);
            //    a.Property(p => p.ZipCode);
            //});
        }
    }

}