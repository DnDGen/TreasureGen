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
        private Mock<ITypeAndAmountPercentileResultProvider> mockTypeAndAmountPercentileResultProvider;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<ITypesProvider> mockTypesProvider;
        private IGoodsGenerator generator;

        private TypeAndAmountPercentileResult typeAndAmountResult;

        [SetUp]
        public void Setup()
        {
            typeAndAmountResult = new TypeAndAmountPercentileResult();
            typeAndAmountResult.Type = "type";
            typeAndAmountResult.Amount = 2;

            mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetResultFrom(It.IsAny<String>())).Returns(typeAndAmountResult);

            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetResultFrom(typeAndAmountResult.Type + "Value")).Returns("92d66");

            var types = new[] { "description 1", "description 2" };
            mockTypesProvider = new Mock<ITypesProvider>();
            mockTypesProvider.Setup(p => p.GetTypesFor("92d66", "GoodsDescriptions")).Returns(types);

            mockDice = new Mock<IDice>();

            generator = new GoodsGenerator(mockDice.Object, mockTypeAndAmountPercentileResultProvider.Object);
        }

        [Test]
        public void GoodsAreGenerated()
        {
            var goods = generator.GenerateAtLevel(1);
            Assert.That(goods, Is.Not.Null);
        }

        [Test]
        public void GetTypeAndAmountFromProvider()
        {
            generator.GenerateAtLevel(1);
            mockTypeAndAmountPercentileResultProvider.Verify(p => p.GetResultFrom("Level1Goods"), Times.Once);
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
            typeAndAmountResult.Amount = 9266;
            var goods = generator.GenerateAtLevel(1);
            Assert.That(goods.Count(), Is.EqualTo(9266));
        }

        [Test]
        public void GetValueOfGoodFromProviderPerGood()
        {
            generator.GenerateAtLevel(1);
            mockPercentileResultProvider.Verify(p => p.GetResultFrom("typeValue"), Times.Exactly(2));
        }

        [Test]
        public void ValueDeterminedByValueResult()
        {
            mockDice.SetupSequence(d => d.Roll("92d66")).Returns(92).Returns(66);

            var good = generator.GenerateAtLevel(1);
            var firstGood = good.First();
            var secondGood = good.Last();

            Assert.That(firstGood.ValueInGold, Is.EqualTo(92));
            Assert.That(secondGood.ValueInGold, Is.EqualTo(66));
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