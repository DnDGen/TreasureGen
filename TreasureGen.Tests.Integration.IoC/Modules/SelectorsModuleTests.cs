using NUnit.Framework;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Percentiles;

namespace TreasureGen.Tests.Integration.IoC.Modules
{
    [TestFixture]
    public class SelectorsModuleTests : IoCTests
    {
        [Test]
        public void TypeAndAmountPercentileSelectorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ITypeAndAmountPercentileSelector>();
        }

        [Test]
        public void PercentileSelectorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IPercentileSelector>();
        }

        [Test]
        public void PercentileSelectorHasReplacementDecorator()
        {
            var selector = GetNewInstanceOf<IPercentileSelector>();
            Assert.That(selector, Is.InstanceOf<ReplacePercentileSelectorDecorator>());
        }

        [Test]
        public void CollectionsSelectorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ICollectionsSelector>();
        }

        [Test]
        public void SpecialAbilityDataSelectorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpecialAbilityDataSelector>();
        }

        [Test]
        public void IntelligenceDataSelectorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IIntelligenceDataSelector>();
        }

        [Test]
        public void RangeDataSelectorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IRangeDataSelector>();
        }

        [Test]
        public void BooleanPercentileSelectorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IBooleanPercentileSelector>();
        }

        [Test]
        public void ArmorDataSelectorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IArmorDataSelector>();
        }

        [Test]
        public void WeaponDataSelectorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IWeaponDataSelector>();
        }
    }
}