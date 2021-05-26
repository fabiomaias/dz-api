using DotzInc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotzInc.Infrastructure.Persistence.Mappings
{
    class CreditCardMappings : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ExpirationDate)
                    .IsRequired();

            builder.Property(c => c.InvoiceDueDate)
                    .IsRequired();

            builder.Property(c => c.Number)
                    .IsRequired();

            builder.Property(c => c.SecurityCode)
                    .IsRequired();

            builder.Property(c => c.Status)
                    .IsRequired();

            builder.Property(c => c.Type)
                    .IsRequired();

            builder.Property(c => c.Balance)
                    .HasDefaultValue(2000);

            builder.HasOne(c => c.Account)
                    .WithMany(a => a.CreditCards)
                    .HasForeignKey(a => a.AccountId);

            builder.ToTable("CreditCards");
        }
    }
}
