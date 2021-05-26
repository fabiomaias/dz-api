using DotzInc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotzInc.Infrastructure.Persistence.Mappings
{
    class AccountMappings : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.AuthId)
                .IsRequired();

            builder.Property(a => a.Dz)
                .HasDefaultValue(200);

            builder.ToTable("Accounts");
        }
    }
}
