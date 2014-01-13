using D20Dice;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Factories
{
    [TestFixture]
    public class GemFactoryTests
    {
        private Mock<IDice> mockDice;
        private IGemFactory factory;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            factory = new GemFactory(mockDice.Object);
        }

        [Test]
        public void GemIsGenerated()
        {
            var gem = factory.Create();
            Assert.That(gem, Is.Not.Null);
        }
    }
}