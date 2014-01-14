using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Providers.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Factories
{
    [TestFixture]
    public class GoodsFactoryTests
    {
        private Mock<IDice> mockDice;
        private Mock<IGoodPercentileResultProvider> mockGoodPercentileResultProvider;
        private Mock<IGoodDescriptionProvider> mockGoodDescriptionProvider;
        private IGoodsFactory factory;

        private GoodPercentileResult result;

        [SetUp]
        public void Setup()
        {
            result = new GoodPercentileResult();
            result.GoodType = GoodsConstants.Art;
            result.RollToDetermineAmount = "12";

            mockGoodPercentileResultProvider = new Mock<IGoodPercentileResultProvider>();
            mockGoodPercentileResultProvider.Setup(p => p.GetGoodPercentileResult(It.IsAny<Int32>())).Returns(result);

            mockDice = new Mock<IDice>();
            mockDice.Setup(d => d.Roll(result.RollToDetermineAmount)).Returns(12);

            mockGoodDescriptionProvider = new Mock<IGoodDescriptionProvider>();
            factory = new GoodsFactory(mockGoodPercentileResultProvider.Object, mockDice.Object, mockGoodDescriptionProvider.Object);
        }

        [Test]
        public void GoodsAreGenerated()
        {
            var goods = factory.CreateAtLevel(1);
            Assert.That(goods, Is.Not.Null);
        }

        [Test]
        public void GetResultFromGoodsPercentileResultProvider()
        {
            factory.CreateAtLevel(1);
            mockGoodPercentileResultProvider.Verify(p => p.GetGoodPercentileResult(1), Times.Once);
        }

        [Test]
        public void EmptyGoodsIfNoGoodType()
        {
            result.GoodType = String.Empty;
            var goods = factory.CreateAtLevel(1);
            Assert.That(goods.Any(), Is.False);
        }

        [Test]
        public void ReturnsNumberOfGoodsDeterminedByDice()
        {
            var goods = factory.CreateAtLevel(1);
            Assert.That(goods.Count(), Is.EqualTo(12));
        }

        [Test]
        public void GetValueOfGoodFromProvider()
        {

        }
    }
}