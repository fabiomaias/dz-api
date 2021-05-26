using DotzInc.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotzInc.Application.CQRS.Transactions.Queries
{
    public partial class GetAllTransactionsQuery : IRequest<PagedResponse<IEnumerable<GetAllTransactionsViewModel>>>
    {
        public int MaxResults { get; set; }
        public int PageSize { get; set; }
    }
}
