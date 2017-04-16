using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class PotionGeneratorTests
    {
        private MagicalItemGenerator potionGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private string power;
        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            itemVerifier = new ItemVerifier();
            potionGenerator = new PotionGenerator(mockTypeAndAmountPercentileSelector.Object, mockPercentileSelector.Object);

            var result = new TypeAndAmountPercentileResult();
            result.Amount = 9266;
            result.Type = "potion";
            power = "power";

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Potion);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(result);
        }

        [Test]
        public void GeneratePotion()
        {
            var potion = potionGenerator.GenerateAtPower(power);
            Assert.That(potion.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(potion.IsMagical, Is.True);
            Assert.That(potion.Name, Is.EqualTo("potion"));
            Assert.That(potion.BaseNames.Single(), Is.EqualTo("potion"));
            Assert.That(potion.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(potion.Quantity, Is.EqualTo(1));
            Assert.That(potion.ItemType, Is.EqualTo(ItemTypeConstants.Potion));
        }

        [Test]
        public void GenerateCustomPotion()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var potion = potionGenerator.Generate(template);
            itemVerifier.AssertMagicalItemFromTemplate(potion, template);
            Assert.That(potion.BaseNames.Single(), Is.EqualTo(name));
            Assert.That(potion.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(potion.IsMagical, Is.True);
            Assert.That(potion.ItemType, Is.EqualTo(ItemTypeConstants.Potion));
            Assert.That(potion.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void GenerateRandomCustomPotion()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var potion = potionGenerator.Generate(template, true);
            itemVerifier.AssertMagicalItemFromTemplate(potion, template);
            Assert.That(potion.BaseNames.Single(), Is.EqualTo(name));
            Assert.That(potion.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(potion.IsMagical, Is.True);
            Assert.That(potion.ItemType, Is.EqualTo(ItemTypeConstants.Potion));
            Assert.That(potion.Quantity, Is.EqualTo(1));
        }
    }
}