using DotzInc.Application.Responses;
using DotzInc.Domain.Enums;
using MediatR;
using System.Text.Json.Serialization;

namespace DotzInc.Application.CQRS.Transactions.Commands.CreateTransaction
{
    public partial class CreateTransactionCommand : IRequest<Response<int>>
    {
        public TransactionType Type { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        [JsonIgnore]
        public int AccountId { get; set; }
    }
}