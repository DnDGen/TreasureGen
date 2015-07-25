using TreasureGen.Mappers.Attributes;
using TreasureGen.Mappers.Interfaces;
using TreasureGen.Mappers.Percentile;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Bootstrap.Modules
{
    [TestFixture]
    public class MappersModuleTests : BootstrapTests
    {
        [Test]
        public void PercentileMapperConstructedAsSingleton()
        {
            AssertSingleton<IPercentileMapper>();
        }

        [Test]
        public void PercentileMapperHasCachingProxy()
        {
            var mapper = GetNewInstanceOf<IPercentileMapper>();
            Assert.That(mapper, Is.InstanceOf<PercentileMapperCachingProxy>());
        }

        [Test]
        public void AttributesMapperConstructedAsSingleton()
        {
            AssertSingleton<IAttributesMapper>();
        }

        [Test]
        public void AttributesMapperHasCachingProxy()
        {
            var mapper = GetNewInstanceOf<IAttributesMapper>();
            Assert.That(mapper, Is.InstanceOf<AttributesMapperCachingProxy>());
        }
    }
}