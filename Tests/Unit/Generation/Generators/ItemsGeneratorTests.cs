using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Providers.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
{
    [TestFixture]
    public class ItemsGeneratorTests
    {
        private Mock<ITypeAndAmountPercentileResultProvider> mockTypeAndAmountPercentileResultProvider;
        private Mock<IDice> mockDice;
        private Mock<IPowerItemGenerator> mockPowerItemGenerator;
        private IItemsGenerator generator;

        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            result = new TypeAndAmountPercentileResult();
            result.Type = "power";
            result.RollToDetermineAmount = "amount";
            mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetTypeAndAmountPercentileResult(It.IsAny<String>())).Returns(result);

            mockDice = new Mock<IDice>();

            mockPowerItemGenerator = new Mock<IPowerItemGenerator>();

            generator = new ItemsGenerator(mockTypeAndAmountPercentileResultProvider.Object, mockDice.Object, mockPowerItemGenerator.Object);
        }

        [Test]
        public void ItemsAreGenerated()
        {
            var items = generator.GenerateAtLevel(1);
            Assert.That(items, Is.Not.Null);
        }

        [Test]
        public void ItemsGeneratorGetsItemTypeFromTypeAndAmountPercentileResultProvider()
        {
            generator.GenerateAtLevel(1);
            mockTypeAndAmountPercentileResultProvider.Verify(p => p.GetTypeAndAmountPercentileResult("Level1Items"), Times.Once);
        }

        [Test]
        public void ItemsGeneratorGetsAmountFromRoll()
        {
            generator.GenerateAtLevel(1);
            mockDice.Verify(d => d.Roll(result.RollToDetermineAmount), Times.Once);
        }

        [Test]
        public void ItemsGeneratorCallsPowerItemGeneratorFiveTimesWhenAmountIsFive()
        {
            mockDice.Setup(d => d.Roll(result.RollToDetermineAmount)).Returns(5);

            generator.GenerateAtLevel(1);
            mockPowerItemGenerator.Verify(f => f.GenerateAtPower("power"), Times.Exactly(5));
        }

        [Test]
        public void ItemsGeneratorReturnsItemsFromPowerItemGenerator()
        {
            mockDice.Setup(d => d.Roll(result.RollToDetermineAmount)).Returns(2);
            var firstItem = new AlchemicalItem();
            var secondItem = new BasicItem();
            mockPowerItemGenerator.SetupSequence(f => f.GenerateAtPower("power")).Returns(firstItem).Returns(secondItem);

            var items = generator.GenerateAtLevel(1);
            Assert.That(items.Count(), Is.EqualTo(2));
            Assert.That(items, Contains.Item(firstItem));
            Assert.That(items, Contains.Item(secondItem));
        }

        [Test]
        public void IfTypeAndAmountProviderReturnsEmptyResult_ItemsGeneratorReturnsEmptyEnumerable()
        {
            result.Type = String.Empty;
            result.RollToDetermineAmount = String.Empty;
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetTypeAndAmountPercentileResult(It.IsAny<String>())).Returns(result);
            mockDice.Setup(d => d.Roll(String.Empty)).Throws(new FormatException());

            var items = generator.GenerateAtLevel(1);
            Assert.That(items, Is.Empty);
        }
    }
}