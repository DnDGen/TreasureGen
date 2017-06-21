using Moq;
using NUnit.Framework;
using TreasureGen.Domain.Generators.Factories;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalItemGeneratorFactoryTests
    {
        private IMagicalItemGeneratorFactory factory;
        private Mock<JustInTimeFactory> mockFactory;

        [SetUp]
        public void Setup()
        {
            mockFactory = new Mock<JustInTimeFactory>();
            factory = new MagicalItemGeneratorFactory(mockFactory.Object);
        }

        [Test]
        public void FactoryMakesGenerator()
        {
            var mockGenerator = new Mock<MagicalItemGenerator>();
            mockFactory.Setup(f => f.Build<MagicalItemGenerator>("name")).Returns(mockGenerator.Object);

            var generator = factory.CreateGeneratorOf("name");
            Assert.That(generator, Is.Not.Null);
            Assert.That(generator, Is.EqualTo(mockGenerator.Object));
        }
    }
}