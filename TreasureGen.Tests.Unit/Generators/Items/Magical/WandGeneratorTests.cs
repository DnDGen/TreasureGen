using Moq;
using NUnit.Framework;
using System;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class WandGeneratorTests
    {
        private MagicalItemGenerator wandGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IChargesGenerator> mockChargesGenerator;
        private string power;

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

            Assert.That(wand.Name, Does.StartWith("Wand of "));
            Assert.That(wand.ItemType, Is.EqualTo(ItemTypeConstants.Wand));
            Assert.That(wand.IsMagical, Is.True);
            Assert.That(wand.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(wand.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
        }

        [Test]
        public void GetWandSpellFromSelector()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Wand);
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