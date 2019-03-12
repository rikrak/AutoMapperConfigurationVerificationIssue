﻿using AutoMapper;
using AutoMapperVerifyMappings.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperVerifyMappings.Tests.Unit
{
    [TestClass]
    public class VerifyMappingTests : VerifyMappingTestBase
    {
        protected override MapperConfiguration BuildTarget()
        {
            var mce = new ApplicationMapperConfigurationExpression();
            mce.AddProfile(typeof(ApplicationMapperProfile));

            return new MapperConfiguration(mce);

        }
    }
}