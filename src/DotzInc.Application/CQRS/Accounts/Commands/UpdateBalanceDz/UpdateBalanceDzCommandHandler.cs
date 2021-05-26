using AutoMapper;
using DotzInc.Application.CQRS.Accounts.Shared;
using DotzInc.Application.Exceptions;
using DotzInc.Application.Interfaces.Repositories;
using DotzInc.Application.Responses;
using DotzInc.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DotzInc.Application.CQRS.Accounts.Commands.UpdateBalanceDz
{
    public class UpdateBalanceDzCommandHandler : IRequestHandler<UpdateBalanceDzCommand, Response<AccountViewModel>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public UpdateBalanceDzCommandHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<Response<AccountViewModel>> Handle(UpdateBalanceDzCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByAuthId(request.AuthId);

            if (account == null) throw new ApiException($"A conta para atualização de Dz é inexistente.");

            if (request.Operation.Equals(TypeOperationDz.Adicionar))
                account.Dz += request.Dz;
            else
                account.Dz -= request.Dz;

            await _accountRepository.Update(account);
            var accountViewModel = _mapper.Map<AccountViewModel>(account);

            return new Response<AccountViewModel>(accountViewModel);
        }
    }
}
