using DotzInc.Domain.Enums;
using System;

namespace DotzInc.Application.CQRS.CreditCards.Commands.UpdateCardStatus
{
    public class UpdateCardStatusViewModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public CardType Type { get; set; }
        public string Number { get; set; }
        public CardStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
    }
}
