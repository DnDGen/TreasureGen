using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Generators.Goods;
using EquipmentGen.Generators.Interfaces.Goods;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;
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
            mockDice = new Mock<IDice>();
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            generator = new GoodsGenerator(mockDice.Object, mockTypeAndAmountPercentileSelector.Object, mockPercentileSelector.Object, mockAttributesSelector.Object);
            typeAndAmountResult = new TypeAndAmountPercentileResult();

            typeAndAmountResult.Type = "type";
            typeAndAmountResult.Amount = "2";
            mockDice.Setup(d => d.Roll(typeAndAmountResult.Amount)).Returns(2);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>())).Returns(typeAndAmountResult);
            mockPercentileSelector.Setup(p => p.SelectFrom(typeAndAmountResult.Type + "Values")).Returns("92d66");

            var descriptions = new[] { "description 1", "description 2" };
            mockAttributesSelector.Setup(p => p.SelectFrom(typeAndAmountResult.Type + "Descriptions", It.IsAny<String>())).Returns(descriptions);
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
            mockTypeAndAmountPercentileSelector.Verify(p => p.SelectFrom("Level1Goods"), Times.Once);
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
            typeAndAmountResult.Amount = "9266";
            mockDice.Setup(d => d.Roll(typeAndAmountResult.Amount)).Returns(9266);

            var goods = generator.GenerateAtLevel(1);
            Assert.That(goods.Count(), Is.EqualTo(9266));
        }

        [Test]
        public void ValueDeterminedByValueResult()
        {
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(typeAndAmountResult.Type + "Values")).Returns("92d66").Returns("other roll");
            mockDice.Setup(d => d.Roll("92d66")).Returns(9266);
            mockDice.Setup(d => d.Roll("other roll")).Returns(42);

            var goods = generator.GenerateAtLevel(1);
            var firstGood = goods.First();
            var secondGood = goods.Last();

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