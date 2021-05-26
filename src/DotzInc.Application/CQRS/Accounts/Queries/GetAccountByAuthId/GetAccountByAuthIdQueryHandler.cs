using AutoMapper;
using DotzInc.Application.CQRS.Accounts.Shared;
using DotzInc.Application.Exceptions;
using DotzInc.Application.Interfaces.Repositories;
using DotzInc.Application.Responses;
using DotzInc.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DotzInc.Application.CQRS.Accounts.Queries.GetAccountByAuthId
{
    public class GetAccountByAuthIdQueryHandler : IRequestHandler<GetAccountByAuthIdQuery, Response<AccountViewModel>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GetAccountByAuthIdQueryHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<Response<AccountViewModel>> Handle(GetAccountByAuthIdQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByAuthId(request.AuthId);
            if (account == null) throw new ApiException($"Não existe conta com o AuthId {request.AuthId}");
            var accountViewModel = _mapper.Map<AccountViewModel>(account);
            return new Response<AccountViewModel>(accountViewModel);
        }
    }
}
