using DotzInc.Application.Interfaces.Repositories;
using FluentValidation;

namespace DotzInc.Application.CQRS.CreditCards.Commands.CreateCard
{
    public class CreateCardComandValidator : AbstractValidator<CreateCardCommand>
    {
        private readonly ICreditCardRepository _cardRepository;
        public CreateCardComandValidator(ICreditCardRepository cardRepository)
        {
            _cardRepository = cardRepository;

            RuleFor(c => c.Type)
                 .NotNull().WithMessage("O campo {PropertyName} não pode estar vazio.");

            RuleFor(c => c.InvoiceDueDate)
                .Must(VerifyDate).WithMessage("O dia de vencimento deve ser maior que 0 e menor que 31.")
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar vazio.");
        }

        private bool VerifyDate(int number)
        {
            if (number >= 1 && number <= 31)
                return true;
            else
                return false;
        }
    }
}