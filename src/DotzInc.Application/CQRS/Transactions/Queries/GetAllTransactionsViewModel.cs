using DotzInc.Domain.Enums;
using System;

namespace DotzInc.Application.CQRS.Transactions.Queries
{
    public class GetAllTransactionsViewModel
    {
        public TransactionType Type { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
