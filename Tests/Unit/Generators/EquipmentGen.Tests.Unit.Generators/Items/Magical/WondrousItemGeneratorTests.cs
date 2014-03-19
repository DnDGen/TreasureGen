using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Magical;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
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

            mockDice = new Mock<IDice>();
            mockDice.Setup(d => d.Percentile(1)).Returns(9266);

            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems", 9266)).Returns(name);

            mockTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            mockIntelligenceGenerator = new Mock<IIntelligenceGenerator>();
            mockAttributesProvider = new Mock<IAttributesProvider>();
            mockChargesGenerator = new Mock<IChargesGenerator>();

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
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(It.IsAny<Dictionary<Magic, Object>>()))
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
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(It.IsAny<Dictionary<Magic, Object>>()))
                .Returns(intelligence);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic[Magic.Intelligence], Is.EqualTo(intelligence));
        }

        [Test]
        public void DoNotGetChargesIfNotCharged()
        {
            var attributes = new[] { "type 1", "type 2" };
            mockAttributesProvider.Setup(p => p.GetAttributesFor(name, "WondrousItemAttributes")).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, "wondrous item")).Returns(9266);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic.Keys, Is.Not.Contains(Magic.Charges));
        }

        [Test]
        public void GetChargesIfCharged()
        {
            var attributes = new[] { AttributeConstants.Charged };
            mockAttributesProvider.Setup(p => p.GetAttributesFor(name, "WondrousItemAttributes")).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, name)).Returns(9266);

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
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems", 9266)).Returns("wondrous item +9266");

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
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66);

            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems", 92)).Returns("Horn of Valhalla");
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("HornOfValhallaTypes", 66)).Returns("metallic");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Horn of Valhalla (metallic)"));
        }

        [Test]
        public void IronFlaskContentsGenerated()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66);

            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems", 92)).Returns("Iron flask");
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("IronFlaskContents", 66)).Returns("contents");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Iron flask (contents)"));
        }

        [Test]
        public void RemoveBonusBeforeGettingAttributes()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems", 9266)).Returns("wondrous item +9266");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            mockAttributesProvider.Verify(p => p.GetAttributesFor("wondrous item", "WondrousItemAttributes"), Times.Once);
        }

        [Test]
        public void RemoveTypesBeforeGettingAttributes()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems", 9266)).Returns("wondrous item type IXCCLXVI");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            mockAttributesProvider.Verify(p => p.GetAttributesFor("wondrous item", "WondrousItemAttributes"), Times.Once);
        }

        [Test]
        public void CommaTypesRemovedBeforeGettingAttributes()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems", 9266)).Returns("wondrous item, type");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            mockAttributesProvider.Verify(p => p.GetAttributesFor("wondrous item", "WondrousItemAttributes"), Times.Once);
        }

        [Test]
        public void RobeOfUsefulItemsExtraItemsDetermined()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66).Returns(42);

            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems", 92)).Returns("Robe of useful items");
            mockDice.Setup(d => d.d4(4)).Returns(2);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("RobeOfUsefulItemsExtraItems", 66)).Returns("item 1");
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("RobeOfUsefulItemsExtraItems", 42)).Returns("item 2");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Robe of useful items (extra items: item 1, item 2)"));
        }

        [Test]
        public void CubicGateGetsPlanes()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(1).Returns(2).Returns(3).Returns(4).Returns(5);

            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems", 92)).Returns("Cubic gate");
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("Planes", 1)).Returns("plane 1");
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("Planes", 2)).Returns("plane 2");
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("Planes", 3)).Returns("plane 3");
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("Planes", 4)).Returns("plane 4");
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("Planes", 5)).Returns("plane 5");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Cubic gate (Material plane, plane 1, plane 2, plane 3, plane 4, plane 5)"));
        }

        [Test]
        public void CubicGateGetsDistinctPlanes()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(1).Returns(1).Returns(2).Returns(3).Returns(4)
                .Returns(5);

            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerWondrousItems", 92)).Returns("Cubic gate");
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("Planes", 1)).Returns("plane 1");
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("Planes", 2)).Returns("plane 2");
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("Planes", 3)).Returns("plane 3");
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("Planes", 4)).Returns("plane 4");
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("Planes", 5)).Returns("plane 5");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Cubic gate (Material plane, plane 1, plane 2, plane 3, plane 4, plane 5)"));
        }
    }
}