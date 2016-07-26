using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TreasureGen.Domain.Mappers.Collections;

namespace TreasureGen.Tests.Unit.Mappers.Attributes
{
    [TestFixture]
    public class AttributeMapperCachingProxyTests
    {
        private ICollectionsMapper proxy;
        private Mock<ICollectionsMapper> mockInnerMapper;
        private Dictionary<string, IEnumerable<string>> table;

        [SetUp]
        public void Setup()
        {
            table = new Dictionary<string, IEnumerable<string>>();
            mockInnerMapper = new Mock<ICollectionsMapper>();
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
            mockInnerMapper.Verify(p => p.Map(It.IsAny<string>()), Times.Once);
        }
    }
}