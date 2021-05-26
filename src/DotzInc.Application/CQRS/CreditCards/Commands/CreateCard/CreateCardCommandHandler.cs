using AutoMapper;
using DotzInc.Application.Exceptions;
using DotzInc.Application.Interfaces.Repositories;
using DotzInc.Application.Responses;
using DotzInc.Domain.Entities;
using DotzInc.Domain.Enums;
using Edi.CreditCardUtils;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotzInc.Application.CQRS.CreditCards.Commands.CreateCard
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, Response<int>>
    {
        private readonly ICreditCardRepository _cardRepository;
        private readonly IMapper _mapper;
        public CreateCardCommandHandler(ICreditCardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var cardExists = await _cardRepository.VerifyIfExists(request.AccountId, request.Type);
            if(cardExists) throw new ApiException($"Sua conta Dotz já possui um cartão {request.Type} de crédito ativo do tipo solicitado.");

            var card = _mapper.Map<CreditCard>(request);
            //TODO: Verificar duplicidade do número gerado
            var creditCardNumber = CreditCardGenerator.GenerateCardNumber("485246", 16);
     
            card.Number = creditCardNumber;
            card.SecurityCode = new Random().Next(100, 999);
            card.Status = CardStatus.Ativo;
            // TODO: Alterar data completa para mês/ano
            card.ExpirationDate = DateTime.Now.AddYears(5);
            await _cardRepository.Add(card);
            
            return new Response<int>(card.Id);
        }
    }
}
