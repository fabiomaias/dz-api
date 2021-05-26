using DotzInc.Application.Interfaces.Repositories;
using DotzInc.Domain.Entities;
using DotzInc.Domain.Settings;
using DotzInc.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace DotzInc.Infrastructure.Persistence.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly DbSet<Account> _accounts;
        public AccountRepository(DotzDbContext dbContext, IOptions<DzConvert> config) : base(dbContext)
        {
            _accounts = dbContext.Set<Account>();
        }

        public async Task<bool> VerifyAuthId(string authId) => await _accounts.AllAsync(p => p.AuthId != authId);


        public async Task<Account> GetByAuthId(string authId) => 
            await _accounts.SingleOrDefaultAsync(a => a.AuthId == authId);
    }
}
