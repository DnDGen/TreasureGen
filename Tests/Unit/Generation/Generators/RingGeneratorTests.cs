using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
{
    [TestFixture]
    public class RingGeneratorTests
    {
        private IMagicalItemGenerator ringGenerator;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<IAttributesProvider> mockAttributesProvider;
        private Mock<IMagicalItemTraitsGenerator> mockTraitsGenerator;

        [SetUp]
        public void Setup()
        {
            mockAttributesProvider = new Mock<IAttributesProvider>();
            mockTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();

            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("Rings")).Returns("ring");

            ringGenerator = new RingGenerator();
        }

        [Test]
        public void GenerateRing()
        {
            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("ring"));
            Assert.That(ring.Magic[Magic.IsMagical], Is.True);
        }

        [Test]
        public void GetAttributesFromProvider()
        {
            var attributes = new[] { "attribute 1", "attribute 2" };
            mockAttributesProvider.Setup(p => p.GetAttributesFor("ring", "RingAttributes")).Returns(attributes);

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GetTraitsFromGenerator()
        {
            var traits = new[] { "trait 1", "trait 2" };
            mockTraitsGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Ring));

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Traits, Is.EqualTo(traits));
        }
    }
}