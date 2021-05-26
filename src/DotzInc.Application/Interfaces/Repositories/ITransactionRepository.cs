using System.Collections.Generic;
using System.Threading.Tasks;
using DotzInc.Domain.Entities;

namespace DotzInc.Application.Interfaces.Repositories
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        Task<IReadOnlyList<Transaction>> GetByAccount(string id);
    }
}