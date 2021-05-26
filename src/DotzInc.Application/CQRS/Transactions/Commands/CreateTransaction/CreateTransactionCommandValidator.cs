using FluentValidation;

namespace DotzInc.Application.CQRS.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionComandValidator : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionComandValidator()
        {

            RuleFor(t => t.Amount)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar sem valor.")
                .GreaterThan(0).WithMessage("O valor da propriedade {PropertyName deve ser positivo e maior que 0");
            
            RuleFor(t => t.Description)
                .NotEmpty().WithMessage("O campo {PropertyName} deve estar preenchido.");
           
            RuleFor(t => t.Type)
                .IsInEnum().WithMessage("O campo {PropertyName} não possui um valor válido");
        }
    }
}