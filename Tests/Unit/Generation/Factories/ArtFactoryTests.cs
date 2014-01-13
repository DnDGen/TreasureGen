using D20Dice;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Factories
{
    [TestFixture]
    public class ArtFactoryTests
    {
        private Mock<IDice> mockDice;
        private IArtFactory factory;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            factory = new ArtFactory(mockDice.Object);
        }

        [Test]
        public void ArtIsGenerated()
        {
            var art = factory.Create();
            Assert.That(art, Is.Not.Null);
        }
    }
}