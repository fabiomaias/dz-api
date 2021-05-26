using DotzInc.Application.CQRS.Accounts.Shared;
using DotzInc.Application.Responses;
using DotzInc.Domain.Enums;
using MediatR;
using System.Text.Json.Serialization;

namespace DotzInc.Application.CQRS.Accounts.Commands.UpdateBalanceDz
{
    public partial class UpdateBalanceDzCommand: IRequest<Response<AccountViewModel>>
    {
        [JsonIgnore]
        public string AuthId { get; set; }
        public int Dz { get; set; }
        [JsonIgnore]
        public TypeOperationDz Operation { get; set; }
    }
}
