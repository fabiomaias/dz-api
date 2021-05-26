using FluentValidation;

namespace DotzInc.Application.CQRS.Accounts.Commands.UpdateBalanceDz
{
    public class UpdateBalanceDzCommandValidator : AbstractValidator<UpdateBalanceDzCommand>
    {
        public UpdateBalanceDzCommandValidator()
        {
            RuleFor(a => a.Dz)
                .NotEmpty().WithMessage("É necessário informar o valor a adicionar na conta.")
                .GreaterThan(0).WithMessage("Valor menor ou igual a 0 não é permitido");
        }
    }
}
