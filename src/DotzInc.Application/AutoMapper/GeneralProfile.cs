using AutoMapper;
using DotzInc.Application.CQRS.Accounts.Commands.CreateAccount;
using DotzInc.Application.CQRS.Accounts.Commands.UpdateBalanceDz;
using DotzInc.Application.CQRS.Accounts.Queries.GetAccountByAuthId;
using DotzInc.Application.CQRS.Accounts.Shared;
using DotzInc.Application.CQRS.CreditCards.Commands.CreateCard;
using DotzInc.Application.CQRS.CreditCards.Commands.UpdateCardStatus;
using DotzInc.Application.CQRS.CreditCards.Commands.UpdateInvoiceDueDate;
using DotzInc.Application.CQRS.Transactions.Commands.CreateTransaction;
using DotzInc.Application.CQRS.Transactions.Queries;
using DotzInc.Domain.Entities;

namespace DotzInc.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateAccountCommand, Account>();
            CreateMap<UpdateBalanceDzCommand, Account>();
            CreateMap<GetAccountByAuthIdQuery, Account>();
            CreateMap<Account, AccountViewModel>().ReverseMap();

            CreateMap<CreateCardCommand, CreditCard>();
            CreateMap<UpdateCardStatusCommand, CreditCard>();
            CreateMap<CreditCard, UpdateCardStatusViewModel>().ReverseMap();
            CreateMap<UpdateInvoiceDueDateCommand, CreditCard>();
            CreateMap<CreditCard, UpdateInvoiceDueDateViewModel>().ReverseMap();

            CreateMap<CreateTransactionCommand, Transaction>();
            CreateMap<GetAllTransactionsQuery, Transaction>();
            CreateMap<GetAllTransactionsQuery, GetAllTransactionsParameter>();
            CreateMap<Transaction, GetAllTransactionsViewModel>().ReverseMap();
        }
    }
}
