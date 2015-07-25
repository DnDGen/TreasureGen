using System;
using System.Collections.Generic;
using TreasureGen.Mappers.Interfaces;
using TreasureGen.Mappers.Percentile;
using Moq;
using NUnit.Framework;

namespace TreasureGen.Tests.Unit.Mappers.Percentile
{
    [TestFixture]
    public class PercentileMapperCachingProxyTests
    {
        private IPercentileMapper proxy;
        private Mock<IPercentileMapper> mockInnerMapper;
        private Dictionary<Int32, String> table;

        [SetUp]
        public void Setup()
        {
            table = new Dictionary<Int32, String>();
            mockInnerMapper = new Mock<IPercentileMapper>();
            mockInnerMapper.Setup(m => m.Map("table name")).Returns(table);

            proxy = new PercentileMapperCachingProxy(mockInnerMapper.Object);
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