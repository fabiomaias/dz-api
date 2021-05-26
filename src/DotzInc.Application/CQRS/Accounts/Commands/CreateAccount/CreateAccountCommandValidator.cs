using DotzInc.Application.Interfaces.Repositories;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace DotzInc.Application.CQRS.Accounts.Commands.CreateAccount
{
    public class CreateAccountComandValidator : AbstractValidator<CreateAccountCommand>
    {
        private readonly IAccountRepository _accountRepository;
        public CreateAccountComandValidator(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

            RuleFor(a => a.AuthId)
                .MustAsync(IsUniqueId).WithMessage("Você já possui uma conta Dotz.");
            RuleFor(a => a.Dz)
                .GreaterThanOrEqualTo(0).WithMessage("Valores negativos não são permitidos.");
        }

        private async Task<bool> IsUniqueId(string authId, CancellationToken cancellationToken)
        {
            return await _accountRepository.VerifyAuthId(authId);
        }
    }
}