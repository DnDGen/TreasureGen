using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Factories
{
    [TestFixture]
    public class GoodsFactoryTests
    {
        private Mock<IDice> mockDice;
        private Mock<IGoodPercentileResultProvider> mockGoodPercentileResultProvider;
        private Mock<IGemFactory> mockGemFactory;
        private Mock<IArtFactory> mockArtFactory;
        private IGoodsFactory factory;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mockGoodPercentileResultProvider = new Mock<IGoodPercentileResultProvider>();
            mockGemFactory = new Mock<IGemFactory>();
            mockArtFactory = new Mock<IArtFactory>();
            factory = new GoodsFactory(mockGoodPercentileResultProvider.Object, mockDice.Object, mockGemFactory.Object, mockArtFactory.Object);
        }

        [Test]
        public void GoodsAreGenerated()
        {
            var goods = factory.CreateAtLevel(1);
            Assert.That(goods, Is.Not.Null);
        }

        [Test]
        public void ReturnsNumberOfGoodsDeterminedByDice()
        {
            mockDice.Setup(d => d.Roll(It.IsAny<String>())).Returns(9266);
            var goods = factory.CreateAtLevel(1);
            Assert.That(goods.Count(), Is.EqualTo(9266));
        }
    }
}