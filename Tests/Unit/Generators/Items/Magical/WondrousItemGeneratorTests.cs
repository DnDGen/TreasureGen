using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class WondrousItemGeneratorTests
    {
        private IMagicalItemGenerator wondrousItemGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IMagicalItemTraitsGenerator> mockTraitsGenerator;
        private Mock<IIntelligenceGenerator> mockIntelligenceGenerator;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private Mock<IChargesGenerator> mockChargesGenerator;
        private Mock<IDice> mockDice;
        private Mock<ICurseGenerator> mockCurseGenerator;

        private String name;

        [SetUp]
        public void Setup()
        {
            name = "wondrous item";

            mockDice = new Mock<IDice>();
            mockDice.Setup(d => d.Percentile(1)).Returns(9266);

            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems", 9266)).Returns(name);

            mockTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            mockIntelligenceGenerator = new Mock<IIntelligenceGenerator>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            mockCurseGenerator = new Mock<ICurseGenerator>();

            wondrousItemGenerator = new WondrousItemGenerator(mockPercentileSelector.Object,
                mockTraitsGenerator.Object, mockIntelligenceGenerator.Object, mockAttributesSelector.Object,
                mockChargesGenerator.Object, mockDice.Object, mockCurseGenerator.Object);
        }

        [Test]
        public void GetItemFromSelector()
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
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "type 1", "type 2" };
            mockAttributesSelector.Setup(p => p.SelectFrom("WondrousItemAttributes", name)).Returns(attributes);

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
            mockAttributesSelector.Setup(p => p.SelectFrom("WondrousItemAttributes", name)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, "wondrous item")).Returns(9266);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic.Keys, Is.Not.Contains(Magic.Charges));
        }

        [Test]
        public void GetChargesIfCharged()
        {
            var attributes = new[] { AttributeConstants.Charged };
            mockAttributesSelector.Setup(p => p.SelectFrom("WondrousItemAttributes", name)).Returns(attributes);

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
            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems", 9266)).Returns("wondrous item +9266");

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

            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems", 92)).Returns("Horn of Valhalla");
            mockPercentileSelector.Setup(p => p.SelectFrom("HornOfValhallaTypes", 66)).Returns("metallic");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Horn of Valhalla (metallic)"));
        }

        [Test]
        public void IronFlaskContentsGenerated()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66);

            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems", 92)).Returns("Iron flask");
            mockPercentileSelector.Setup(p => p.SelectFrom("IronFlaskContents", 66)).Returns("contents");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Iron flask (contents)"));
        }

        [Test]
        public void RemoveBonusBeforeGettingAttributes()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems", 9266)).Returns("wondrous item +9266");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            mockAttributesSelector.Verify(p => p.SelectFrom("WondrousItemAttributes", "wondrous item"), Times.Once);
        }

        [Test]
        public void RemoveTypesBeforeGettingAttributes()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems", 9266)).Returns("wondrous item type IXCCLXVI");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            mockAttributesSelector.Verify(p => p.SelectFrom("WondrousItemAttributes", "wondrous item"), Times.Once);
        }

        [Test]
        public void CommaTypesRemovedBeforeGettingAttributes()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems", 9266)).Returns("wondrous item, type");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            mockAttributesSelector.Verify(p => p.SelectFrom("WondrousItemAttributes", "wondrous item"), Times.Once);
        }

        [Test]
        public void RobeOfUsefulItemsExtraItemsDetermined()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66).Returns(42);

            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems", 92)).Returns("Robe of useful items");
            mockDice.Setup(d => d.d4(4)).Returns(2);
            mockPercentileSelector.Setup(p => p.SelectFrom("RobeOfUsefulItemsExtraItems", 66)).Returns("item 1");
            mockPercentileSelector.Setup(p => p.SelectFrom("RobeOfUsefulItemsExtraItems", 42)).Returns("item 2");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Robe of useful items (extra items: item 1, item 2)"));
        }

        [Test]
        public void CubicGateGetsPlanes()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(1).Returns(2).Returns(3).Returns(4).Returns(5);

            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems", 92)).Returns("Cubic gate");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes", 1)).Returns("plane 1");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes", 2)).Returns("plane 2");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes", 3)).Returns("plane 3");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes", 4)).Returns("plane 4");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes", 5)).Returns("plane 5");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Cubic gate (Material plane, plane 1, plane 2, plane 3, plane 4, plane 5)"));
        }

        [Test]
        public void CubicGateGetsDistinctPlanes()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(1).Returns(1).Returns(2).Returns(3).Returns(4)
                .Returns(5);

            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems", 92)).Returns("Cubic gate");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes", 1)).Returns("plane 1");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes", 2)).Returns("plane 2");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes", 3)).Returns("plane 3");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes", 4)).Returns("plane 4");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes", 5)).Returns("plane 5");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Cubic gate (Material plane, plane 1, plane 2, plane 3, plane 4, plane 5)"));
        }

        [Test]
        public void DoNotGetCurseIfNotCursed()
        {
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<Dictionary<Magic, Object>>())).Returns(false);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic.Keys, Is.Not.Contains(Magic.Curse));
        }

        [Test]
        public void GetCurseIfCursed()
        {
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<Dictionary<Magic, Object>>())).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic.Keys, Contains.Item(Magic.Curse));
            Assert.That(item.Magic[Magic.Curse], Is.EqualTo("cursed"));
        }

        [Test]
        public void GetSpecificCursedItems()
        {
            var cursedItem = new Item();
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<Dictionary<Magic, Object>>())).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("SpecificCursedItem");
            mockCurseGenerator.Setup(g => g.GenerateSpecificCursedItem()).Returns(cursedItem);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(cursedItem));
        }
    }
}