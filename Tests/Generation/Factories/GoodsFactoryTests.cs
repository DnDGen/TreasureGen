using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Core.Generation.Factories;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Factories
{
    [TestFixture]
    public class GoodsFactoryTests
    {
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
        }

        [Test]
        public void GoodsAreGenerated()
        {
            var goods = GoodsFactory.CreateWith(mockDice.Object, 1);
            Assert.That(goods, Is.Not.Null);
        }

        [Test]
        public void ReturnsNumberOfGoodsDeterminedByDice()
        {
            mockDice.Setup(d => d.Roll(It.IsAny<String>())).Returns(9266);
            var goods = GoodsFactory.CreateWith(mockDice.Object, 1);
            Assert.That(goods.Count(), Is.EqualTo(9266));
        }
    }
}