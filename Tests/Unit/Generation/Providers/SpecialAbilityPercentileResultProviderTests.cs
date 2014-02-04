using System;
using D20Dice;
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
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("table name")).Returns("ability,1,2,core ability name");

            var result = provider.GetResultFrom("table name");
            Assert.That(result.Name, Is.EqualTo("ability"));
            Assert.That(result.Bonus, Is.EqualTo(1));
            Assert.That(result.Strength, Is.EqualTo(2));
        }

        [Test]
        public void DoNotParseCoreNameIfNoCoreName()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("table name")).Returns("ability,1,0");

            var result = provider.GetResultFrom("table name");
            Assert.That(result.CoreName, Is.EqualTo(result.Name));
        }

        [Test]
        public void CoreNameIsParsedIfThereIsACoreName()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("table name")).Returns("ability,1,0,core ability name");

            var result = provider.GetResultFrom("table name");
            Assert.That(result.CoreName, Is.EqualTo("core ability name"));
        }

        [Test]
        public void SpecialAbilityPercentileResultProviderThrowsFormatExceptionIfNoCommas()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom(It.IsAny<String>())).Returns("no comma in this result");
            Assert.That(() => provider.GetResultFrom("table name"), Throws.InstanceOf<FormatException>());
        }
    }
}