using DotzInc.Application.CQRS.Accounts.Commands.CreateAccount;
using DotzInc.Application.CQRS.Accounts.Commands.UpdateBalanceDz;
using DotzInc.Application.CQRS.Accounts.Queries.GetAccountByAuthId;
using DotzInc.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DotzInc.WebApi.Controllers.v1
{
    [Route("api/account")]
    [ApiController]
    [Authorize]
    public class AccountController : BaseApiController
    {
        /// <summary>
        ///     Criar conta
        /// </summary>
        /// <remarks>
        ///     Funcionalidade responsável por criar a conta Dotz. Se o saldo em dz não for informado, a conta será criada com incentivo inicial de 200dz.
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Cria conta e exibe dados mínimos</response>
        /// <response code="400">Usuário autenticado já possui conta Dotz.</response>         
        /// <response code="401">Token expirado, inválido ou não fornecido</response>

        [HttpPost("sign-on")]
        public async Task<IActionResult> SignOn(CreateAccountCommand command)
        {
            command.AuthId = User.Claims.Where(x => x.Type == "user_id").FirstOrDefault().Value;
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        ///     Consultar Conta Dotz
        /// </summary>
        /// <remarks>
        ///    Funcionalidade permite consultar cadastro de conta Dotz. Se o AuthId não for informado, a consulta será realiza com o do usuário autenticado.
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Retorna os dados básicos da Conta Dotz.</response>
        /// <response code="400">Usuário que tentou autenticar não possui conta Dotz.</response>         
        /// <response code="401">Token expirado, inválido ou não fornecido</response>

        [HttpGet("get-by-authid")]
        public async Task<IActionResult> GetAccountByAuthID([FromQuery] GetAccountByAuthIdQuery filter)
        {
            if(filter.AuthId == null)
                filter.AuthId = User.Claims.Where(x => x.Type == "user_id").FirstOrDefault().Value;
            return Ok(await Mediator.Send(filter));
        }


        /// <summary>
        ///     Atualizar saldo Dz
        /// </summary>
        /// <remarks>
        ///     Funcionalidade responsável por atualizar o saldo da conta Dotz.
        /// </remarks>
        /// <param name="operation"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="200">Saldo atualizado com sucesso.</response>
        /// <response code="400">Erros de validação para valor igual ou menor que 0</response>         
        /// <response code="401">Token expirado, inválido ou não fornecido</response>
        [HttpPut("update-balance-dz")]
        public async Task<IActionResult> UpdateBalanceDz(UpdateBalanceDzCommand command, [FromQuery] TypeOperationDz operation)
        {
            command.AuthId = User.Claims.Where(x => x.Type == "user_id").FirstOrDefault().Value;
            command.Operation = operation;
            return Ok(await Mediator.Send(command));
        }
    }
}