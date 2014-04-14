using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class ChargesGeneratorTests
    {
        private IChargesGenerator generator;
        private Mock<IDice> mockDice;
        private Mock<IAttributesSelector> mockAttributesSelector;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            generator = new ChargesGenerator(mockDice.Object, mockAttributesSelector.Object);
        }

        [Test]
        public void ReturnPercentileDividedByTwoForWands()
        {
            for (var roll = 100; roll > 0; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var charges = generator.GenerateFor(ItemTypeConstants.Wand, String.Empty);
                var expectedCharges = Math.Max(roll / 2, 1);
                Assert.That(charges, Is.EqualTo(expectedCharges));
            }
        }

        [Test]
        public void ReturnPercentileDividedByTwoForStaves()
        {
            for (var roll = 100; roll > 0; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var charges = generator.GenerateFor(ItemTypeConstants.Staff, String.Empty);
                var expectedCharges = Math.Max(roll / 2, 1);
                Assert.That(charges, Is.EqualTo(expectedCharges));
            }
        }

        [Test]
        public void GetMinAndMaxForNamedItemsFromAttributesSelector()
        {
            var attributes = new[] { "66", "92" };
            mockAttributesSelector.Setup(s => s.SelectFrom("ChargeLimits", "name")).Returns(attributes);
            mockDice.Setup(d => d.Roll("1d(92-66+1)+66-1")).Returns(9266);

            var charges = generator.GenerateFor(String.Empty, "name");
            Assert.That(charges, Is.EqualTo(9266));
        }

        [Test]
        public void ForDeckOfIllusions_ReturnFullOn90Percent()
        {
            for (var roll = 90; roll > 0; roll--)
            {
                var attributes = new[] { "66", "92" };
                mockAttributesSelector.Setup(s => s.SelectFrom("ChargeLimits", "Deck of illusions")).Returns(attributes);
                mockDice.Setup(d => d.Roll("1d(92-66+1)+66-1")).Returns(9266);
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);

                var charges = generator.GenerateFor(String.Empty, "Deck of illusions");
                Assert.That(charges, Is.EqualTo(34));
            }
        }

        [Test]
        public void ForDeckOfIllusions_ReturnFractionOn10Percent()
        {
            for (var roll = 100; roll > 90; roll--)
            {
                var attributes = new[] { "66", "92" };
                mockAttributesSelector.Setup(s => s.SelectFrom("ChargeLimits", "Deck of illusions")).Returns(attributes);
                mockDice.Setup(d => d.Roll("1d(92-66+1)+66-1")).Returns(9266);
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);

                var charges = generator.GenerateFor(String.Empty, "Deck of illusions");
                Assert.That(charges, Is.EqualTo(9266));
            }
        }
    }
}