using System;
using System.Collections.Generic;
using D20Dice;
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
        private Mock<IDice> mockDice;

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
            mockDice = new Mock<IDice>();

            wondrousItemGenerator = new WondrousItemGenerator(mockPercentileResultProvider.Object,
                mockTraitsGenerator.Object, mockIntelligenceGenerator.Object, mockAttributesProvider.Object,
                mockChargesGenerator.Object, mockDice.Object);
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
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(ItemTypeConstants.WondrousItem, It.IsAny<IEnumerable<String>>(),
                It.IsAny<Dictionary<Magic, Object>>())).Returns(false);
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, It.IsAny<Dictionary<Magic, Object>>()))
                .Returns(intelligence);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic.Keys, Is.Not.Contains(Magic.Intelligence));
        }

        [Test]
        public void GetIntelligenceIfIntelligent()
        {
            var intelligence = new Intelligence();
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(ItemTypeConstants.WondrousItem, It.IsAny<IEnumerable<String>>(),
                It.IsAny<Dictionary<Magic, Object>>())).Returns(true);
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, It.IsAny<Dictionary<Magic, Object>>()))
                .Returns(intelligence);

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
            Assert.That(item.Magic.Keys, Is.Not.Contains(Magic.Charges));
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
            Assert.That(item.Magic.Keys, Is.Not.Contains(Magic.Bonus));
        }

        [Test]
        public void GetBonusIfThereIsABonus()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems")).Returns("wondrous item +9266");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            var bonus = Convert.ToInt32(item.Magic[Magic.Bonus]);
            Assert.That(bonus, Is.EqualTo(9266));
        }

        [Test]
        public void WondrousItemsAreMagical()
        {
            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic[Magic.IsMagical], Is.True);
        }

        [Test]
        public void HornOfValhallaGetsType()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems")).Returns("Horn of Valhalla");
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("HornOfValhallaTypes")).Returns("metallic");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Horn of Valhalla (metallic)"));
        }

        [Test]
        public void IronFlaskContentsGenerated()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems")).Returns("Iron flask");
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("IronFlaskContents")).Returns("contents");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Iron flask (contents)"));
        }

        [Test]
        public void RemoveBonusBeforeGettingAttributes()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems")).Returns("wondrous item +9266");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            mockAttributesProvider.Verify(p => p.GetAttributesFor("wondrous item", "WondrousItemAttributes"), Times.Once);
        }

        [Test]
        public void RemoveTypesBeforeGettingAttributes()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems")).Returns("wondrous item type IXCCLXVI");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            mockAttributesProvider.Verify(p => p.GetAttributesFor("wondrous item", "WondrousItemAttributes"), Times.Once);
        }

        [Test]
        public void CommaTypesRemovedBeforeGettingAttributes()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems")).Returns("wondrous item, type");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            mockAttributesProvider.Verify(p => p.GetAttributesFor("wondrous item", "WondrousItemAttributes"), Times.Once);
        }

        [Test]
        public void RobeOfUsefulItemsExtraItemsDetermined()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems")).Returns("Robe of useful items");
            mockDice.Setup(d => d.d4(4)).Returns(2);
            mockPercentileResultProvider.SetupSequence(p => p.GetResultFrom("RobeOfUsefulItemsExtraItems")).Returns("item 1")
                .Returns("item 2");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Robe of useful items (extra items: item 1, item 2)"));
        }
    }
}