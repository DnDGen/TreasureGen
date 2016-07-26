using NUnit.Framework;
using TreasureGen.Domain.Selectors.Attributes;
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
        public void AttributesSelectorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ICollectionsSelector>();
        }

        [Test]
        public void SpecialAbilityAttributesSelectorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpecialAbilityAttributesSelector>();
        }

        [Test]
        public void IntelligenceAttributesSelectorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IIntelligenceAttributesSelector>();
        }

        [Test]
        public void RangeAttributesSelectorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IRangeAttributesSelector>();
        }

        [Test]
        public void BooleanPercentileSelectorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IBooleanPercentileSelector>();
        }
    }
}