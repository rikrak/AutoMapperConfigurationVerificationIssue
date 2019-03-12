using System;
using AutoMapper;
using AutoMapperVerifyMappings.Mapping;
using AutoMapperVerifyMappings.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperVerifyMappings.Tests.Unit
{
    [TestClass]
    public class VerifyMappingTests
    {
        private MapperConfiguration _target;

        [TestInitialize]
        public void Setup()
        {
            var mce = new ApplicationMapperConfigurationExpression();
            mce.AddProfiles(typeof(ApplicationMapperProfile));

            _target = new MapperConfiguration(mce);

        }

        [TestMethod]
        public void VerifyConfiguration()
        {
            // arrange

            // act

            // assert
            _target.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void VerifyMapping_1()
        {
            // arrange
            var effectiveFromDate = new DateTime(2018, 10, 12);
            const int itemId = 23;

            var source = new MainViewModel()
            {
                EffectiveFrom = effectiveFromDate,
                Item = new ReferenceViewModel()
                {
                    Id = itemId,
                    Name = Guid.NewGuid().ToString()
                }
            };
            var mapper = _target.CreateMapper();

            // act
            var actual = mapper.Map<MainModel>(source);

            // assert
            actual.Id.Should().Be(DataConstants.UndefinedId);
            actual.EffectiveFrom.Should().Be(effectiveFromDate);
            actual.ItemId.Should().Be(itemId);
        }

        [TestMethod]
        public void VerifyMapping_HasNoReferenceItem()
        {
            // arrange
            var effectiveFromDate = new DateTime(2018, 10, 12);

            var source = new MainViewModel()
            {
                EffectiveFrom = effectiveFromDate,
                Item = null
            };
            var mapper = _target.CreateMapper();

            // act
            var actual = mapper.Map<MainModel>(source);

            // assert
            actual.Id.Should().Be(DataConstants.UndefinedId);
            actual.EffectiveFrom.Should().Be(effectiveFromDate);
            actual.ItemId.Should().Be(DataConstants.UndefinedId);
        }
    }
}