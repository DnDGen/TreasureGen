using System;
using System.Collections.Generic;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Mappers.Objects;
using EquipmentGen.Mappers.SpecialAbilityData;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Mappers.SpecialAbilityData
{
    [TestFixture]
    public class SpecialAbilityDataMapperCachingProxyTests
    {
        private ISpecialAbilityDataMapper proxy;
        private Mock<ISpecialAbilityDataMapper> mockInnerMapper;
        private Dictionary<String, SpecialAbilityDataObject> table;

        [SetUp]
        public void Setup()
        {
            table = new Dictionary<String, SpecialAbilityDataObject>();
            mockInnerMapper = new Mock<ISpecialAbilityDataMapper>();
            mockInnerMapper.Setup(m => m.Map("table name")).Returns(table);

            proxy = new SpecialAbilityDataMapperCachingProxy(mockInnerMapper.Object);
        }

        [Test]
        public void ReturnTableFromInnerMapper()
        {
            var result = proxy.Map("table name");
            Assert.That(result, Is.EqualTo(table));
        }

        [Test]
        public void CacheTable()
        {
            proxy.Map("table name");
            var result = proxy.Map("table name");

            Assert.That(result, Is.EqualTo(table));
            mockInnerMapper.Verify(p => p.Map(It.IsAny<String>()), Times.Once);
        }
    }
}