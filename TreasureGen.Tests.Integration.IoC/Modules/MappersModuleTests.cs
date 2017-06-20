using NUnit.Framework;
using TreasureGen.Domain.Mappers.Collections;
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
            var mapper = InjectAndAssertDuration<IPercentileMapper>();
            Assert.That(mapper, Is.InstanceOf<PercentileMapperCachingProxy>());
        }

        [Test]
        public void AttributesMapperConstructedAsSingleton()
        {
            AssertSingleton<ICollectionsMapper>();
        }

        [Test]
        public void AttributesMapperHasCachingProxy()
        {
            var mapper = InjectAndAssertDuration<ICollectionsMapper>();
            Assert.That(mapper, Is.InstanceOf<AttributesMapperCachingProxy>());
        }
    }
}