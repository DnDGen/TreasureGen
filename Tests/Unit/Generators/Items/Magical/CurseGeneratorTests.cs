using D20Dice;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Interfaces.Items.Magical;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Selectors.Interfaces;
using TreasureGen.Tables.Interfaces;
using Moq;
using NUnit.Framework;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class CurseGeneratorTests
    {
        private ICurseGenerator curseGenerator;
        private Mock<IDice> mockDice;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();

            curseGenerator = new CurseGenerator(mockDice.Object, mockPercentileSelector.Object, mockBooleanPercentileSelector.Object,
                mockAttributesSelector.Object);
        }

        [Test]
        public void NotCursedIfNoMagic()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IsItemCursed)).Returns(true);
            var cursed = curseGenerator.HasCurse(false);
            Assert.That(cursed, Is.False);
        }

        [Test]
        public void NotCursedIfSelectorSaySo()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IsItemCursed)).Returns(false);
            var cursed = curseGenerator.HasCurse(true);
            Assert.That(cursed, Is.False);
        }

        [Test]
        public void CursedIfSelectorSaysSo()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.IsItemCursed)).Returns(true);
            var cursed = curseGenerator.HasCurse(true);
            Assert.That(cursed, Is.True);
        }

        [Test]
        public void GenerateCurseGetsFromPercentileSelector()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.Curses)).Returns("curse");

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("curse"));
        }

        [Test]
        public void IfIntermittentFunctioning_1OnD3IsUnreliable()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.Curses)).Returns("Intermittent Functioning");
            mockDice.Setup(d => d.Roll(1).d3()).Returns(1);

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("Intermittent Functioning (Unreliable)"));
        }

        [Test]
        public void IfIntermittentFunctioning_2OnD3IsDependent()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.Curses)).Returns("Intermittent Functioning");
            mockDice.Setup(d => d.Roll(1).d3()).Returns(2);
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CursedDependentSituations)).Returns("situation");

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("Intermittent Functioning (Dependent: situation)"));
        }

        [Test]
        public void IfIntermittentFunctioning_3OnD3IsUncontrolled()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.Curses)).Returns("Intermittent Functioning");
            mockDice.Setup(d => d.Roll(1).d3()).Returns(3);

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("Intermittent Functioning (Uncontrolled)"));
        }

        [Test]
        public void IfDrawback_GetDrawback()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.Curses)).Returns("Drawback");
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CurseDrawbacks)).Returns("cursed drawback");

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("cursed drawback"));
        }

        [Test]
        public void GetSpecificCursedItem()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.SpecificCursedItems)).Returns("specific cursed item");

            var itemType = new[] { "item type" };
            mockAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.SpecificCursedItemItemTypes, "specific cursed item"))
                .Returns(itemType);

            var attributes = new[] { "attribute 1", "attribute 2" };
            mockAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.SpecificCursedItemAttributes, "specific cursed item"))
                .Returns(attributes);

            var cursedItem = curseGenerator.GenerateSpecificCursedItem();
            Assert.That(cursedItem.Name, Is.EqualTo("specific cursed item"));
            Assert.That(cursedItem.IsMagical, Is.True);
            Assert.That(cursedItem.Magic.Curse, Is.EqualTo(CurseConstants.SpecificCursedItem));
            Assert.That(cursedItem.ItemType, Is.EqualTo("item type"));

            foreach (var attribute in attributes)
                Assert.That(cursedItem.Attributes, Contains.Item(attribute));
        }
    }
}