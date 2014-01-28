using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Providers.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
{
    [TestFixture]
    public class GoodsGeneratorTests
    {
        private Mock<IDice> mockDice;
        private Mock<IGoodPercentileResultProvider> mockGoodPercentileResultProvider;
        private Mock<ITypeAndAmountPercentileResultProvider> mockTypeAndAmountPercentileResultProvider;
        private IGoodsGenerator generator;

        private TypeAndAmountPercentileResult typeAndAmountResult;
        private GoodValuePercentileResult valueResult;

        [SetUp]
        public void Setup()
        {
            typeAndAmountResult = new TypeAndAmountPercentileResult();
            typeAndAmountResult.Type = "type";
            typeAndAmountResult.Amount = 2;

            valueResult = new GoodValuePercentileResult();
            valueResult.ValueRoll = "92d66";
            valueResult.Descriptions = new[] { "description 1", "description 2" };

            mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetTypeAndAmountPercentileResult(It.IsAny<String>())).Returns(typeAndAmountResult);

            mockGoodPercentileResultProvider = new Mock<IGoodPercentileResultProvider>();
            mockGoodPercentileResultProvider.Setup(p => p.GetGoodValuePercentileResult(It.IsAny<String>())).Returns(valueResult);

            mockDice = new Mock<IDice>();

            generator = new GoodsGenerator(mockGoodPercentileResultProvider.Object, mockDice.Object, mockTypeAndAmountPercentileResultProvider.Object);
        }

        [Test]
        public void GoodsAreGenerated()
        {
            var goods = generator.GenerateAtLevel(1);
            Assert.That(goods, Is.Not.Null);
        }

        [Test]
        public void GetResultFromGoodsPercentileResultProvider()
        {
            generator.GenerateAtLevel(1);
            mockTypeAndAmountPercentileResultProvider.Verify(p => p.GetTypeAndAmountPercentileResult("Level1Goods"), Times.Once);
        }

        [Test]
        public void EmptyGoodsIfNoGoodType()
        {
            typeAndAmountResult.Type = String.Empty;
            var goods = generator.GenerateAtLevel(1);
            Assert.That(goods.Any(), Is.False);
        }

        [Test]
        public void ReturnsNumberOfGoodsDeterminedByDice()
        {
            var goods = generator.GenerateAtLevel(1);
            Assert.That(goods.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetValueOfGoodFromProvider()
        {
            generator.GenerateAtLevel(1);
            mockGoodPercentileResultProvider.Verify(p => p.GetGoodValuePercentileResult("typeValue"), Times.Exactly(2));
        }

        [Test]
        public void ValueDeterminedByValueResult()
        {
            mockDice.SetupSequence(d => d.Roll(valueResult.ValueRoll)).Returns(92).Returns(66);

            var good = generator.GenerateAtLevel(1);
            var firstGood = good.First();
            var secondGood = good.ElementAt(1);

            Assert.That(firstGood.ValueInGold, Is.EqualTo(92));
            Assert.That(secondGood.ValueInGold, Is.EqualTo(66));
        }

        [Test]
        public void DescriptionDeterminedByValueResult()
        {
            mockDice.SetupSequence(d => d.Roll("1d2-1")).Returns(0).Returns(1);

            var good = generator.GenerateAtLevel(1);
            var firstGood = good.First();
            var secondGood = good.ElementAt(1);

            Assert.That(firstGood.Description, Is.EqualTo("description 1"));
            Assert.That(secondGood.Description, Is.EqualTo("description 2"));
        }
    }
}