using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;
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
        private Mock<IAttributesSelector> mockAttributesSelector;
        private Mock<IChargesGenerator> mockChargesGenerator;
        private Mock<IDice> mockDice;
        private Mock<ISpellGenerator> mockSpellGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            mockTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            mockSpellGenerator = new Mock<ISpellGenerator>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockDice = new Mock<IDice>();
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            result = new TypeAndAmountPercentileResult();
            wondrousItemGenerator = new WondrousItemGenerator(mockPercentileSelector.Object, mockTraitsGenerator.Object,
                mockAttributesSelector.Object, mockChargesGenerator.Object, mockDice.Object, mockSpellGenerator.Object);

            result.Type = "wondrous item";
            result.Amount = "0";
            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems")).Returns(result);
        }

        [Test]
        public void GetItemFromSelector()
        {
            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo(result.Type));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.IsMagical, Is.True);
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
            mockAttributesSelector.Setup(p => p.SelectFrom("WondrousItemAttributes", result.Type)).Returns(attributes);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void DoNotGetChargesIfNotCharged()
        {
            var attributes = new[] { "type 1", "type 2" };
            mockAttributesSelector.Setup(p => p.SelectFrom("WondrousItemAttributes", result.Type)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, "wondrous item")).Returns(9266);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public void GetChargesIfCharged()
        {
            var attributes = new[] { AttributeConstants.Charged };
            mockAttributesSelector.Setup(p => p.SelectFrom("WondrousItemAttributes", result.Type)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, result.Type)).Returns(9266);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic.Charges, Is.EqualTo(9266));
        }

        [Test]
        public void GetBonus()
        {
            result.Amount = "90210";
            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Magic.Bonus, Is.EqualTo(90210));
        }


        [Test]
        public void HornOfValhallaGetsType()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems")).Returns("Horn of Valhalla");
            mockPercentileSelector.Setup(p => p.SelectFrom("HornOfValhallaTypes")).Returns("metallic");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("metallic Horn of Valhalla"));
        }

        [Test]
        public void IronFlaskContentsGenerated()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems")).Returns("Iron flask");
            mockPercentileSelector.Setup(p => p.SelectFrom("IronFlaskContents")).Returns("contents");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Iron flask"));
            Assert.That(item.Contents, Contains.Item("contents"));
        }

        [Test]
        public void IronFlaskContentsDoNotContainsEmptyString()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems")).Returns("Iron flask");
            mockPercentileSelector.Setup(p => p.SelectFrom("IronFlaskContents")).Returns(String.Empty);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Iron flask"));
            Assert.That(item.Contents, Is.Empty);
        }

        [Test]
        public void IronFlaskOnlyContainsOneThing()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems")).Returns("Iron flask");
            mockPercentileSelector.SetupSequence(p => p.SelectFrom("IronFlaskContents")).Returns("contents").Returns("more contents");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Iron flask"));
            Assert.That(item.Contents, Contains.Item("contents"));
            Assert.That(item.Contents.Count, Is.EqualTo(1));
        }

        [Test]
        public void IfBalorOrPitFiend_GetFromSelector()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66);

            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems")).Returns("Iron flask");
            mockPercentileSelector.Setup(p => p.SelectFrom("IronFlaskContents")).Returns("BalorOrPitFiend");
            mockPercentileSelector.Setup(p => p.SelectFrom("BalorOrPitFiend")).Returns("balor or pit fiend");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Iron flask"));
            Assert.That(item.Contents, Contains.Item("balor or pit fiend"));
        }

        [Test]
        public void RobeOfUsefulItemsBaseItemsAdded()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems")).Returns("Robe of useful items");
            var items = new[] { "item 1", "item 2", "item 3" };
            mockAttributesSelector.Setup(s => s.SelectFrom("RobeOfUsefulItemsBaseItems", "Items")).Returns(items);

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Robe of useful items"));
            foreach (var baseItem in items)
                Assert.That(item.Contents, Contains.Item(baseItem));
        }

        [Test]
        public void RobeOfUsefulItemsExtraItemsDetermined()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems")).Returns("Robe of useful items");
            mockDice.Setup(d => d.d4(4)).Returns(2);
            mockPercentileSelector.Setup(p => p.SelectFrom("RobeOfUsefulItemsExtraItems")).Returns("item 1");
            mockPercentileSelector.Setup(p => p.SelectFrom("RobeOfUsefulItemsExtraItems")).Returns("item 2");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Robe of useful items"));
            Assert.That(item.Contents, Contains.Item("item 1"));
            Assert.That(item.Contents, Contains.Item("item 2"));
        }

        [Test]
        public void RobeOfUsefulItemsExtraItemsScrollDetermined()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems")).Returns("Robe of useful items");
            mockDice.Setup(d => d.d4(4)).Returns(1);
            mockPercentileSelector.Setup(p => p.SelectFrom("RobeOfUsefulItemsExtraItems")).Returns("Scroll");
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

            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems")).Returns("Cubic gate");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes")).Returns("plane 1");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes")).Returns("plane 2");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes")).Returns("plane 3");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes")).Returns("plane 4");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes")).Returns("plane 5");

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
            mockPercentileSelector.Setup(p => p.SelectFrom("powerWondrousItems")).Returns("Cubic gate");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes")).Returns("plane 1");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes")).Returns("plane 2");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes")).Returns("plane 3");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes")).Returns("plane 4");
            mockPercentileSelector.Setup(p => p.SelectFrom("Planes")).Returns("plane 5");

            var item = wondrousItemGenerator.GenerateAtPower("power");
            Assert.That(item.Name, Is.EqualTo("Cubic gate"));
            Assert.That(item.Contents, Contains.Item("Material plane"));
            Assert.That(item.Contents, Contains.Item("plane 1"));
            Assert.That(item.Contents, Contains.Item("plane 2"));
            Assert.That(item.Contents, Contains.Item("plane 3"));
            Assert.That(item.Contents, Contains.Item("plane 4"));
            Assert.That(item.Contents, Contains.Item("plane 5"));
        }
    }
}