using Microsoft.EntityFrameworkCore;
using DotzInc.Domain.Common;
using DotzInc.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace DotzInc.Infrastructure.Persistence.Contexts
{
    public class DotzDbContext : DbContext
    {
        public DotzDbContext(DbContextOptions<DotzDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntityTraceable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedAt = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
             .SelectMany(e => e.GetProperties()
             .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100" +
                    ")");

            builder.ApplyConfigurationsFromAssembly(typeof(DotzDbContext).Assembly);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(builder);
        }
    }
}
