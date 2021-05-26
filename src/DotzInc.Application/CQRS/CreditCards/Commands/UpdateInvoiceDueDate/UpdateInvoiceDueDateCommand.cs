using DotzInc.Application.Responses;
using MediatR;
using System.Text.Json.Serialization;

namespace DotzInc.Application.CQRS.CreditCards.Commands.UpdateInvoiceDueDate
{
    public partial class UpdateInvoiceDueDateCommand : IRequest<Response<UpdateInvoiceDueDateViewModel>>
    {
        public int Id { get; set; }
        [JsonIgnore]
        public int AccountId { get; set; }
        public int InvoiceDueDate { get; set; }
    }
}
