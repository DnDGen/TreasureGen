using System;
using System.Collections.Generic;
using System.Linq;
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
        private Mock<ISpellGenerator> mockSpellGenerator;

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
            mockSpellGenerator = new Mock<ISpellGenerator>();

            wondrousItemGenerator = new WondrousItemGenerator(mockPercentileSelector.Object,
                mockTraitsGenerator.Object, mockIntelligenceGenerator.Object, mockAttributesSelector.Object,
                mockChargesGenerator.Object, mockDice.Object, mockCurseGenerator.Object, mockSpellGenerator.Object);
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
            intelligence.Ego = 9266;
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(ItemTypeConstants.WondrousItem, It.IsAny<IEnumerable<String>>(),
                It.IsAny<Boolean>())).Returns(false);
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(It.IsAny<Magic>())).Returns(intelligence);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic.Intelligence, Is.Not.EqualTo(intelligence));
            Assert.That(item.Magic.Intelligence.Ego, Is.EqualTo(0));
        }

        [Test]
        public void GetIntelligenceIfIntelligent()
        {
            var intelligence = new Intelligence();
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(ItemTypeConstants.WondrousItem, It.IsAny<IEnumerable<String>>(),
                It.IsAny<Boolean>())).Returns(true);
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(It.IsAny<Magic>())).Returns(intelligence);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic.Intelligence, Is.EqualTo(intelligence));
        }

        [Test]
        public void DoNotGetChargesIfNotCharged()
        {
            var attributes = new[] { "type 1", "type 2" };
            mockAttributesSelector.Setup(p => p.SelectFrom("WondrousItemAttributes", name)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, "wondrous item")).Returns(9266);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public void GetChargesIfCharged()
        {
            var attributes = new[] { AttributeConstants.Charged };
            mockAttributesSelector.Setup(p => p.SelectFrom("WondrousItemAttributes", name)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, name)).Returns(9266);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic.Charges, Is.EqualTo(9266));
        }

        [Test]
        public void DoNotGetBonusIfNoBonus()
        {
            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic.Bonus, Is.EqualTo(0));
        }

        [Test]
        public void GetBonusIfThereIsABonus()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems", 9266)).Returns("wondrous item +9266");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
        }

        [Test]
        public void WondrousItemsAreMagical()
        {
            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.IsMagical, Is.True);
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
            Assert.That(item.Name, Is.EqualTo("Iron flask"));
            Assert.That(item.Contents, Contains.Item("contents"));
        }

        [Test]
        public void IronFlaskOnlyContainsOneThing()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66);

            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems", 92)).Returns("Iron flask");
            mockPercentileSelector.SetupSequence(p => p.SelectFrom("IronFlaskContents", 66)).Returns("contents").Returns("more contents");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Iron flask"));
            Assert.That(item.Contents, Contains.Item("contents"));
            Assert.That(item.Contents.Count, Is.EqualTo(1));
        }

        [Test]
        public void IfBalorOrPitFiend_GetFromSelector()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66);

            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems", 92)).Returns("Iron flask");
            mockPercentileSelector.Setup(p => p.SelectFrom("IronFlaskContents", 66)).Returns("BalorOrPitFiend");
            mockPercentileSelector.Setup(p => p.SelectFrom("BalorOrPitFiend", It.IsAny<Int32>())).Returns("balor or pit fiend");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Iron flask"));
            Assert.That(item.Contents, Contains.Item("balor or pit fiend"));
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
        public void RobeOfUsefulItemsBaseItemsAdded()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems", It.IsAny<Int32>())).Returns("Robe of useful items");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Robe of useful items"));
            Assert.That(item.Contents, Contains.Item(WeaponConstants.Dagger));
            Assert.That(item.Contents, Contains.Item("Bullseye lantern (filled and lit)"));
            Assert.That(item.Contents, Contains.Item("Mirror (highly polished, 2-foot by 4-foot, steel)"));
            Assert.That(item.Contents, Contains.Item("10-foot pole"));
            Assert.That(item.Contents, Contains.Item("50-foot Hempen rope"));
            Assert.That(item.Contents, Contains.Item("Sack"));

            foreach (var content in item.Contents.Distinct())
            {
                var allOfContent = item.Contents.FindAll(c => c == content);
                Assert.That(allOfContent.Count, Is.EqualTo(2));
            }
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
            Assert.That(item.Name, Is.EqualTo("Robe of useful items"));
            Assert.That(item.Contents, Contains.Item("item 1"));
            Assert.That(item.Contents, Contains.Item("item 2"));
        }

        [Test]
        public void RobeOfUsefulItemsExtraItemsScrollDetermined()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66);

            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems", 92)).Returns("Robe of useful items");
            mockDice.Setup(d => d.d4(4)).Returns(1);
            mockPercentileSelector.Setup(p => p.SelectFrom("RobeOfUsefulItemsExtraItems", 66)).Returns("Scroll");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Minor)).Returns(9266);
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.Generate("spell type", 9266)).Returns("spell");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Robe of useful items"));
            Assert.That(item.Contents, Contains.Item("spell type scroll of spell (9266)"));
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
            Assert.That(item.Name, Is.EqualTo("Cubic gate"));
            Assert.That(item.Contents, Contains.Item("Material plane"));
            Assert.That(item.Contents, Contains.Item("plane 1"));
            Assert.That(item.Contents, Contains.Item("plane 2"));
            Assert.That(item.Contents, Contains.Item("plane 3"));
            Assert.That(item.Contents, Contains.Item("plane 4"));
            Assert.That(item.Contents, Contains.Item("plane 5"));
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
            Assert.That(item.Name, Is.EqualTo("Cubic gate"));
            Assert.That(item.Contents, Contains.Item("Material plane"));
            Assert.That(item.Contents, Contains.Item("plane 1"));
            Assert.That(item.Contents, Contains.Item("plane 2"));
            Assert.That(item.Contents, Contains.Item("plane 3"));
            Assert.That(item.Contents, Contains.Item("plane 4"));
            Assert.That(item.Contents, Contains.Item("plane 5"));
        }

        [Test]
        public void DoNotGetCurseIfNotCursed()
        {
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<Boolean>())).Returns(false);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic.Curse, Is.Empty);
        }

        [Test]
        public void GetCurseIfCursed()
        {
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<Boolean>())).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic.Curse, Is.EqualTo("cursed"));
        }

        [Test]
        public void GetSpecificCursedItems()
        {
            var cursedItem = new Item();
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<Boolean>())).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("SpecificCursedItem");
            mockCurseGenerator.Setup(g => g.GenerateSpecificCursedItem()).Returns(cursedItem);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(cursedItem));
        }
    }
}