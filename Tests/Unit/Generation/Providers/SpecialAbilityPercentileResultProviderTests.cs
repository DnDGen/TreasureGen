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
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockDice = new Mock<IDice>();
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
        public void CoreNameIsNameIfStrengthIsZero()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("table name")).Returns("ability,1,0,core ability name");

            var result = provider.GetResultFrom("table name");
            Assert.That(result.CoreName, Is.EqualTo(result.Name));
        }

        [Test]
        public void DoNotParseCoreNameIfStrengthIsZero()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("table name")).Returns("ability,1,0");

            var result = provider.GetResultFrom("table name");
            Assert.That(result.CoreName, Is.EqualTo(result.Name));
        }

        [Test]
        public void CoreNameIsParsedIfStrengthIsGreaterThanZero()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("table name")).Returns("ability,1,1,core ability name");

            var result = provider.GetResultFrom("table name");
            Assert.That(result.CoreName, Is.EqualTo("core ability name"));
        }

        [Test]
        public void SpecialAbilityPercentileResultProviderThrowsFormatExceptionIfNoCommas()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom(It.IsAny<String>())).Returns("no comma in this result");
            Assert.That(() => provider.GetResultFrom("table name"), Throws.InstanceOf<FormatException>());
        }

        [Test]
        public void BaneAbilityGetsDesignatedFoe()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("table name")).Returns("Bane,0,0");
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("DesignatedFoes")).Returns("designated foe");

            var result = provider.GetResultFrom("table name");
            Assert.That(result.CoreName, Is.EqualTo("Bane"));
            Assert.That(result.Name, Is.EqualTo("Bane (designated foe)"));
        }

        [Test]
        public void SpellStoringAbilityDoesNotHaveSpellIfBelow51()
        {
            Assert.Fail();
        }

        [Test]
        public void SpellStoringAbilityHasSpellIfAbove50()
        {
            Assert.Fail();
        }
    }
}