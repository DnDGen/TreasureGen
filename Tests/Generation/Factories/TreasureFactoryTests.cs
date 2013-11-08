using D20Dice.Dice;
using EquipmentGen.Core.Generation.Factories;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Factories
{
    public class TreasureFactoryTests
    {
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
        }

        [Test]
        public void TreasureFactoryReturnsTreasure()
        {
            var treasure = TreasureFactory.CreateUsing(mockDice.Object);
            Assert.That(treasure, Is.Not.Null);
        }
    }
}