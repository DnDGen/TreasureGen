using EquipmentGen.Selectors.Decorators;
using EquipmentGen.Selectors.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Bootstrap.Modules
{
    [TestFixture]
    public class SelectorsModuleTests : BootstrapTests
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
            AssertNotSingleton<IAttributesSelector>();
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