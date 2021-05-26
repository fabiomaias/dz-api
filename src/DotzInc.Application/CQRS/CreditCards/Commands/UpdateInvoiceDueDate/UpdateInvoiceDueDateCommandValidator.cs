using FluentValidation;

namespace DotzInc.Application.CQRS.CreditCards.Commands.UpdateInvoiceDueDate
{
    public class UpdateInvoiceDueDateCommandValidator : AbstractValidator<UpdateInvoiceDueDateCommand>
    {
        public UpdateInvoiceDueDateCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Cartão de crédito a ser atualizado não existe.");
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
