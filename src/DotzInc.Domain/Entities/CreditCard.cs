using System;
using DotzInc.Domain.Common;
using DotzInc.Domain.Enums;

namespace DotzInc.Domain.Entities
{
    public class CreditCard: BaseEntityTraceable
    {
        public CardType Type { get; set; }
        public string Number { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SecurityCode { get; set; }
        public int InvoiceDueDate { get; set; }
        public CardStatus Status { get; set; }
        public double Balance { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

    }
}