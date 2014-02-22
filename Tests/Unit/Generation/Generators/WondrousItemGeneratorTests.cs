using System;
using System.Collections.Generic;
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
        private Mock<IAttributesProvider> mockAttributesProvider;
        private Mock<IChargesGenerator> mockChargesGenerator;

        private String name;

        [SetUp]
        public void Setup()
        {
            name = "wondrous item";
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems")).Returns(name);

            mockTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            mockIntelligenceGenerator = new Mock<IIntelligenceGenerator>();
            mockAttributesProvider = new Mock<IAttributesProvider>();
            mockChargesGenerator = new Mock<IChargesGenerator>();

            wondrousItemGenerator = new WondrousItemGenerator(mockPercentileResultProvider.Object,
                mockTraitsGenerator.Object, mockIntelligenceGenerator.Object, mockAttributesProvider.Object,
                mockChargesGenerator.Object);
        }

        [Test]
        public void GetItemFromProvider()
        {
            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo(name));
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
        public void GetAttributesFromProvider()
        {
            var attributes = new[] { "type 1", "type 2" };
            mockAttributesProvider.Setup(p => p.GetAttributesFor(name, "WondrousItemAttributes")).Returns(attributes);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void DoNotGetIntelligenceIfNotIntelligent()
        {
            var intelligence = new Intelligence();
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(ItemTypeConstants.WondrousItem, It.IsAny<IEnumerable<String>>())).Returns(false);
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem)).Returns(intelligence);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic, Is.Empty);
        }

        [Test]
        public void GetIntelligenceIfIntelligent()
        {
            var intelligence = new Intelligence();
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(ItemTypeConstants.WondrousItem, It.IsAny<IEnumerable<String>>())).Returns(true);
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem)).Returns(intelligence);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic[Magic.Intelligence], Is.EqualTo(intelligence));
        }

        [Test]
        public void DoNotGetChargesIfNotCharged()
        {
            var attributes = new[] { "type 1", "type 2" };
            mockAttributesProvider.Setup(p => p.GetAttributesFor(name, "WondrousItemAttributes")).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateChargesFor(ItemTypeConstants.WondrousItem, "wondrous item")).Returns(9266);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic, Is.Empty);
        }

        [Test]
        public void GetChargesIfCharged()
        {
            var attributes = new[] { AttributeConstants.Charged };
            mockAttributesProvider.Setup(p => p.GetAttributesFor(name, "WondrousItemAttributes")).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateChargesFor(ItemTypeConstants.WondrousItem, name)).Returns(9266);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            var charges = Convert.ToInt32(item.Magic[Magic.Charges]);
            Assert.That(charges, Is.EqualTo(9266));
        }

        [Test]
        public void DoNotGetBonusIfNoBonus()
        {
            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic, Is.Empty);
        }

        [Test]
        public void GetBonusIfThereIsABonus()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems")).Returns("wondrous item +9266");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            var bonus = Convert.ToInt32(item.Magic[Magic.Bonus]);
            Assert.That(bonus, Is.EqualTo(9266));
        }
    }
}