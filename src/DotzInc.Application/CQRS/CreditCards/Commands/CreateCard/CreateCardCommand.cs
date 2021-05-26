using DotzInc.Application.Responses;
using DotzInc.Domain.Enums;
using MediatR;
using System;
using System.Text.Json.Serialization;

namespace DotzInc.Application.CQRS.CreditCards.Commands.CreateCard
{
    public partial class CreateCardCommand : IRequest<Response<int>>
    {
        public CardType Type { get; set; }
        public int InvoiceDueDate { get; set; }
        [JsonIgnore]
        public int AccountId { get; set; }
    }
}