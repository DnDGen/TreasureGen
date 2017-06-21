using Moq;
using NUnit.Framework;
using TreasureGen.Domain.Generators.Factories;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class MundaneItemGeneratorFactoryTests
    {
        private IMundaneItemGeneratorFactory factory;
        private Mock<JustInTimeFactory> mockFactory;

        [SetUp]
        public void Setup()
        {
            mockFactory = new Mock<JustInTimeFactory>();
            factory = new MundaneItemGeneratorFactory(mockFactory.Object);
        }

        [Test]
        public void FactoryMakesGenerator()
        {
            var mockGenerator = new Mock<MundaneItemGenerator>();
            mockFactory.Setup(f => f.Build<MundaneItemGenerator>("name")).Returns(mockGenerator.Object);

            var generator = factory.CreateGeneratorOf("name");
            Assert.That(generator, Is.Not.Null);
            Assert.That(generator, Is.EqualTo(mockGenerator.Object));
        }
    }
}