using AutoMapper;
using DotzInc.Application.CQRS.Accounts.Shared;
using DotzInc.Application.Interfaces.Repositories;
using DotzInc.Application.Responses;
using DotzInc.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DotzInc.Application.CQRS.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Response<AccountViewModel>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public CreateAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        public async Task<Response<AccountViewModel>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = _mapper.Map<Account>(request);
            await _accountRepository.Add(account);
            
            var accountViewModel = _mapper.Map<AccountViewModel>(account);
            return new Response<AccountViewModel>(accountViewModel);
        }
    }
}
