using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Providers.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Factories
{
    [TestFixture]
    public class ItemsFactoryTests
    {
        private Mock<ITypeAndAmountPercentileResultProvider> mockTypeAndAmountPercentileResultProvider;
        private Mock<IDice> mockDice;
        private Mock<IPowerFactoryFactory> mockPowerFactoryFactory;
        private Mock<IPowerFactory> mockPowerFactory;
        private IItemsFactory factory;

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

            mockPowerFactory = new Mock<IPowerFactory>();
            mockPowerFactoryFactory = new Mock<IPowerFactoryFactory>();
            mockPowerFactoryFactory.Setup(f => f.CreateWith(It.IsAny<String>())).Returns(mockPowerFactory.Object);

            factory = new ItemsFactory(mockTypeAndAmountPercentileResultProvider.Object, mockDice.Object, mockPowerFactoryFactory.Object);
        }

        [Test]
        public void ItemsAreGenerated()
        {
            var items = factory.CreateAtLevel(1);
            Assert.That(items, Is.Not.Null);
        }

        [Test]
        public void ItemsFactoryGetsItemTypeFromTypeAndAmountPercentileResultProvider()
        {
            factory.CreateAtLevel(1);
            mockTypeAndAmountPercentileResultProvider.Verify(p => p.GetTypeAndAmountPercentileResult("Level1Items"), Times.Once);
        }

        [Test]
        public void ItemsFactoryGetsAmountFromRoll()
        {
            factory.CreateAtLevel(1);
            mockDice.Verify(d => d.Roll(result.RollToDetermineAmount), Times.Once);
        }

        [Test]
        public void ItemsFactoryGetsPowerFactoryFromPowerFactoryFactory()
        {
            factory.CreateAtLevel(1);
            mockPowerFactoryFactory.Verify(f => f.CreateWith("power"), Times.Once);
        }

        [Test]
        public void ItemsFactoryCallsPowerFactoryFiveTimesWhenAmountIsFive()
        {
            mockDice.Setup(d => d.Roll(result.RollToDetermineAmount)).Returns(5);

            factory.CreateAtLevel(1);
            mockPowerFactory.Verify(f => f.Create(), Times.Exactly(5));
        }

        [Test]
        public void ItemsFactoryReturnsItemsFromPowerFactory()
        {
            mockDice.Setup(d => d.Roll(result.RollToDetermineAmount)).Returns(2);
            var firstItem = new AlchemicalItem();
            var secondItem = new BasicItem();
            mockPowerFactory.SetupSequence(f => f.Create()).Returns(firstItem).Returns(secondItem);

            var items = factory.CreateAtLevel(1);
            Assert.That(items.Count(), Is.EqualTo(2));
            Assert.That(items, Contains.Item(firstItem));
            Assert.That(items, Contains.Item(secondItem));
        }
    }
}