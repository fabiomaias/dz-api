using AutoMapper;
using DotzInc.Application.Mappings;
using System;
using Xunit;

namespace DotzInc.Tests
{
    public class TestBase
    {
        protected static IMapper _mapper;

        public TestBase()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new GeneralProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
    }
}
