using DotzInc.Application.CQRS.Accounts.Shared;
using DotzInc.Application.Responses;
using MediatR;
using System.Text.Json.Serialization;

namespace DotzInc.Application.CQRS.Accounts.Queries.GetAccountByAuthId
{
    public class GetAccountByAuthIdQuery : IRequest<Response<AccountViewModel>>
    {
        [JsonIgnore]
        public string AuthId { get; set; }
    }
}
