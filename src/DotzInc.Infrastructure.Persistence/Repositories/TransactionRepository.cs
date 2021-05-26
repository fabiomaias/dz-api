using DotzInc.Application.Interfaces.Repositories;
using DotzInc.Domain.Entities;
using DotzInc.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotzInc.Infrastructure.Persistence.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly DbSet<Transaction> _transaction;
        public TransactionRepository(DotzDbContext dbContext): base(dbContext)
        {
            _transaction = dbContext.Set<Transaction>();
        }

        public Task<IReadOnlyList<Transaction>> GetByAccount(string id)
        {
            throw new NotImplementedException();
        }
    }
}
