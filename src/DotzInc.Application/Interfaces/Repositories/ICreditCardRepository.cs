using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotzInc.Domain.Entities;
using DotzInc.Domain.Enums;

namespace DotzInc.Application.Interfaces.Repositories
{
    public interface ICreditCardRepository: IGenericRepository<CreditCard>
    {
        Task<IReadOnlyList<CreditCard>> GetByAccountId(int accountId);
        Task<bool> VerifyIfExists(int accountId, CardType type);
    }
}