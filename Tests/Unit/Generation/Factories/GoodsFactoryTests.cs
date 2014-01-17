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
        private IGoodsFactory factory;

        private GoodPercentileResult result;
        private GoodValuePercentileResult valueResult;

        [SetUp]
        public void Setup()
        {
            result = new GoodPercentileResult();
            result.GoodType = GoodsConstants.Art;
            result.RollToDetermineAmount = "2";

            valueResult = new GoodValuePercentileResult();
            valueResult.ValueRoll = "92d66";
            valueResult.Descriptions = new[] { "description 1", "description 2" };

            mockGoodPercentileResultProvider = new Mock<IGoodPercentileResultProvider>();
            mockGoodPercentileResultProvider.Setup(p => p.GetGoodPercentileResult(It.IsAny<Int32>())).Returns(result);
            mockGoodPercentileResultProvider.Setup(p => p.GetGoodValuePercentileResult(It.IsAny<String>())).Returns(valueResult);

            mockDice = new Mock<IDice>();
            mockDice.Setup(d => d.Roll(result.RollToDetermineAmount)).Returns(Convert.ToInt32(result.RollToDetermineAmount));

            factory = new GoodsFactory(mockGoodPercentileResultProvider.Object, mockDice.Object);
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
            Assert.That(goods.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetValueOfGoodFromProvider()
        {
            factory.CreateAtLevel(1);
            mockGoodPercentileResultProvider.Verify(p => p.GetGoodValuePercentileResult(result.GoodType), Times.Exactly(2));
        }

        [Test]
        public void ValueDeterminedByValueResult()
        {
            mockDice.SetupSequence(d => d.Roll(valueResult.ValueRoll)).Returns(92).Returns(66);

            var good = factory.CreateAtLevel(1);
            var firstGood = good.First();
            var secondGood = good.ElementAt(1);

            Assert.That(firstGood.ValueInGold, Is.EqualTo(92));
            Assert.That(secondGood.ValueInGold, Is.EqualTo(66));
        }

        [Test]
        public void DescriptionDeterminedByValueResult()
        {
            mockDice.SetupSequence(d => d.Roll("1d2-1")).Returns(0).Returns(1);

            var good = factory.CreateAtLevel(1);
            var firstGood = good.First();
            var secondGood = good.ElementAt(1);

            Assert.That(firstGood.Description, Is.EqualTo("description 1"));
            Assert.That(secondGood.Description, Is.EqualTo("description 2"));
        }
    }
}