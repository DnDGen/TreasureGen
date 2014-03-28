using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Generators.Goods;
using EquipmentGen.Generators.Interfaces.Goods;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Goods
{
    [TestFixture]
    public class GoodsGeneratorTests
    {
        private Mock<IDice> mockDice;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private IGoodsGenerator generator;

        private TypeAndAmountPercentileResult typeAndAmountResult;

        [SetUp]
        public void Setup()
        {
            typeAndAmountResult = new TypeAndAmountPercentileResult();
            typeAndAmountResult.Type = "type";
            typeAndAmountResult.AmountToRoll = "2";

            mockDice = new Mock<IDice>();
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66).Returns(123);
            mockDice.Setup(d => d.Roll(typeAndAmountResult.AmountToRoll)).Returns(2);

            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>(), 92)).Returns(typeAndAmountResult);

            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockPercentileSelector.Setup(p => p.SelectFrom(typeAndAmountResult.Type + "Values", 66)).Returns("92d66");

            var types = new[] { "description 1", "description 2" };
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockAttributesSelector.Setup(p => p.SelectFrom(typeAndAmountResult.Type + "Descriptions", It.IsAny<String>())).Returns(types);

            generator = new GoodsGenerator(mockDice.Object, mockTypeAndAmountPercentileSelector.Object,
                mockPercentileSelector.Object, mockAttributesSelector.Object);
        }

        [Test]
        public void GoodsAreGenerated()
        {
            var goods = generator.GenerateAtLevel(1);
            Assert.That(goods, Is.Not.Null);
        }

        [Test]
        public void GetTypeAndAmountFromSelector()
        {
            generator.GenerateAtLevel(1);
            mockTypeAndAmountPercentileSelector.Verify(p => p.SelectFrom("Level1Goods", 92), Times.Once);
        }

        [Test]
        public void EmptyGoodsIfNoGoodType()
        {
            typeAndAmountResult.Type = String.Empty;
            var goods = generator.GenerateAtLevel(1);
            Assert.That(goods, Is.Empty);
        }

        [Test]
        public void ReturnsNumberOfGoodsDeterminedByDice()
        {
            typeAndAmountResult.AmountToRoll = "9266";
            mockDice.Setup(d => d.Roll(typeAndAmountResult.AmountToRoll)).Returns(9266);

            var goods = generator.GenerateAtLevel(1);
            Assert.That(goods.Count(), Is.EqualTo(9266));
        }

        [Test]
        public void ValueDeterminedByValueResult()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(typeAndAmountResult.Type + "Values", 66)).Returns("92d66");
            mockPercentileSelector.Setup(p => p.SelectFrom(typeAndAmountResult.Type + "Values", 123)).Returns("other roll");
            mockDice.Setup(d => d.Roll("92d66")).Returns(9266);
            mockDice.Setup(d => d.Roll("other roll")).Returns(42);

            var good = generator.GenerateAtLevel(1);
            var firstGood = good.First();
            var secondGood = good.Last();

            Assert.That(firstGood.ValueInGold, Is.EqualTo(9266));
            Assert.That(secondGood.ValueInGold, Is.EqualTo(42));
        }

        [Test]
        public void DescriptionDeterminedByValueResult()
        {
            mockDice.SetupSequence(d => d.Roll("1d2-1")).Returns(0).Returns(1);

            var good = generator.GenerateAtLevel(1);
            var firstGood = good.First();
            var secondGood = good.Last();

            Assert.That(firstGood.Description, Is.EqualTo("description 1"));
            Assert.That(secondGood.Description, Is.EqualTo("description 2"));
        }
    }
}