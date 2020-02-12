using DnDGen.TreasureGen.Selectors.Collections;
using DnDGen.TreasureGen.Selectors.Percentiles;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Integration.IoC.Modules
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
        public void TypeAndAmountPercentileSelectorIsDecorated()
        {
            var selector = InjectAndAssertDuration<ITypeAndAmountPercentileSelector>();
            Assert.That(selector, Is.InstanceOf<TypeAndAmountPercentileSelectorEventDecorator>());
        }

        [Test]
        public void TreasurePercentileSelectorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ITreasurePercentileSelector>();
        }

        [Test]
        public void TreasurePercentileSelectorHasReplacementDecorator()
        {
            var selector = InjectAndAssertDuration<ITreasurePercentileSelector>();
            Assert.That(selector, Is.InstanceOf<PercentileSelectorStringReplacementDecorator>());
        }

        [Test]
        public void SpecialAbilityDataSelectorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpecialAbilityDataSelector>();
        }

        [Test]
        public void SpecialAbilityDataSelectorIsDecorated()
        {
            var selector = InjectAndAssertDuration<ISpecialAbilityDataSelector>();
            Assert.That(selector, Is.InstanceOf<SpecialAbilityDataSelectorEventDecorator>());
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
        public void ArmorDataSelectorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IArmorDataSelector>();
        }

        [Test]
        public void WeaponDataSelectorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IWeaponDataSelector>();
        }

        [Test]
        public void ReplacementSelectorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IReplacementSelector>();
        }
    }
}