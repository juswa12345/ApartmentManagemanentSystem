using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Billing.Infrastructure.Data.Configuration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasConversion(id => id.Value, value => new PaymentId(value));

            builder.Property(p => p.TenantID)
                .HasConversion(id => id.Value, value => new TenantId(value));

            builder.Property(p => p.UnitID)
                .HasConversion(id => id.Value, value => new UnitId(value));
        }
    }
}
