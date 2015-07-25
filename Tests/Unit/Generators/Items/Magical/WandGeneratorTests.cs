using Moq;
using NUnit.Framework;
using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Domain.Items.Magical;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Selectors;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class WandGeneratorTests
    {
        private IMagicalItemGenerator wandGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IChargesGenerator> mockChargesGenerator;
        private String power;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            wandGenerator = new WandGenerator(mockPercentileSelector.Object, mockChargesGenerator.Object);
            power = "power";
        }

        [Test]
        public void GenerateWand()
        {
            var wand = wandGenerator.GenerateAtPower(power);

            Assert.That(wand.Name, Is.StringStarting("Wand of "));
            Assert.That(wand.ItemType, Is.EqualTo(ItemTypeConstants.Wand));
            Assert.That(wand.IsMagical, Is.True);
            Assert.That(wand.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(wand.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
        }

        [Test]
        public void GetWandSpellFromSelector()
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Wand);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("wand spell");

            var wand = wandGenerator.GenerateAtPower(power);
            Assert.That(wand.Name, Is.EqualTo("Wand of wand spell"));
        }

        [Test]
        public void GetChargesFromGenerator()
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Wand);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("wand spell");
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Wand, "wand spell")).Returns(9266);

            var wand = wandGenerator.GenerateAtPower(power);
            Assert.That(wand.Magic.Charges, Is.EqualTo(9266));
        }
    }
}