using System;
using System.Collections.Generic;
using EquipmentGen.Mappers.Attributes;
using EquipmentGen.Mappers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Mappers.Attributes
{
    [TestFixture]
    public class AttributeMapperCachingProxyTests
    {
        private IAttributesMapper proxy;
        private Mock<IAttributesMapper> mockInnerMapper;
        private Dictionary<String, IEnumerable<String>> table;

        [SetUp]
        public void Setup()
        {
            table = new Dictionary<String, IEnumerable<String>>();
            mockInnerMapper = new Mock<IAttributesMapper>();
            mockInnerMapper.Setup(m => m.Map("table name")).Returns(table);

            proxy = new AttributesMapperCachingProxy(mockInnerMapper.Object);
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