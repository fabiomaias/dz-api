using DotzInc.Application.Responses;
using DotzInc.Domain.Enums;
using MediatR;
using System.Text.Json.Serialization;

namespace DotzInc.Application.CQRS.CreditCards.Commands.UpdateCardStatus
{
    public partial class UpdateCardStatusCommand : IRequest<Response<UpdateCardStatusViewModel>>
    {
        public int Id { get; set; }
        [JsonIgnore]
        public int AccountId { get; set; }
        public CardStatus CardStatus { get; set; }
    }
}
