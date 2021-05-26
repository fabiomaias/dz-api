using DotzInc.Application.Interfaces;
using DotzInc.Domain.Settings;
using Microsoft.Extensions.Options;

namespace DotzInc.Application.LocalServices
{
    class ConversionService : IConversionService
    {
        private readonly IOptions<DzConvert> _config;

        public ConversionService(IOptions<DzConvert> config)
        {
            _config = config;
        }

        public double ConvertDzInReal(int dz) => (double)dz * _config.Value.DzToReal;

        public double ConvertRealInDz(double real) => real / _config.Value.DzToReal;
    }
}
