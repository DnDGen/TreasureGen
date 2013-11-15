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
        public void GoodsAreSet()
        {
            var goods = GoodsFactory.CreateWith(mockDice.Object, 1);
            Assert.That(goods, Is.Not.Null);
        }
    }
}