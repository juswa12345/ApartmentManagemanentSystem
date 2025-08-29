using Identity.Domain.Entities;
using Identity.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Data.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> account)
        {
            account.HasKey(t => t.Id);
            account.Property(t => t.Id).HasConversion(u => u.Value, value => new AccountId(value));


            account.Property(t => t.UserId).HasConversion(u => u.Value, value => new UserId(value));

            account.OwnsOne(x => x.FullName, a =>
            {
                a.Property(p => p.FirstName);
                a.Property(p => p.LastName);
            });

            account.OwnsOne(x => x.Address, a =>
            {
                a.Property(p => p.Street);
                a.Property(p => p.City);
                a.Property(p => p.State);
                a.Property(p => p.ZipCode);
            });

        }
    }
}
