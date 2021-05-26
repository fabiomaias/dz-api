using AutoMapper;
using DotzInc.Application.Interfaces.Repositories;
using DotzInc.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DotzInc.Application.CQRS.Transactions.Queries
{
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, PagedResponse<IEnumerable<GetAllTransactionsViewModel>>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllTransactionsViewModel>>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllTransactionsParameter>(request);
            var transactions = await _transactionRepository.GetPagedReponse(validFilter.PageNumber, validFilter.MaxResults);
            var transactionsViewModel = _mapper.Map<IEnumerable<GetAllTransactionsViewModel>>(transactions);
            return new PagedResponse<IEnumerable<GetAllTransactionsViewModel>>(transactionsViewModel, validFilter.PageNumber, validFilter.MaxResults);
        }
    }
}
