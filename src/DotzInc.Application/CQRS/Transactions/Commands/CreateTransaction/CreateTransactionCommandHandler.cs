using AutoMapper;
using DotzInc.Application.Exceptions;
using DotzInc.Application.Interfaces.Repositories;
using DotzInc.Application.Responses;
using DotzInc.Domain.Entities;
using DotzInc.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotzInc.Application.CQRS.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Response<int>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly IAccountRepository _accountRepository;
        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper, ICreditCardRepository creditCardRepository, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _creditCardRepository = creditCardRepository;
            _accountRepository = accountRepository;
        }
        public async Task<Response<int>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = _mapper.Map<Transaction>(request);
            transaction.Date = DateTime.Now;
            var account = await _accountRepository.GetById(request.AccountId);
            var credidtCards = await _creditCardRepository.GetByAccountId(request.AccountId);
        

            await _transactionRepository.Add(transaction);

            switch (request.Type)
            {
                case TransactionType.CreditoDz:
                    account.Dz += (int)request.Amount;
                    await _accountRepository.Update(account);
                    break;
                case TransactionType.Troca:
                    if (request.Amount > account.Dz) throw new ApiException("Sua conta não possui saldo suficiente para esta troca.");
                    account.Dz -= (int)request.Amount;
                    await _accountRepository.Update(account);
                    break;
                default:
                    foreach (var card in credidtCards)
                    {
                        if (request.Amount > card.Balance) throw new ApiException("Seu cartão de crédito não possui saldo suficiente para esta compra.");
                        card.Balance -= request.Amount;
                        await _creditCardRepository.Update(card);
                    }
                    break;
            }

            return new Response<int>(transaction.Id);
        }
    }
}
