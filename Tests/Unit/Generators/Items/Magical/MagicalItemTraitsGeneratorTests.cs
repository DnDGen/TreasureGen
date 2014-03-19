using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalItemTraitsGeneratorTests
    {
        private IMagicalItemTraitsGenerator generator;
        private Mock<IPercentileSelector> mockPercentileResultProvider;
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileSelector>();
            mockDice = new Mock<IDice>();
            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            generator = new MagicalItemTraitsGenerator(mockPercentileResultProvider.Object, mockDice.Object);
        }

        [Test]
        public void ReturnTraits()
        {
            var traits = generator.GenerateFor("item type");
            Assert.That(traits, Is.Not.Null);
        }

        [Test]
        public void GetTraitsFromPercentileProvider()
        {
            mockPercentileResultProvider.Setup(p => p.SelectFrom("item typeTraits", 9266)).Returns("trait");
            var traits = generator.GenerateFor("item type");
            Assert.That(traits, Contains.Item("trait"));
            Assert.That(traits.Count(), Is.EqualTo(1));
        }

        [Test]
        public void SplitsCommaDelimitedTraits()
        {
            mockPercentileResultProvider.Setup(p => p.SelectFrom("item typeTraits", 9266)).Returns("trait,other trait");
            var traits = generator.GenerateFor("item type");
            Assert.That(traits, Contains.Item("trait"));
            Assert.That(traits, Contains.Item("other trait"));
            Assert.That(traits.Count(), Is.EqualTo(2));
        }

        [Test]
        public void DoNotAddEmptyTrait()
        {
            mockPercentileResultProvider.Setup(p => p.SelectFrom("item typeTraits", 9266)).Returns(String.Empty);
            var traits = generator.GenerateFor("item type");
            Assert.That(traits, Is.Empty);
        }
    }
}