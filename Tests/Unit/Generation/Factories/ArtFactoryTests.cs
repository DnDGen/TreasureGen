using D20Dice;
using EquipmentGen.Core.Generation.Factories;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Factories
{
    [TestFixture]
    public class ArtFactoryTests
    {
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
        }

        [Test]
        public void ArtIsGenerated()
        {
            var art = ArtFactory.CreateWith(mockDice.Object);
            Assert.That(art, Is.Not.Null);
        }
    }
}