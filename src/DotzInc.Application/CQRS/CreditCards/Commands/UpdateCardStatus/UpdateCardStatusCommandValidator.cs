using FluentValidation;

namespace DotzInc.Application.CQRS.CreditCards.Commands.UpdateCardStatus
{
    class UpdateCardStatusCommandValidator : AbstractValidator<UpdateCardStatusCommand>
    {
        public UpdateCardStatusCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Cartão de crédito a ser atualizado não existe.");
            RuleFor(c => c.CardStatus)
                .IsInEnum().WithMessage("O valor informado em {PropertyName} não é válido");
        }
    }
}
