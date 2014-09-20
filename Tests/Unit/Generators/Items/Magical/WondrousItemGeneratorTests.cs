using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;
using EquipmentGen.Tables.Interfaces;
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
        private String power;

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
            wondrousItemGenerator = new WondrousItemGenerator(mockPercentileSelector.Object, mockAttributesSelector.Object, mockChargesGenerator.Object, mockDice.Object, mockSpellGenerator.Object, mockTypeAndAmountPercentileSelector.Object);

            power = "power";
            result.Type = "wondrous item";
            result.Amount = 0;
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(result);
        }

        [Test]
        public void GenerateWondrousItem()
        {
            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(result.Type));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.IsMagical, Is.True);
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "type 1", "type 2" };
            var tableName = String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockAttributesSelector.Setup(p => p.SelectFrom(tableName, result.Type)).Returns(attributes);

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void DoNotGetChargesIfNotCharged()
        {
            var attributes = new[] { "type 1", "type 2" };
            var tableName = String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockAttributesSelector.Setup(p => p.SelectFrom(tableName, result.Type)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, "wondrous item")).Returns(9266);

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public void GetChargesIfCharged()
        {
            var attributes = new[] { AttributeConstants.Charged };
            var tableName = String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockAttributesSelector.Setup(p => p.SelectFrom(tableName, result.Type)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, result.Type)).Returns(9266);

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Magic.Charges, Is.EqualTo(9266));
        }

        [Test]
        public void GetBonus()
        {
            result.Amount = 90210;
            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Magic.Bonus, Is.EqualTo(90210));
        }

        [Test]
        public void HornOfValhallaGetsType()
        {
            result.Type = "Horn of Valhalla";
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.HornOfValhallaTypes)).Returns("metallic");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo("metallic Horn of Valhalla"));
        }

        [Test]
        public void IronFlaskContentsGenerated()
        {
            result.Type = "Iron flask";
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IronFlaskContents)).Returns("contents");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo("Iron flask"));
            Assert.That(item.Contents, Contains.Item("contents"));
        }

        [Test]
        public void IronFlaskContentsDoNotContainEmptyString()
        {
            result.Type = "Iron flask";
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IronFlaskContents)).Returns(String.Empty);

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo("Iron flask"));
            Assert.That(item.Contents, Is.Empty);
        }

        [Test]
        public void IronFlaskOnlyContainsOneThing()
        {
            result.Type = "Iron flask";
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IronFlaskContents)).Returns("contents").Returns("more contents");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo("Iron flask"));
            Assert.That(item.Contents, Contains.Item("contents"));
            Assert.That(item.Contents.Count, Is.EqualTo(1));
        }

        [Test]
        public void IfBalorOrPitFiend_GetFromSelector()
        {
            result.Type = "Iron flask";
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IronFlaskContents)).Returns("BalorOrPitFiend");
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.BalorOrPitFiend)).Returns("balor or pit fiend");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo("Iron flask"));
            Assert.That(item.Contents, Contains.Item("balor or pit fiend"));
        }

        [Test]
        public void RobeOfUsefulItemsBaseItemsAdded()
        {
            mockDice.Setup(d => d.Roll(4).d4()).Returns(0);
            result.Type = "Robe of useful items";
            var items = new[] { "item 1", "item 1", "item 2", "item 2", "item 3", "item 3" };
            mockAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.WondrousItemContents, result.Type)).Returns(items);

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(result.Type));
            foreach (var baseItem in items)
                Assert.That(item.Contents, Contains.Item(baseItem));
        }

        [Test]
        public void RobeOfUsefulItemsExtraItemsDetermined()
        {
            result.Type = "Robe of useful items";
            mockDice.Setup(d => d.Roll(4).d4()).Returns(2);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.RobeOfUsefulItemsExtraItems)).Returns("item 1").Returns("item 2");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(result.Type));
            Assert.That(item.Contents, Contains.Item("item 1"));
            Assert.That(item.Contents, Contains.Item("item 2"));
            Assert.That(item.Contents.Count, Is.EqualTo(2));
        }

        [Test]
        public void RobeOfUsefulItemsCanHaveDuplicateExtraItems()
        {
            result.Type = "Robe of useful items";
            mockDice.Setup(d => d.Roll(4).d4()).Returns(2);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.RobeOfUsefulItemsExtraItems)).Returns("item 1");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(result.Type));
            Assert.That(item.Contents, Contains.Item("item 1"));
            Assert.That(item.Contents.Count(i => i == "item 1"), Is.EqualTo(2));
            Assert.That(item.Contents.Count, Is.EqualTo(2));
        }

        [Test]
        public void RobeOfUsefulItemsExtraItemsScrollDetermined()
        {
            result.Type = "Robe of useful items";
            mockDice.Setup(d => d.Roll(4).d4()).Returns(1);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.RobeOfUsefulItemsExtraItems)).Returns("Scroll");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Minor)).Returns(9266);
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.Generate("spell type", 9266)).Returns("spell");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(result.Type));
            Assert.That(item.Contents, Contains.Item("spell type scroll of spell (9266)"));
        }

        [Test]
        public void CubicGateGetsPlanes()
        {
            result.Type = "Cubic gate";
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.Planes)).Returns("plane 1").Returns("plane 2").Returns("plane 3")
                .Returns("plane 4").Returns("plane 5");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(result.Type));
            Assert.That(item.Contents, Contains.Item("Material plane"));
            Assert.That(item.Contents, Contains.Item("plane 1"));
            Assert.That(item.Contents, Contains.Item("plane 2"));
            Assert.That(item.Contents, Contains.Item("plane 3"));
            Assert.That(item.Contents, Contains.Item("plane 4"));
            Assert.That(item.Contents, Contains.Item("plane 5"));
            Assert.That(item.Contents.Count, Is.EqualTo(6));
        }

        [Test]
        public void CubicGateGetsDistinctPlanes()
        {
            result.Type = "Cubic gate";
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.Planes)).Returns("plane 1").Returns("plane 1").Returns("plane 2")
                .Returns("plane 3").Returns("plane 4").Returns("plane 5");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(result.Type));
            Assert.That(item.Contents, Contains.Item("Material plane"));
            Assert.That(item.Contents, Contains.Item("plane 1"));
            Assert.That(item.Contents, Contains.Item("plane 2"));
            Assert.That(item.Contents, Contains.Item("plane 3"));
            Assert.That(item.Contents, Contains.Item("plane 4"));
            Assert.That(item.Contents, Contains.Item("plane 5"));
            Assert.That(item.Contents.Count, Is.EqualTo(6));
        }

        [Test]
        public void GetCardsForDeckOfIllusions()
        {
            result.Type = "Deck of illusions";
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, result.Type)).Returns(3);
            var cards = new[] { "card 1", "card 2", "card 3", "card 4" };
            mockAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.WondrousItemContents, result.Type)).Returns(cards);
            mockDice.Setup(d => d.Roll(1).d(4)).Returns(1);
            mockDice.Setup(d => d.Roll(1).d(3)).Returns(1);
            mockDice.Setup(d => d.Roll(1).d(2)).Returns(2);

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(result.Type));
            Assert.That(item.Contents, Contains.Item("card 1"));
            Assert.That(item.Contents, Contains.Item("card 2"));
            Assert.That(item.Contents, Contains.Item("card 4"));
            Assert.That(item.Contents.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetSpheresForNecklaceOfFireballs()
        {
            result.Type = "Necklace of fireballs type whatever";
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, result.Type)).Returns(4);
            var spheres = new[] { "small sphere", "big sphere", "normal sphere", "normal sphere", "big sphere" };
            mockAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.WondrousItemContents, result.Type)).Returns(spheres);
            mockDice.Setup(d => d.Roll(1).d(5)).Returns(1);
            mockDice.Setup(d => d.Roll(1).d(4)).Returns(1);
            mockDice.Setup(d => d.Roll(1).d(3)).Returns(1);
            mockDice.Setup(d => d.Roll(1).d(2)).Returns(2);

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(result.Type));
            Assert.That(item.Contents, Contains.Item("small sphere"));
            Assert.That(item.Contents, Contains.Item("normal sphere"));
            Assert.That(item.Contents, Contains.Item("big sphere"));
            Assert.That(item.Contents.Count(c => c == "big sphere"), Is.EqualTo(2));
            Assert.That(item.Contents.Count, Is.EqualTo(4));
        }

        [Test]
        public void RobeOfBonesItemsAdded()
        {
            result.Type = "Robe of bones";
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, result.Type)).Returns(4);
            var items = new[] { "undead 1", "undead 1", "undead 2", "undead 2", "undead 3", "undead 3" };
            mockAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.WondrousItemContents, result.Type)).Returns(items);
            mockDice.Setup(d => d.Roll(1).d(6)).Returns(1);
            mockDice.Setup(d => d.Roll(1).d(5)).Returns(1);
            mockDice.Setup(d => d.Roll(1).d(4)).Returns(1);
            mockDice.Setup(d => d.Roll(1).d(3)).Returns(2);

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(result.Type));
            Assert.That(item.Contents, Contains.Item("undead 1"));
            Assert.That(item.Contents.Count(c => c == "undead 1"), Is.EqualTo(2));
            Assert.That(item.Contents, Contains.Item("undead 2"));
            Assert.That(item.Contents, Contains.Item("undead 3"));
            Assert.That(item.Contents.Count, Is.EqualTo(4));
        }

        [Test]
        public void DoNotRollIfFullContents()
        {
            result.Type = "Robe of bones";
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, result.Type)).Returns(6);
            var items = new[] { "undead 1", "undead 1", "undead 2", "undead 2", "undead 3", "undead 3" };
            mockAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.WondrousItemContents, result.Type)).Returns(items);

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(result.Type));
            Assert.That(item.Contents, Contains.Item("undead 1"));
            Assert.That(item.Contents.Count(c => c == "undead 1"), Is.EqualTo(2));
            Assert.That(item.Contents, Contains.Item("undead 2"));
            Assert.That(item.Contents.Count(c => c == "undead 2"), Is.EqualTo(2));
            Assert.That(item.Contents, Contains.Item("undead 3"));
            Assert.That(item.Contents.Count(c => c == "undead 3"), Is.EqualTo(2));
            Assert.That(item.Contents.Count, Is.EqualTo(6));
            mockDice.Verify(d => d.Roll(It.IsAny<Int32>()).d(It.IsAny<Int32>()), Times.Never);
        }
    }
}