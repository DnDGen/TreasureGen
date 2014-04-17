using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class ChargesGeneratorTests
    {
        private IChargesGenerator generator;
        private Mock<IDice> mockDice;
        private Mock<IRangeAttributesSelector> mockRangeAttributesSelector;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mockRangeAttributesSelector = new Mock<IRangeAttributesSelector>();
            generator = new ChargesGenerator(mockDice.Object, mockRangeAttributesSelector.Object);
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
            var result = new RangeAttributesResult();
            result.Maximum = 92;
            result.Minimum = 66;

            mockRangeAttributesSelector.Setup(s => s.SelectFrom("ChargeLimits", "name")).Returns(result);
            mockDice.Setup(d => d.Roll("1d27")).Returns(9266);

            var charges = generator.GenerateFor(String.Empty, "name");
            Assert.That(charges, Is.EqualTo(9331));
        }

        [Test]
        public void ForDeckOfIllusions_ReturnFullOn90Percent()
        {
            var result = new RangeAttributesResult();
            result.Maximum = 92;
            result.Minimum = 66;

            mockRangeAttributesSelector.Setup(s => s.SelectFrom("ChargeLimits", "Deck of illusions")).Returns(result);
            mockDice.Setup(d => d.Roll("1d27")).Returns(9266);

            for (var roll = 90; roll > 0; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);

                var charges = generator.GenerateFor(String.Empty, "Deck of illusions");
                Assert.That(charges, Is.EqualTo(34));
            }
        }

        [Test]
        public void ForDeckOfIllusions_ReturnFractionOn10Percent()
        {
            var result = new RangeAttributesResult();
            result.Maximum = 92;
            result.Minimum = 66;

            mockRangeAttributesSelector.Setup(s => s.SelectFrom("ChargeLimits", "Deck of illusions")).Returns(result);
            mockDice.Setup(d => d.Roll("1d27")).Returns(9266);

            for (var roll = 100; roll > 90; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);

                var charges = generator.GenerateFor(String.Empty, "Deck of illusions");
                Assert.That(charges, Is.EqualTo(9331));
            }
        }
    }
}