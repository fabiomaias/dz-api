using DotzInc.Application.CQRS.Accounts.Shared;
using DotzInc.Application.Responses;
using MediatR;
using System.Text.Json.Serialization;

namespace DotzInc.Application.CQRS.Accounts.Commands.CreateAccount
{
    public partial class CreateAccountCommand : IRequest<Response<AccountViewModel>>
    {
        public int Dz { get; set; }
        [JsonIgnore]
        public string AuthId { get; set; }
    }
}