using D20Dice;
using EquipmentGen.Core.Generation.Factories;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Factories
{
    [TestFixture]
    public class GemFactoryTests
    {
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
        }

        [Test]
        public void GemIsCreated()
        {
            var gem = GemFactory.CreateWith(mockDice.Object);
            Assert.That(gem, Is.Not.Null);
        }
    }
}