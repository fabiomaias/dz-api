using System.Threading.Tasks;
using DotzInc.Domain.Entities;

namespace DotzInc.Application.Interfaces.Repositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<bool> VerifyAuthId(string authId);
        Task<Account> GetByAuthId(string authId);

    }
}