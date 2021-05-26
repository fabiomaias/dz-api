using DotzInc.Application.CQRS.Transactions.Commands.CreateTransaction;
using DotzInc.Application.CQRS.Transactions.Queries;
using DotzInc.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DotzInc.WebApi.Controllers.v1
{
    [Route("api/transaction")]
    [ApiController]
    [Authorize]
    public class TransactionController : BaseApiController
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICreditCardRepository _creditCardRepository;

        public TransactionController(IAccountRepository accountRepository, ICreditCardRepository creditCardRepository)
        {
            _accountRepository = accountRepository;
            _creditCardRepository = creditCardRepository;
        }

        /// <summary>
        ///     Adiciona uma transação
        /// </summary>
        /// <remarks>
        ///     Funcionalidade responsável simular uma transação.
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPost("add")]
        public async Task<IActionResult> AddTransaction(CreateTransactionCommand command)
        {
            var authId = User.Claims.Where(x => x.Type == "user_id").FirstOrDefault().Value;
            command.AccountId = _accountRepository.GetByAuthId(authId).Result.Id;
            return Ok(await Mediator.Send(command));
        }


        /// <summary>
        ///     Consultar Transações
        /// </summary>
        /// <remarks>
        ///    Funcionalidade permite consultar transações da conta Dotz aplicando filtro de paginação.
        /// </remarks>
        /// <param name="filter">Valor</param>
        /// <returns></returns>
        [HttpGet("get-all")]
        public async Task<IActionResult> Get([FromQuery] GetAllTransactionsParameter filter)
        {
            var authId = User.Claims.Where(x => x.Type == "user_id").FirstOrDefault().Value;
            var accountId = _accountRepository.GetByAuthId(authId).Result.Id;
            return Ok(await Mediator.Send(new GetAllTransactionsQuery() { MaxResults = filter.MaxResults, PageSize = filter.PageNumber }));
        }
    }
}