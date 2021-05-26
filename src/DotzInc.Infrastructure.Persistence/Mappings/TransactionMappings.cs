using DotzInc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotzInc.Infrastructure.Persistence.Mappings
{
    class TransactionMappings : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Amount)
                    .IsRequired();

            builder.Property(t => t.Date)
                    .IsRequired();

            builder.Property(t => t.Description)
                    .IsRequired()
                    .HasMaxLength(500);

            builder.HasOne(t => t.Account)
                    .WithMany(a => a.Transactions)
                    .HasForeignKey(a => a.AccountId);

            builder.ToTable("Transactions");
        }
    }
}
