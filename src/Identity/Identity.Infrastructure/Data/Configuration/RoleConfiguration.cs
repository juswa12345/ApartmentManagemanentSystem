using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> role)
        {
            role.HasKey(r => r.Id);
            role.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(200);

        }
    }
}
