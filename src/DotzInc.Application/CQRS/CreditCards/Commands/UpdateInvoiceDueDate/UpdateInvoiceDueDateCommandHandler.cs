using AutoMapper;
using DotzInc.Application.Exceptions;
using DotzInc.Application.Interfaces.Repositories;
using DotzInc.Application.Responses;
using DotzInc.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DotzInc.Application.CQRS.CreditCards.Commands.UpdateInvoiceDueDate
{
    public class UpdateInvoiceDueDateCommandHandler : IRequestHandler<UpdateInvoiceDueDateCommand, Response<UpdateInvoiceDueDateViewModel>>
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly IMapper _mapper;

        public UpdateInvoiceDueDateCommandHandler(ICreditCardRepository creditCardRepository, IMapper mapper)
        {
            _creditCardRepository = creditCardRepository;
            _mapper = mapper;
        }

        public async Task<Response<UpdateInvoiceDueDateViewModel>> Handle(UpdateInvoiceDueDateCommand request, CancellationToken cancellationToken)
        {
            var card = await _creditCardRepository.GetById(request.Id);

            if (card == null) throw new ApiException("Cartão de crédito inexistente.");
            if (card.AccountId != request.AccountId) throw new ApiException("O cartão de crédito a ser editado não pertence a esta conta.");
            if (card.Status != CardStatus.Ativo) throw new ApiException("Cartões com status diferente de ativo não podem ser editados.");

            card.InvoiceDueDate = request.InvoiceDueDate;
            await _creditCardRepository.Update(card);
            var cardViewModel = _mapper.Map<UpdateInvoiceDueDateViewModel>(card);
            return new Response<UpdateInvoiceDueDateViewModel>(cardViewModel);
        }
    }
}
