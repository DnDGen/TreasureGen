using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Domain.Items.Mundane;
using TreasureGen.Generators.Items.Mundane;
using TreasureGen.Selectors;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class MundaneArmorGeneratorTests
    {
        private IMundaneItemGenerator mundaneArmorGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mundaneArmorGenerator = new MundaneArmorGenerator(mockPercentileSelector.Object, mockAttributesSelector.Object);

            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns("armor type");
        }

        [Test]
        public void ReturnArmor()
        {
            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor, Is.Not.Null);
        }

        [Test]
        public void GetArmorTypeFromPercentileSelector()
        {
            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("armor type"));
        }

        [Test]
        public void SetMasterworkTraitIfTypeIsStuddedLeatherArmor()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(ArmorConstants.StuddedLeatherArmor);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo(ArmorConstants.StuddedLeatherArmor));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GetShieldTypeIfResultIsDarkwood()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(TraitConstants.Darkwood);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.DarkwoodShields)).Returns("big shield");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Darkwood));
        }

        [Test]
        public void GetShieldTypeIfResultIsMasterworkShield()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(TraitConstants.Masterwork);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MasterworkShields)).Returns("big shield");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockAttributesSelector.Setup(p => p.SelectFrom(tableName, "armor type")).Returns(attributes);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GenerateSizeFromPercentileSelector()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.ArmorSizes)).Returns("armor size");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Contains.Item("armor size"));
            Assert.That(armor.Traits.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetAttributesForDarkwoodShields()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(TraitConstants.Darkwood);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.DarkwoodShields)).Returns("big shield");
            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = String.Format(TableNameConstants.Attributes.Formattable.SpecificITEMTYPEAttributes, AttributeConstants.Shield);
            mockAttributesSelector.Setup(s => s.SelectFrom(tableName, "big shield")).Returns(attributes);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GetSizesForDarkwoodShields()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors)).Returns(TraitConstants.Darkwood);
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.DarkwoodShields)).Returns("big shield");
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.ArmorSizes)).Returns("armor size");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item("armor size"));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Darkwood));
            Assert.That(armor.Traits.Count(), Is.EqualTo(2));
        }
    }
}