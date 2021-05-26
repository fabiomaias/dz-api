using DotzInc.Application.Interfaces.Repositories;
using DotzInc.Domain.Entities;
using DotzInc.Domain.Enums;
using DotzInc.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotzInc.Infrastructure.Persistence.Repositories
{
    public class CreditCardRepository : GenericRepository<CreditCard>, ICreditCardRepository
    {
        private readonly DbSet<CreditCard> _creditCard;
        public CreditCardRepository(DotzDbContext dbContext): base(dbContext) =>
            _creditCard = dbContext.Set<CreditCard>();

        public async Task<IReadOnlyList<CreditCard>> GetByAccountId(int accountId) =>
           await _creditCard.Where(c => c.AccountId == accountId && c.Status == CardStatus.Ativo)
            .ToListAsync();

        public async Task<bool> VerifyIfExists(int accountId, CardType type) => 
            await _creditCard.AnyAsync(c => c.AccountId == accountId && c.Type == type && c.Status == CardStatus.Ativo);
        
    }
}
