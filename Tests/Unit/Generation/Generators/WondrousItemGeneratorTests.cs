using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
{
    [TestFixture]
    public class WondrousItemGeneratorTests
    {
        private IMagicalItemGenerator wondrousItemGenerator;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<IMagicalItemTraitsGenerator> mockTraitsGenerator;
        private Mock<IIntelligenceGenerator> mockIntelligenceGenerator;
        private Mock<ITypesProvider> mockTypesProvider;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            mockIntelligenceGenerator = new Mock<IIntelligenceGenerator>();
            mockTypesProvider = new Mock<ITypesProvider>();

            wondrousItemGenerator = new WondrousItemGenerator(mockPercentileResultProvider.Object,
                mockTraitsGenerator.Object, mockIntelligenceGenerator.Object);
        }

        [Test]
        public void GetItemFromProvider()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems")).Returns("wondrous item");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("wondrous item"));
        }

        [Test]
        public void GetTraitsFromGenerator()
        {
            var traits = new[] { "trait 1", "trait 2" };
            mockTraitsGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem)).Returns(traits);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            foreach (var trait in traits)
                Assert.That(item.Traits, Contains.Item(trait));
        }

        [Test]
        public void GetTypesFromProvider()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems")).Returns("wondrous item");

            var types = new[] { "type 1", "type 2" };
            mockTypesProvider.Setup(p => p.GetTypesFor("wondrous item", "WondrousItemTypes")).Returns(types);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Types, Is.EqualTo(types));
        }

        [Test]
        public void GetIntelligenceFromGeneratorIfNotOneTimeUse()
        {
            var intelligence = new Intelligence();
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem)).Returns(intelligence);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Intelligence, Is.EqualTo(intelligence));
        }

        [Test]
        public void DoNotGetIntelligenceFromGeneratorIfOneTimeUse()
        {
            var intelligence = new Intelligence();
            intelligence.IsIntelligent = true;
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem)).Returns(intelligence);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems")).Returns("wondrous item");

            var types = new[] { TypeConstants.OneTimeUse };
            mockTypesProvider.Setup(p => p.GetTypesFor("wondrous item", "WondrousItemTypes")).Returns(types);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Intelligence.IsIntelligent, Is.False);
        }
    }
}