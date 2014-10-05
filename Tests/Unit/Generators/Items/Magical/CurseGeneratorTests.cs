using D20Dice;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Tables.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
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
        public void IfIntermittentFunctioning_GetDesignatedFoe()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.Curses)).Returns("Intermittent Functioning");
            mockDice.Setup(d => d.Roll(1).d3()).Returns(2);
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CursedDependentSituations)).Returns("situation with DESIGNATEDFOE");
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.DesignatedFoes)).Returns("creature type");

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("Intermittent Functioning (Dependent: situation with creature type)"));
        }

        [Test]
        public void IfIntermittentFunctioning_GetAlignment()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.Curses)).Returns("Intermittent Functioning");
            mockDice.Setup(d => d.Roll(1).d3()).Returns(2);
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CursedDependentSituations)).Returns("situation with ALIGNMENT");
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.ProtectionAlignments)).Returns("neutral");

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("Intermittent Functioning (Dependent: situation with neutral)"));
        }

        [Test]
        public void IfIntermittentFunctioning_GetMale()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.Curses)).Returns("Intermittent Functioning");
            mockDice.Setup(d => d.Roll(1).d3()).Returns(2);
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CursedDependentSituations)).Returns("situation with GENDER");
            mockDice.Setup(d => d.Roll(1).d2()).Returns(1);

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("Intermittent Functioning (Dependent: situation with male)"));
        }

        [Test]
        public void IfIntermittentFunctioning_GetFemale()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.Curses)).Returns("Intermittent Functioning");
            mockDice.Setup(d => d.Roll(1).d3()).Returns(2);
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CursedDependentSituations)).Returns("situation with GENDER");
            mockDice.Setup(d => d.Roll(1).d2()).Returns(2);

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("Intermittent Functioning (Dependent: situation with female)"));
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
        public void IfDrawback_GetShrinkOrGrows()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.Curses)).Returns("Drawback");
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CurseDrawbacks)).Returns("drawback with HEIGHTs");
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.CurseHeightChanges)).Returns("grow");

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("drawback with grows"));
        }

        [Test]
        public void GetSpecificCursedItem()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.SpecificCursedItems)).Returns("specific cursed item");

            var cursedItem = curseGenerator.GenerateSpecificCursedItem();
            Assert.That(cursedItem.Name, Is.EqualTo("specific cursed item"));
            Assert.That(cursedItem.IsMagical, Is.True);
            Assert.That(cursedItem.Magic.Curse, Is.EqualTo("This is a specific cursed item"));
        }

        [Test]
        public void SpecificCursedItemsHaveAppropriateItemType()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.SpecificCursedItems)).Returns("specific cursed item");

            var itemType = new[] { "item type" };
            mockAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.SpecificCursedItemItemTypes, "specific cursed item"))
                .Returns(itemType);

            var cursedItem = curseGenerator.GenerateSpecificCursedItem();
            Assert.That(cursedItem.ItemType, Is.EqualTo("item type"));
        }

        [Test]
        public void SpecificCursedItemsHaveAppropriateAttributes()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.SpecificCursedItems)).Returns("specific cursed item");

            var attributes = new[] { "attribute 1", "attribute 2" };
            mockAttributesSelector.Setup(s => s.SelectFrom(TableNameConstants.Attributes.Set.SpecificCursedItemAttributes, "specific cursed item"))
                .Returns(attributes);

            var cursedItem = curseGenerator.GenerateSpecificCursedItem();
            foreach (var attribute in attributes)
                Assert.That(cursedItem.Attributes, Contains.Item(attribute));
        }
    }
}