using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class RodGeneratorTests
    {
        private MagicalItemGenerator rodGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private Mock<IChargesGenerator> mockChargesGenerator;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private TypeAndAmountPercentileResult result;
        private string power;
        private ItemVerifier itemVerifier;
        private Mock<ISpecialAbilitiesGenerator> mockSpecialAbilitiesGenerator;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            result = new TypeAndAmountPercentileResult();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            rodGenerator = new RodGenerator(mockTypeAndAmountPercentileSelector.Object, mockCollectionsSelector.Object,
                mockChargesGenerator.Object, mockBooleanPercentileSelector.Object, mockSpecialAbilitiesGenerator.Object);
            itemVerifier = new ItemVerifier();

            result.Type = "rod of ability";
            result.Amount = 9266;
            power = "power";

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Rod);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(result);
        }

        [Test]
        public void GenerateRod()
        {
            var rod = rodGenerator.GenerateAtPower(power);
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.Name, Is.EqualTo("rod of ability"));
        }

        [Test]
        public void MinorPowerThrowsError()
        {
            Assert.That(() => rodGenerator.GenerateAtPower(PowerConstants.Minor), Throws.ArgumentException.With.Message.EqualTo("Cannot generate minor rods"));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, result.Type)).Returns(attributes);

            var rod = rodGenerator.GenerateAtPower(power);
            Assert.That(rod.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GetChargesIfCharged()
        {
            var attributes = new[] { AttributeConstants.Charged };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, result.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, result.Type)).Returns(90210);

            var rod = rodGenerator.GenerateAtPower(power);
            Assert.That(rod.Magic.Charges, Is.EqualTo(90210));
        }

        [Test]
        public void DoNotGetChargesIfNotCharged()
        {
            var attributes = new[] { "new attribute" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, result.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, result.Type)).Returns(90210);

            var rod = rodGenerator.GenerateAtPower(power);
            Assert.That(rod.Magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public void RodOfAbsorptionContainsLevelsIfSelectorSaysSo()
        {
            result.Type = RodConstants.Absorption;
            var attributes = new[] { AttributeConstants.Charged };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, result.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, result.Type)).Returns(42);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, result.Type + " (max)")).Returns(50);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.RodOfAbsorptionContainsSpellLevels)).Returns(true);

            var rod = rodGenerator.GenerateAtPower(power);
            Assert.That(rod.Magic.Charges, Is.EqualTo(42));
            Assert.That(rod.Contents, Contains.Item("4 spell levels"));
            Assert.That(rod.Contents.Count, Is.EqualTo(1));
        }

        [Test]
        public void RodOfAbsorptionDoesNotContainLevelsIfSelectorSaysSo()
        {
            result.Type = RodConstants.Absorption;
            var attributes = new[] { AttributeConstants.Charged };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, result.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, result.Type)).Returns(42);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, result.Type + " (max)")).Returns(50);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.RodOfAbsorptionContainsSpellLevels)).Returns(false);

            var rod = rodGenerator.GenerateAtPower(power);
            Assert.That(rod.Magic.Charges, Is.EqualTo(42));
            Assert.That(rod.Contents, Is.Empty);
        }

        [Test]
        public void GenerateCustomRod()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            var specialAbilityNames = template.Magic.SpecialAbilities.Select(a => a.Name);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            var abilities = new[]
            {
                new SpecialAbility { Name = specialAbilityNames.First() },
                new SpecialAbility { Name = specialAbilityNames.Last() }
            };

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(specialAbilityNames)).Returns(abilities);

            var rod = rodGenerator.Generate(template);
            itemVerifier.AssertMagicalItemFromTemplate(rod, template);
            Assert.That(rod.Attributes, Is.EquivalentTo(attributes));
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.Quantity, Is.EqualTo(1));
            Assert.That(rod.Magic.SpecialAbilities, Is.Empty);
        }

        [TestCase(RodConstants.Alertness)]
        [TestCase(RodConstants.Flailing)]
        [TestCase(RodConstants.Python)]
        [TestCase(RodConstants.ThunderAndLightning)]
        [TestCase(RodConstants.Viper)]
        [TestCase(RodConstants.Withering)]
        public void GenerateNamedCustomRod(string name)
        {
            var template = itemVerifier.CreateRandomTemplate(name);
            var specialAbilityNames = template.Magic.SpecialAbilities.Select(a => a.Name);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            var abilities = new[]
            {
                new SpecialAbility { Name = specialAbilityNames.First() },
                new SpecialAbility { Name = specialAbilityNames.Last() }
            };

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(specialAbilityNames)).Returns(abilities);

            var rod = rodGenerator.Generate(template);
            itemVerifier.AssertMagicalItemFromTemplate(rod, template);
            Assert.That(rod.Attributes, Is.EquivalentTo(attributes));
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.Quantity, Is.EqualTo(1));
            Assert.That(rod.Magic.SpecialAbilities, Is.EqualTo(abilities));
        }

        [Test]
        public void GenerateRandomCustomRod()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            var specialAbilityNames = template.Magic.SpecialAbilities.Select(a => a.Name);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            var abilities = new[]
            {
                new SpecialAbility { Name = specialAbilityNames.First() },
                new SpecialAbility { Name = specialAbilityNames.Last() }
            };

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(specialAbilityNames)).Returns(abilities);

            var rod = rodGenerator.Generate(template, true);
            itemVerifier.AssertMagicalItemFromTemplate(rod, template);
            Assert.That(rod.Attributes, Is.EquivalentTo(attributes));
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.Quantity, Is.EqualTo(1));
            Assert.That(rod.Magic.SpecialAbilities, Is.Empty);
        }

        [Test]
        public void GenerateOneTimeUseCustomRod()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            var specialAbilityNames = template.Magic.SpecialAbilities.Select(a => a.Name);

            var attributes = new[] { "attribute 1", "attribute 2", AttributeConstants.OneTimeUse };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            var abilities = new[]
            {
                new SpecialAbility { Name = specialAbilityNames.First() },
                new SpecialAbility { Name = specialAbilityNames.Last() }
            };

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(specialAbilityNames)).Returns(abilities);

            var rod = rodGenerator.Generate(template);
            itemVerifier.AssertMagicalItemFromTemplate(rod, template);
            Assert.That(rod.Attributes, Is.EquivalentTo(attributes));
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.Quantity, Is.EqualTo(1));
            Assert.That(rod.Magic.SpecialAbilities, Is.Empty);
        }
    }
}