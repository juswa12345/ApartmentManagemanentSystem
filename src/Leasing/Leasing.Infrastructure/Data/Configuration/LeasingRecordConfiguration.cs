using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leasing.Infrastructure.Data.Configuration
{
    public class LeasingRecordConfiguration : IEntityTypeConfiguration<LeasingRecord>
    {
        public void Configure(EntityTypeBuilder<LeasingRecord> leasing)
        {
            leasing.HasKey(l => l.Id); 
            leasing.Property(l => l.Id)
                .HasConversion(u => u.Value, value => new LeasingRecordId(value)); 

            leasing.Property(l => l.UnitId)
                .HasConversion(u => u.Value, value => new UnitId(value)); 

            leasing.Property(l => l.TenantId)
                .HasConversion(u => u.Value, value => new TenantId(value)); 

            leasing.Property(l => l.OwnerId)
                .HasConversion(u => u.Value, value => new OwnerId(value));

            leasing.OwnsOne(l => l.MonthlyRent, m =>
            {
                m.Property(x => x.Amount)
                 .HasColumnName("MonthlyRentAmount")
                 .HasColumnType("decimal(18,2)") 
                 .IsRequired();

                m.Property(x => x.Currency)
                 .HasColumnName("MonthlyRentCurrency")
                 .HasMaxLength(3)
                 .IsUnicode(false)
                 .IsRequired();
            });

            leasing.OwnsOne(l => l.Term, t =>
            {
                t.Property(x => x.Start)
                 .HasColumnName("LeaseStart")
                 .IsRequired();
                t.Property(x => x.End)
                 .HasColumnName("LeaseEnd");
            });

        }
    }
}
