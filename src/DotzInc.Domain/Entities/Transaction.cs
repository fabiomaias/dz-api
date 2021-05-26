using System;
using DotzInc.Domain.Common;
using DotzInc.Domain.Enums;

namespace DotzInc.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public TransactionType Type { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}