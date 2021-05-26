using DotzInc.Application.CQRS.CreditCards.Commands.CreateCard;
using DotzInc.Application.CQRS.CreditCards.Commands.UpdateCardStatus;
using DotzInc.Application.CQRS.CreditCards.Commands.UpdateInvoiceDueDate;
using DotzInc.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DotzInc.WebApi.Controllers.v1
{
    [Route("api/card")]
    [ApiController]
    [Authorize]
    public class CreditCardController : BaseApiController
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICreditCardRepository _creditCardRepository;

        public CreditCardController(IAccountRepository accountRepository, ICreditCardRepository creditCardRepository)
        {
            _accountRepository = accountRepository;
            _creditCardRepository = creditCardRepository;
        }

        /// <summary>
        ///     Adicionar Cartão de Crédito
        /// </summary>
        /// <remarks>
        ///     Funcionalidade responsável por adicionar cartão de crédito virtual ou físico com limite compartilhado.
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPost("add")]
        public async Task<IActionResult> AddCreditCard(CreateCardCommand command)
        {
            var authId = User.Claims.Where(x => x.Type == "user_id").FirstOrDefault().Value;
            command.AccountId = _accountRepository.GetByAuthId(authId).Result.Id;
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        ///     Atualizar Status
        /// </summary>
        /// <remarks>
        ///     Funcionalidade responsável por atualizar o Status do Cartão de Crédito.
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateStatus(UpdateCardStatusCommand command)
        {
            var authId = User.Claims.Where(x => x.Type == "user_id").FirstOrDefault().Value;
            command.AccountId = _accountRepository.GetByAuthId(authId).Result.Id;
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        ///     Atualizar dia de vencimento
        /// </summary>
        /// <remarks>
        ///     Funcionalidade responsável por atualizar o dia de vencimento do Cartão de Crédito.
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("update-invoice-due-date")]
        public async Task<IActionResult> UpdateInvoiceDueDate(UpdateInvoiceDueDateCommand command)
        {
            var authId = User.Claims.Where(x => x.Type == "user_id").FirstOrDefault().Value;
            command.AccountId = _accountRepository.GetByAuthId(authId).Result.Id;
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        ///     Consultar Cartões de Crédito da Conta
        /// </summary>
        /// <remarks>
        ///    Funcionalidade permite consultar Todos cartões ativos da conta Dotz.
        /// </remarks>
        /// <returns></returns>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var authId = User.Claims.Where(x => x.Type == "user_id").FirstOrDefault().Value;
            var accountId = _accountRepository.GetByAuthId(authId).Result.Id;
            return Ok(await _creditCardRepository.GetByAccountId(accountId));
        }
    }
}