using Moq;
using NUnit.Framework;
using RollGen;
using System;
using System.Linq;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Selectors.Selections;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class WondrousItemGeneratorTests
    {
        private MagicalItemGenerator wondrousItemGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IMagicalItemTraitsGenerator> mockTraitsGenerator;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private Mock<IChargesGenerator> mockChargesGenerator;
        private Mock<Dice> mockDice;
        private Mock<ISpellGenerator> mockSpellGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private TypeAndAmountSelection selection;
        private string power;
        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            mockTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            mockSpellGenerator = new Mock<ISpellGenerator>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockDice = new Mock<Dice>();
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            selection = new TypeAndAmountSelection();
            var generator = new ConfigurableIterativeGenerator(5);
            wondrousItemGenerator = new WondrousItemGenerator(
                mockPercentileSelector.Object,
                mockCollectionsSelector.Object,
                mockChargesGenerator.Object,
                mockDice.Object,
                mockSpellGenerator.Object,
                mockTypeAndAmountPercentileSelector.Object,
                generator);
            itemVerifier = new ItemVerifier();

            power = "power";
            selection.Type = "wondrous item";
            selection.Amount = 0;
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(selection);
        }

        [Test]
        public void GenerateWondrousItem()
        {
            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(selection.Type));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(selection.Type));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.IsMagical, Is.True);
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "type 1", "type 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, selection.Type)).Returns(attributes);

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void DoNotGetChargesIfNotCharged()
        {
            var attributes = new[] { "type 1", "type 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, selection.Type)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, "wondrous item")).Returns(9266);

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public void GetChargesIfCharged()
        {
            var attributes = new[] { AttributeConstants.Charged };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, selection.Type)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, selection.Type)).Returns(9266);

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Magic.Charges, Is.EqualTo(9266));
        }

        [Test]
        public void GetBonus()
        {
            selection.Amount = 90210;
            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Magic.Bonus, Is.EqualTo(90210));
        }

        [Test]
        public void HornOfValhallaGetsType()
        {
            selection.Type = WondrousItemConstants.HornOfValhalla;
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.HornOfValhallaTypes)).Returns("metallic");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.HornOfValhalla));
            Assert.That(item.Traits, Contains.Item("metallic"));
            Assert.That(item.Traits.Count, Is.EqualTo(1));
        }

        [Test]
        public void IronFlaskContentsGenerated()
        {
            selection.Type = WondrousItemConstants.IronFlask;
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IronFlaskContents)).Returns("contents");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.IronFlask));
            Assert.That(item.Contents, Contains.Item("contents"));
        }

        [Test]
        public void IronFlaskContentsDoNotContainEmptyString()
        {
            selection.Type = WondrousItemConstants.IronFlask;
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IronFlaskContents)).Returns(string.Empty);

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.IronFlask));
            Assert.That(item.Contents, Is.Empty);
        }

        [Test]
        public void IronFlaskOnlyContainsOneThing()
        {
            selection.Type = WondrousItemConstants.IronFlask;
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IronFlaskContents)).Returns("contents").Returns("more contents");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.IronFlask));
            Assert.That(item.Contents, Contains.Item("contents"));
            Assert.That(item.Contents.Count, Is.EqualTo(1));
        }

        [Test]
        public void IfBalorOrPitFiend_GetFromSelector()
        {
            selection.Type = WondrousItemConstants.IronFlask;
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IronFlaskContents)).Returns(TableNameConstants.Percentiles.Set.BalorOrPitFiend);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.BalorOrPitFiend)).Returns("balor or pit fiend");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.IronFlask));
            Assert.That(item.Contents, Contains.Item("balor or pit fiend"));
        }

        [Test]
        public void RobeOfUsefulItemsBaseItemsAdded()
        {
            SetUpRoll(4, 4, 0);
            selection.Type = WondrousItemConstants.RobeOfUsefulItems;
            var items = new[] { "item 1", "item 1", "item 2", "item 2", "item 3", "item 3" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WondrousItemContents, selection.Type)).Returns(items);

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(selection.Type));
            Assert.That(item.Contents, Is.SupersetOf(items));
        }

        [Test]
        public void RobeOfUsefulItemsExtraItemsDetermined()
        {
            selection.Type = WondrousItemConstants.RobeOfUsefulItems;
            SetUpRoll(4, 4, 2);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.RobeOfUsefulItemsExtraItems)).Returns("item 1").Returns("item 2");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(selection.Type));
            Assert.That(item.Contents, Contains.Item("item 1"));
            Assert.That(item.Contents, Contains.Item("item 2"));
            Assert.That(item.Contents.Count, Is.EqualTo(2));
        }

        [Test]
        public void RobeOfUsefulItemsCanHaveDuplicateExtraItems()
        {
            selection.Type = WondrousItemConstants.RobeOfUsefulItems;
            SetUpRoll(4, 4, 2);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.RobeOfUsefulItemsExtraItems)).Returns("item 1");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(selection.Type));
            Assert.That(item.Contents, Contains.Item("item 1"));
            Assert.That(item.Contents.Count(i => i == "item 1"), Is.EqualTo(2));
            Assert.That(item.Contents.Count, Is.EqualTo(2));
        }

        [Test]
        public void RobeOfUsefulItemsExtraItemsScrollDetermined()
        {
            selection.Type = WondrousItemConstants.RobeOfUsefulItems;
            SetUpRoll(4, 4, 1);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.RobeOfUsefulItemsExtraItems)).Returns("Scroll");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Minor)).Returns(9266);
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.Generate("spell type", 9266)).Returns("spell");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(selection.Type));
            Assert.That(item.Contents, Contains.Item("spell type scroll of spell (9266)"));
        }

        [Test]
        public void CubicGateGetsPlanes()
        {
            selection.Type = WondrousItemConstants.CubicGate;
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.Planes)).Returns("plane 1").Returns("plane 2").Returns("plane 3")
                .Returns("plane 4").Returns("plane 5");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(selection.Type));
            Assert.That(item.Contents, Contains.Item("Material Plane"));
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
            selection.Type = WondrousItemConstants.CubicGate;
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.Planes)).Returns("plane 1").Returns("plane 1").Returns("plane 2")
                .Returns("plane 3").Returns("plane 4").Returns("plane 5");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(selection.Type));
            Assert.That(item.Contents, Contains.Item("Material Plane"));
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
            selection.Type = WondrousItemConstants.DeckOfIllusions;
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, selection.Type)).Returns(3);
            var cards = new[] { "card 1", "card 2", "card 3", "card 4" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WondrousItemContents, selection.Type)).Returns(cards);
            SetUpRoll(1, 4, 1);
            SetUpRoll(1, 3, 1);
            SetUpRoll(1, 2, 2);

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(selection.Type));
            Assert.That(item.Contents, Contains.Item("card 1"));
            Assert.That(item.Contents, Contains.Item("card 2"));
            Assert.That(item.Contents, Contains.Item("card 4"));
            Assert.That(item.Contents.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetSpheresForNecklaceOfFireballs()
        {
            selection.Type = WondrousItemConstants.NecklaceOfFireballs + " type whatever";
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, selection.Type)).Returns(4);
            var spheres = new[] { "small sphere", "big sphere", "normal sphere", "normal sphere", "big sphere" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WondrousItemContents, selection.Type)).Returns(spheres);
            SetUpRoll(1, 5, 1);
            SetUpRoll(1, 4, 1);
            SetUpRoll(1, 3, 1);
            SetUpRoll(1, 2, 2);

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(selection.Type));
            Assert.That(item.Contents, Contains.Item("small sphere"));
            Assert.That(item.Contents, Contains.Item("normal sphere"));
            Assert.That(item.Contents, Contains.Item("big sphere"));
            Assert.That(item.Contents.Count(c => c == "big sphere"), Is.EqualTo(2));
            Assert.That(item.Contents.Count, Is.EqualTo(4));
        }

        private void SetUpRoll(int quantity, int die, int result)
        {
            var mockPartial = new Mock<PartialRoll>();
            mockPartial.Setup(p => p.AsSum()).Returns(result);
            mockDice.Setup(d => d.Roll(quantity).d(die)).Returns(mockPartial.Object);
        }

        [Test]
        public void RobeOfBonesItemsAdded()
        {
            selection.Type = WondrousItemConstants.RobeOfBones;
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, selection.Type)).Returns(4);
            var items = new[] { "undead 1", "undead 1", "undead 2", "undead 2", "undead 3", "undead 3" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WondrousItemContents, selection.Type)).Returns(items);
            SetUpRoll(1, 6, 1);
            SetUpRoll(1, 5, 1);
            SetUpRoll(1, 4, 1);
            SetUpRoll(1, 3, 2);

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(selection.Type));
            Assert.That(item.Contents, Contains.Item("undead 1"));
            Assert.That(item.Contents.Count(c => c == "undead 1"), Is.EqualTo(2));
            Assert.That(item.Contents, Contains.Item("undead 2"));
            Assert.That(item.Contents, Contains.Item("undead 3"));
            Assert.That(item.Contents.Count, Is.EqualTo(4));
        }

        [Test]
        public void DoNotRollIfFullContents()
        {
            selection.Type = WondrousItemConstants.RobeOfBones;
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, selection.Type)).Returns(6);
            var items = new[] { "undead 1", "undead 1", "undead 2", "undead 2", "undead 3", "undead 3" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WondrousItemContents, selection.Type)).Returns(items);

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(selection.Type));
            Assert.That(item.Contents, Contains.Item("undead 1"));
            Assert.That(item.Contents.Count(c => c == "undead 1"), Is.EqualTo(2));
            Assert.That(item.Contents, Contains.Item("undead 2"));
            Assert.That(item.Contents.Count(c => c == "undead 2"), Is.EqualTo(2));
            Assert.That(item.Contents, Contains.Item("undead 3"));
            Assert.That(item.Contents.Count(c => c == "undead 3"), Is.EqualTo(2));
            Assert.That(item.Contents.Count, Is.EqualTo(6));
            mockDice.Verify(d => d.Roll(It.IsAny<int>()).d(It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void CandleOfInvocationGetsAlignment()
        {
            selection.Type = WondrousItemConstants.CandleOfInvocation;
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments)).Returns("alignment");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(selection.Type));
            Assert.That(item.Traits, Contains.Item("alignment"));
            Assert.That(item.Traits.Count, Is.EqualTo(1));
        }

        [Test]
        public void RobeOfTheArchmagiGetsAlignment()
        {
            selection.Type = WondrousItemConstants.RobeOfTheArchmagi;
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.RobeOfTheArchmagiColors)).Returns("color (alignment)");

            var item = wondrousItemGenerator.GenerateAtPower(power);
            Assert.That(item.Name, Is.EqualTo(selection.Type));
            Assert.That(item.Traits, Contains.Item("color (alignment)"));
            Assert.That(item.Traits.Count, Is.EqualTo(1));
        }

        [Test]
        public void GenerateCustomWondrousItem()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var attributes = new[] { "type 1", "type 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            var wondrousItem = wondrousItemGenerator.Generate(template);
            itemVerifier.AssertMagicalItemFromTemplate(wondrousItem, template);
            Assert.That(wondrousItem.Name, Is.EqualTo(name));
            Assert.That(wondrousItem.BaseNames.Single(), Is.EqualTo(name));
            Assert.That(wondrousItem.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(wondrousItem.IsMagical, Is.True);
            Assert.That(wondrousItem.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GenerateRandomCustomWondrousItem()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var attributes = new[] { "type 1", "type 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            var wondrousItem = wondrousItemGenerator.Generate(template, true);
            itemVerifier.AssertMagicalItemFromTemplate(wondrousItem, template);
            Assert.That(wondrousItem.Name, Is.EqualTo(name));
            Assert.That(wondrousItem.BaseNames.Single(), Is.EqualTo(name));
            Assert.That(wondrousItem.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(wondrousItem.IsMagical, Is.True);
            Assert.That(wondrousItem.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GenerateFromSubset()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 })
                .Returns(new TypeAndAmountSelection { Type = "wondrous item", Amount = 9266 })
                .Returns(new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "wondrous item")).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, It.IsAny<string>())).Returns(666);

            var subset = new[] { "other wondrous item", "wondrous item" };

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo("wondrous item"));
            Assert.That(item.BaseNames.Single(), Is.EqualTo("wondrous item"));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public void GenerateChargedFromSubset()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 })
                .Returns(new TypeAndAmountSelection { Type = "wondrous item", Amount = 9266 })
                .Returns(new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 });

            var attributes = new[] { "type 1", "type 2", AttributeConstants.Charged };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "wondrous item")).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, It.IsAny<string>())).Returns(42);

            var subset = new[] { "other wondrous item", "wondrous item" };

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo("wondrous item"));
            Assert.That(item.BaseNames.Single(), Is.EqualTo("wondrous item"));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(42));
        }

        [Test]
        public void GenerateHornOfValhallaFromSubset()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.HornOfValhallaTypes)).Returns("metallic");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 })
                .Returns(new TypeAndAmountSelection { Type = WondrousItemConstants.HornOfValhalla, Amount = 9266 })
                .Returns(new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, WondrousItemConstants.HornOfValhalla)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, It.IsAny<string>())).Returns(666);

            var subset = new[] { "other wondrous item", WondrousItemConstants.HornOfValhalla };

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.HornOfValhalla));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(WondrousItemConstants.HornOfValhalla));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
            Assert.That(item.Traits, Contains.Item("metallic"));
            Assert.That(item.Traits.Count, Is.EqualTo(1));
        }

        [Test]
        public void GenerateIronFlaskFromSubset()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IronFlaskContents)).Returns("contents");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 })
                .Returns(new TypeAndAmountSelection { Type = WondrousItemConstants.IronFlask, Amount = 9266 })
                .Returns(new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, WondrousItemConstants.IronFlask)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, It.IsAny<string>())).Returns(666);

            var subset = new[] { "other wondrous item", WondrousItemConstants.IronFlask };

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.IronFlask));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(WondrousItemConstants.IronFlask));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
            Assert.That(item.Contents, Contains.Item("contents"));
        }

        [Test]
        public void GenerateRobeOfUsefulItemsFromSubset()
        {
            SetUpRoll(4, 4, 2);
            var items = new[] { "item 1", "item 1", "item 2", "item 2", "item 3", "item 3" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WondrousItemContents, WondrousItemConstants.RobeOfUsefulItems)).Returns(items);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.RobeOfUsefulItemsExtraItems)).Returns("extra item 1").Returns("extra item 2");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 })
                .Returns(new TypeAndAmountSelection { Type = WondrousItemConstants.RobeOfUsefulItems, Amount = 9266 })
                .Returns(new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, WondrousItemConstants.RobeOfUsefulItems)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, It.IsAny<string>())).Returns(666);

            var subset = new[] { "other wondrous item", WondrousItemConstants.RobeOfUsefulItems };

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.RobeOfUsefulItems));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(WondrousItemConstants.RobeOfUsefulItems));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
            Assert.That(item.Contents, Is.SupersetOf(items));
            Assert.That(item.Contents, Contains.Item("extra item 1"));
            Assert.That(item.Contents, Contains.Item("extra item 2"));
        }

        [Test]
        public void GenerateCubicGateFromSubset()
        {
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.Planes))
                .Returns("plane 1")
                .Returns("plane 2")
                .Returns("plane 3")
                .Returns("plane 4")
                .Returns("plane 5");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 })
                .Returns(new TypeAndAmountSelection { Type = WondrousItemConstants.CubicGate, Amount = 9266 })
                .Returns(new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, WondrousItemConstants.CubicGate)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, It.IsAny<string>())).Returns(666);

            var subset = new[] { "other wondrous item", WondrousItemConstants.CubicGate };

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.CubicGate));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(WondrousItemConstants.CubicGate));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
            Assert.That(item.Contents, Contains.Item("Material Plane"));
            Assert.That(item.Contents, Contains.Item("plane 1"));
            Assert.That(item.Contents, Contains.Item("plane 2"));
            Assert.That(item.Contents, Contains.Item("plane 3"));
            Assert.That(item.Contents, Contains.Item("plane 4"));
            Assert.That(item.Contents, Contains.Item("plane 5"));
            Assert.That(item.Contents.Count, Is.EqualTo(6));
        }

        [Test]
        public void GenerateDeckOfIllusionsFromSubset()
        {
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, WondrousItemConstants.DeckOfIllusions)).Returns(3);
            var cards = new[] { "card 1", "card 2", "card 3", "card 4" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WondrousItemContents, WondrousItemConstants.DeckOfIllusions)).Returns(cards);
            SetUpRoll(1, 4, 1);
            SetUpRoll(1, 3, 1);
            SetUpRoll(1, 2, 2);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 })
                .Returns(new TypeAndAmountSelection { Type = WondrousItemConstants.DeckOfIllusions, Amount = 9266 })
                .Returns(new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, WondrousItemConstants.DeckOfIllusions)).Returns(attributes);

            var subset = new[] { "other wondrous item", WondrousItemConstants.DeckOfIllusions };

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.DeckOfIllusions));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(WondrousItemConstants.DeckOfIllusions));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
            Assert.That(item.Contents, Contains.Item("card 1"));
            Assert.That(item.Contents, Contains.Item("card 2"));
            Assert.That(item.Contents, Contains.Item("card 4"));
            Assert.That(item.Contents.Count, Is.EqualTo(3));
        }

        [Test]
        public void GenerateNecklaceOfFireballsFromSubset()
        {
            var name = WondrousItemConstants.NecklaceOfFireballs + " type whatever";
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, name)).Returns(4);
            var spheres = new[] { "small sphere", "big sphere", "normal sphere", "normal sphere", "big sphere" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WondrousItemContents, name)).Returns(spheres);
            SetUpRoll(1, 5, 1);
            SetUpRoll(1, 4, 1);
            SetUpRoll(1, 3, 1);
            SetUpRoll(1, 2, 2);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 })
                .Returns(new TypeAndAmountSelection { Type = name, Amount = 9266 })
                .Returns(new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            var subset = new[] { "other wondrous item", name };

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo(name));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(name));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
            Assert.That(item.Contents, Contains.Item("small sphere"));
            Assert.That(item.Contents, Contains.Item("normal sphere"));
            Assert.That(item.Contents, Contains.Item("big sphere"));
            Assert.That(item.Contents.Count(c => c == "big sphere"), Is.EqualTo(2));
            Assert.That(item.Contents.Count, Is.EqualTo(4));
        }

        [Test]
        public void GenerateRobeOfBonesFromSubset()
        {
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, WondrousItemConstants.RobeOfBones)).Returns(4);
            var items = new[] { "undead 1", "undead 1", "undead 2", "undead 2", "undead 3", "undead 3" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WondrousItemContents, WondrousItemConstants.RobeOfBones)).Returns(items);
            SetUpRoll(1, 6, 1);
            SetUpRoll(1, 5, 1);
            SetUpRoll(1, 4, 1);
            SetUpRoll(1, 3, 2);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 })
                .Returns(new TypeAndAmountSelection { Type = WondrousItemConstants.RobeOfBones, Amount = 9266 })
                .Returns(new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, WondrousItemConstants.RobeOfBones)).Returns(attributes);

            var subset = new[] { "other wondrous item", WondrousItemConstants.RobeOfBones };

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.RobeOfBones));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(WondrousItemConstants.RobeOfBones));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
            Assert.That(item.Contents, Contains.Item("undead 1"));
            Assert.That(item.Contents.Count(c => c == "undead 1"), Is.EqualTo(2));
            Assert.That(item.Contents, Contains.Item("undead 2"));
            Assert.That(item.Contents, Contains.Item("undead 3"));
            Assert.That(item.Contents.Count, Is.EqualTo(4));
        }

        [Test]
        public void GenerateCandleOfInvocationFromSubset()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments)).Returns("alignment");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 })
                .Returns(new TypeAndAmountSelection { Type = WondrousItemConstants.CandleOfInvocation, Amount = 9266 })
                .Returns(new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, WondrousItemConstants.CandleOfInvocation)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, It.IsAny<string>())).Returns(666);

            var subset = new[] { "other wondrous item", WondrousItemConstants.CandleOfInvocation };

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.CandleOfInvocation));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(WondrousItemConstants.CandleOfInvocation));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
            Assert.That(item.Traits, Contains.Item("alignment"));
            Assert.That(item.Traits.Count, Is.EqualTo(1));
        }

        [Test]
        public void GenerateRobeOfTheArchmagiFromSubset()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.RobeOfTheArchmagiColors)).Returns("color (alignment)");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 })
                .Returns(new TypeAndAmountSelection { Type = WondrousItemConstants.RobeOfTheArchmagi, Amount = 9266 })
                .Returns(new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, WondrousItemConstants.RobeOfTheArchmagi)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, It.IsAny<string>())).Returns(666);

            var subset = new[] { "other wondrous item", WondrousItemConstants.RobeOfTheArchmagi };

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.RobeOfTheArchmagi));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(WondrousItemConstants.RobeOfTheArchmagi));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
            Assert.That(item.Traits, Contains.Item("color (alignment)"));
            Assert.That(item.Traits.Count, Is.EqualTo(1));
        }

        [Test]
        public void GenerateDefaultFromSubset()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 });
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 },
                new TypeAndAmountSelection { Type = "wondrous item", Amount = 9266 },
                new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 },
            });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "wondrous item")).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, It.IsAny<string>())).Returns(666);

            var subset = new[] { "other wondrous item", "wondrous item" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo("wondrous item"));
            Assert.That(item.BaseNames.Single(), Is.EqualTo("wondrous item"));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public void GenerateDefaultChargedFromSubset()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 });
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 },
                new TypeAndAmountSelection { Type = "wondrous item", Amount = 9266 },
                new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 },
            });

            var attributes = new[] { "type 1", "type 2", AttributeConstants.Charged };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "wondrous item")).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, It.IsAny<string>())).Returns(42);

            var subset = new[] { "other wondrous item", "wondrous item" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo("wondrous item"));
            Assert.That(item.BaseNames.Single(), Is.EqualTo("wondrous item"));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(42));
        }

        [Test]
        public void GenerateDefaultHornOfValhallaFromSubset()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.HornOfValhallaTypes)).Returns("metallic");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 });
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 },
                new TypeAndAmountSelection { Type = WondrousItemConstants.HornOfValhalla, Amount = 9266 },
                new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 },
            });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, WondrousItemConstants.HornOfValhalla)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, It.IsAny<string>())).Returns(666);

            var subset = new[] { "other wondrous item", WondrousItemConstants.HornOfValhalla };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.HornOfValhalla));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(WondrousItemConstants.HornOfValhalla));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
            Assert.That(item.Traits, Contains.Item("metallic"));
            Assert.That(item.Traits.Count, Is.EqualTo(1));
        }

        [Test]
        public void GenerateDefaultIronFlaskFromSubset()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.IronFlaskContents)).Returns("contents");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 });
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 },
                new TypeAndAmountSelection { Type = WondrousItemConstants.IronFlask, Amount = 9266 },
                new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 },
            });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, WondrousItemConstants.IronFlask)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, It.IsAny<string>())).Returns(666);

            var subset = new[] { "other wondrous item", WondrousItemConstants.IronFlask };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.IronFlask));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(WondrousItemConstants.IronFlask));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
            Assert.That(item.Contents, Contains.Item("contents"));
        }

        [Test]
        public void GenerateDefaultRobeOfUsefulItemsFromSubset()
        {
            SetUpRoll(4, 4, 2);
            var items = new[] { "item 1", "item 1", "item 2", "item 2", "item 3", "item 3" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WondrousItemContents, WondrousItemConstants.RobeOfUsefulItems)).Returns(items);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.RobeOfUsefulItemsExtraItems)).Returns("extra item 1").Returns("extra item 2");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 });
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 },
                new TypeAndAmountSelection { Type = WondrousItemConstants.RobeOfUsefulItems, Amount = 9266 },
                new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 },
            });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, WondrousItemConstants.RobeOfUsefulItems)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, It.IsAny<string>())).Returns(666);

            var subset = new[] { "other wondrous item", WondrousItemConstants.RobeOfUsefulItems };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.RobeOfUsefulItems));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(WondrousItemConstants.RobeOfUsefulItems));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
            Assert.That(item.Contents, Is.SupersetOf(items));
            Assert.That(item.Contents, Contains.Item("extra item 1"));
            Assert.That(item.Contents, Contains.Item("extra item 2"));
        }

        [Test]
        public void GenerateDefaultCubicGateFromSubset()
        {
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(TableNameConstants.Percentiles.Set.Planes))
                .Returns("plane 1")
                .Returns("plane 2")
                .Returns("plane 3")
                .Returns("plane 4")
                .Returns("plane 5");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 });
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 },
                new TypeAndAmountSelection { Type = WondrousItemConstants.CubicGate, Amount = 9266 },
                new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 },
            });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, WondrousItemConstants.CubicGate)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, It.IsAny<string>())).Returns(666);

            var subset = new[] { "other wondrous item", WondrousItemConstants.CubicGate };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.CubicGate));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(WondrousItemConstants.CubicGate));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
            Assert.That(item.Contents, Contains.Item("Material Plane"));
            Assert.That(item.Contents, Contains.Item("plane 1"));
            Assert.That(item.Contents, Contains.Item("plane 2"));
            Assert.That(item.Contents, Contains.Item("plane 3"));
            Assert.That(item.Contents, Contains.Item("plane 4"));
            Assert.That(item.Contents, Contains.Item("plane 5"));
            Assert.That(item.Contents.Count, Is.EqualTo(6));
        }

        [Test]
        public void GenerateDefaultDeckOfIllusionsFromSubset()
        {
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, WondrousItemConstants.DeckOfIllusions)).Returns(3);
            var cards = new[] { "card 1", "card 2", "card 3", "card 4" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WondrousItemContents, WondrousItemConstants.DeckOfIllusions)).Returns(cards);
            SetUpRoll(1, 4, 1);
            SetUpRoll(1, 3, 1);
            SetUpRoll(1, 2, 2);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 });
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 },
                new TypeAndAmountSelection { Type = WondrousItemConstants.DeckOfIllusions, Amount = 9266 },
                new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 },
            });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, WondrousItemConstants.DeckOfIllusions)).Returns(attributes);

            var subset = new[] { "other wondrous item", WondrousItemConstants.DeckOfIllusions };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.DeckOfIllusions));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(WondrousItemConstants.DeckOfIllusions));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
            Assert.That(item.Contents, Contains.Item("card 1"));
            Assert.That(item.Contents, Contains.Item("card 2"));
            Assert.That(item.Contents, Contains.Item("card 4"));
            Assert.That(item.Contents.Count, Is.EqualTo(3));
        }

        [Test]
        public void GenerateDefaultNecklaceOfFireballsFromSubset()
        {
            var name = WondrousItemConstants.NecklaceOfFireballs + " type whatever";
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, name)).Returns(4);
            var spheres = new[] { "small sphere", "big sphere", "normal sphere", "normal sphere", "big sphere" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WondrousItemContents, name)).Returns(spheres);
            SetUpRoll(1, 5, 1);
            SetUpRoll(1, 4, 1);
            SetUpRoll(1, 3, 1);
            SetUpRoll(1, 2, 2);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 });
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 },
                new TypeAndAmountSelection { Type = name, Amount = 9266 },
                new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 },
            });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            var subset = new[] { "other wondrous item", name };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo(name));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(name));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
            Assert.That(item.Contents, Contains.Item("small sphere"));
            Assert.That(item.Contents, Contains.Item("normal sphere"));
            Assert.That(item.Contents, Contains.Item("big sphere"));
            Assert.That(item.Contents.Count(c => c == "big sphere"), Is.EqualTo(2));
            Assert.That(item.Contents.Count, Is.EqualTo(4));
        }

        [Test]
        public void GenerateDefaultRobeOfBonesFromSubset()
        {
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, WondrousItemConstants.RobeOfBones)).Returns(4);
            var items = new[] { "undead 1", "undead 1", "undead 2", "undead 2", "undead 3", "undead 3" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.WondrousItemContents, WondrousItemConstants.RobeOfBones)).Returns(items);
            SetUpRoll(1, 6, 1);
            SetUpRoll(1, 5, 1);
            SetUpRoll(1, 4, 1);
            SetUpRoll(1, 3, 2);

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 });
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 },
                new TypeAndAmountSelection { Type = WondrousItemConstants.RobeOfBones, Amount = 9266 },
                new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 },
            });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, WondrousItemConstants.RobeOfBones)).Returns(attributes);

            var subset = new[] { "other wondrous item", WondrousItemConstants.RobeOfBones };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.RobeOfBones));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(WondrousItemConstants.RobeOfBones));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
            Assert.That(item.Contents, Contains.Item("undead 1"));
            Assert.That(item.Contents.Count(c => c == "undead 1"), Is.EqualTo(2));
            Assert.That(item.Contents, Contains.Item("undead 2"));
            Assert.That(item.Contents, Contains.Item("undead 3"));
            Assert.That(item.Contents.Count, Is.EqualTo(4));
        }

        [Test]
        public void GenerateDefaultCandleOfInvocationFromSubset()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments)).Returns("alignment");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 });
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 },
                new TypeAndAmountSelection { Type = WondrousItemConstants.CandleOfInvocation, Amount = 9266 },
                new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 },
            });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, WondrousItemConstants.CandleOfInvocation)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, It.IsAny<string>())).Returns(666);

            var subset = new[] { "other wondrous item", WondrousItemConstants.CandleOfInvocation };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.CandleOfInvocation));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(WondrousItemConstants.CandleOfInvocation));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
            Assert.That(item.Traits, Contains.Item("alignment"));
            Assert.That(item.Traits.Count, Is.EqualTo(1));
        }

        [Test]
        public void GenerateDefaultRobeOfTheArchmagiFromSubset()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.RobeOfTheArchmagiColors)).Returns("color (alignment)");

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 });
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 666 },
                new TypeAndAmountSelection { Type = WondrousItemConstants.RobeOfTheArchmagi, Amount = 9266 },
                new TypeAndAmountSelection { Type = "other wondrous item", Amount = 90210 },
            });

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, WondrousItemConstants.RobeOfTheArchmagi)).Returns(attributes);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.WondrousItem, It.IsAny<string>())).Returns(666);

            var subset = new[] { "other wondrous item", WondrousItemConstants.RobeOfTheArchmagi };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo(WondrousItemConstants.RobeOfTheArchmagi));
            Assert.That(item.BaseNames.Single(), Is.EqualTo(WondrousItemConstants.RobeOfTheArchmagi));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
            Assert.That(item.Traits, Contains.Item("color (alignment)"));
            Assert.That(item.Traits.Count, Is.EqualTo(1));
        }

        [Test]
        public void GenerateDefaultFromSubsetWithDifferentPower()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong wondrous item", Amount = 9266 });
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Amount = 666, Type = "wrong wondrous item" },
                new TypeAndAmountSelection { Amount = 42, Type = "other wondrous item" },
            });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Minor, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Amount = 666, Type = "wrong wondrous item" },
            });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Amount = 42, Type = "other wondrous item" },
            });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Major, ItemTypeConstants.WondrousItem);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Amount = 90210, Type = "wondrous item" },
            });

            var attributes = new[] { "attribute 1", "attribute 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "wondrous item")).Returns(attributes);

            var subset = new[] { "other wondrous item", "wondrous item" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var item = wondrousItemGenerator.GenerateFromSubset(power, subset);
            Assert.That(item.Name, Is.EqualTo("wondrous item"));
            Assert.That(item.BaseNames.Single(), Is.EqualTo("wondrous item"));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(item.Attributes, Is.EqualTo(attributes));
            Assert.That(item.IsMagical, Is.True);
            Assert.That(item.Magic.Bonus, Is.EqualTo(90210));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
        }
    }
}