using System;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Providers
{
    [TestFixture]
    public class SpecialAbilityPercentileResultProviderTests
    {
        private ISpecialAbilityPercentileResultProvider provider;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            provider = new SpecialAbilityPercentileResultProvider(mockPercentileResultProvider.Object);
        }

        [Test]
        public void SpecialAbilityPercentileResultProviderReturnsParsedAbility()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("table name")).Returns("ability,1,2");

            var result = provider.GetResultFrom("table name");
            Assert.That(result.Name, Is.EqualTo("ability"));
            Assert.That(result.Bonus, Is.EqualTo(1));
            Assert.That(result.Strength, Is.EqualTo(2));
        }

        [Test]
        public void SpecialAbilityPercentileResultProviderThrowsFormatExceptionIfNoCommas()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom(It.IsAny<String>())).Returns("no comma in this result");
            Assert.That(() => provider.GetResultFrom("table name"), Throws.InstanceOf<FormatException>());
        }
    }
}