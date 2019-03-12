using AutoMapper;
using AutoMapperVerifyMappings.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperVerifyMappings.Tests.Unit
{
    [TestClass]
    public class VerifyMappingUsingWorkaroundTests : VerifyMappingTestBase
    {
        protected override MapperConfiguration BuildTarget()
        {
            var mce = new ApplicationMapperConfigurationExpression();
            mce.AddProfile(typeof(ApplicationMapperProfileWorkaround));

            return new MapperConfiguration(mce);

        }
    }
}