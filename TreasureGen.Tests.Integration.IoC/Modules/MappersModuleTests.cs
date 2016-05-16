using NUnit.Framework;
using TreasureGen.Domain.Mappers.Attributes;
using TreasureGen.Domain.Mappers.Percentile;

namespace TreasureGen.Tests.Integration.IoC.Modules
{
    [TestFixture]
    public class MappersModuleTests : IoCTests
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