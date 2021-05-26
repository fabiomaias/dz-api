using DotzInc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotzInc.WebApi.Controllers.v1
{
    [Route("api/conversion")]
    [ApiController]
    [Authorize]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionService _conversionService;

        public ConversionController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        /// <summary>
        ///     Converter Dz em Reais
        /// </summary>
        /// <param name="dz">Valor para conversão.</param>
        /// <returns>Teste de retorno</returns>
        [HttpPost("dz-to-real")]
        public IActionResult DzToReal(int dz)
        {
            return Ok( _conversionService.ConvertDzInReal(dz));
        }

        /// <summary>
        ///     Converter Reais em Dz
        /// </summary>
        /// <param name="real">Valor para conversão.</param>
        /// <returns>Teste de retorno</returns>
        [HttpPost("real-to-dotz")]
        public IActionResult RealToDotz(double real)
        {
            return Ok(_conversionService.ConvertRealInDz(real));
        }
    }
}
