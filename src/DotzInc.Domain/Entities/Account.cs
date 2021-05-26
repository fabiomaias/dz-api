using System.Collections.Generic;
using DotzInc.Domain.Common;

namespace DotzInc.Domain.Entities
{
    public class Account: BaseEntityTraceable
    {
        public int Dz { get; set; }
        public string AuthId { get; set; }

        public ICollection<CreditCard> CreditCards { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}