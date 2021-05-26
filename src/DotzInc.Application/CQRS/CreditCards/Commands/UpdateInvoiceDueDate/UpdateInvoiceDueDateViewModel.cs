using DotzInc.Domain.Enums;
using System;

namespace DotzInc.Application.CQRS.CreditCards.Commands.UpdateInvoiceDueDate
{
    public class UpdateInvoiceDueDateViewModel
    {
        public int Id { get; set; }
        public CardType Type { get; set; }
        public string Number { get; set; }
        public int InvoiceDueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
    }
}
