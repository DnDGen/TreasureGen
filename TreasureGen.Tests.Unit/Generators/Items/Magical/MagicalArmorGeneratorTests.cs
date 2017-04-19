using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using TreasureGen.Domain.Generators.Items;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalArmorGeneratorTests
    {
        private MagicalItemGenerator magicalArmorGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private Mock<ISpecialAbilitiesGenerator> mockSpecialAbilitiesGenerator;
        private Mock<IMagicalItemTraitsGenerator> mockMagicItemTraitsGenerator;
        private Mock<ISpecificGearGenerator> mockSpecificGearGenerator;
        private TypeAndAmountPercentileResult result;
        private string power;
        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            mockMagicItemTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            mockSpecificGearGenerator = new Mock<ISpecificGearGenerator>();
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            var generator = new ConfigurableIterativeGenerator(5);
            magicalArmorGenerator = new MagicalArmorGenerator(
                mockTypeAndAmountPercentileSelector.Object,
                mockPercentileSelector.Object,
                mockCollectionsSelector.Object,
                mockSpecialAbilitiesGenerator.Object,
                mockSpecificGearGenerator.Object,
                generator);

            itemVerifier = new ItemVerifier();

            result = new TypeAndAmountPercentileResult();
            result.Type = "armor type";
            result.Amount = 9266;
            power = "power";

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(result);
        }

        [Test]
        public void GetArmor()
        {
            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void GetBonusFromSelector()
        {
            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor.Magic.Bonus, Is.EqualTo(9266));
        }

        [Test]
        public void GetNameFromPercentileSelector()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, result.Type);
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("armor name");

            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor.Name, Is.EqualTo("armor name"));
        }

        [Test]
        public void GetBaseNames()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, result.Type);
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("armor name");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "armor name")).Returns(baseNames);

            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, result.Type);
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("armor name");

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "armor name")).Returns(attributes);

            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GetSpecialAbilitiesFromGenerator()
        {
            var abilityResult = new TypeAndAmountPercentileResult();
            abilityResult.Type = "SpecialAbility";
            abilityResult.Amount = 1;

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns(abilityResult).Returns(abilityResult).Returns(result);

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, It.IsAny<string>())).Returns(attributes);

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Armor, attributes, power, 9266, 2)).Returns(abilities);

            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor.Magic.SpecialAbilities, Is.EqualTo(abilities));
        }

        [Test]
        public void GetSpecificArmorsFromGenerator()
        {
            result.Amount = 0;

            var specificArmor = new Item();
            mockSpecificGearGenerator.Setup(g => g.GenerateFrom(power, result.Type)).Returns(specificArmor);

            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor, Is.EqualTo(specificArmor));
        }

        [Test]
        public void GenerateCustomArmor()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var attributes = new[] { "type 1", "type 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            var specialAbilityNames = template.Magic.SpecialAbilities.Select(a => a.Name);
            var abilities = new[]
            {
                new SpecialAbility { Name = specialAbilityNames.First() },
                new SpecialAbility { Name = specialAbilityNames.Last() }
            };

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(template.Magic.SpecialAbilities)).Returns(abilities);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, template.Name)).Returns(baseNames);

            var armor = magicalArmorGenerator.Generate(template);
            itemVerifier.AssertMagicalItemFromTemplate(armor, template);
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Attributes, Is.EquivalentTo(attributes));
            Assert.That(armor.Magic.SpecialAbilities, Is.EquivalentTo(abilities));
            Assert.That(armor.BaseNames, Is.EquivalentTo(baseNames));
        }

        [Test]
        public void GenerateRandomCustomArmor()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            var specialAbilityNames = template.Magic.SpecialAbilities.Select(a => a.Name);

            var attributes = new[] { "type 1", "type 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Returns(attributes);

            var abilities = new[]
            {
                new SpecialAbility { Name = specialAbilityNames.First() },
                new SpecialAbility { Name = specialAbilityNames.Last() }
            };

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(template.Magic.SpecialAbilities)).Returns(abilities);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, template.Name)).Returns(baseNames);

            var armor = magicalArmorGenerator.Generate(template, true);
            itemVerifier.AssertMagicalItemFromTemplate(armor, template);
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Attributes, Is.EquivalentTo(attributes));
            Assert.That(armor.Magic.SpecialAbilities, Is.EquivalentTo(abilities));
            Assert.That(armor.BaseNames, Is.EquivalentTo(baseNames));
        }

        [Test]
        public void GenerateSpecificCustomArmor()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            var specialAbilityNames = template.Magic.SpecialAbilities.Select(a => a.Name);

            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, name)).Throws<ArgumentException>();

            var abilities = new[]
            {
                new SpecialAbility { Name = specialAbilityNames.First() },
                new SpecialAbility { Name = specialAbilityNames.Last() }
            };

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(template.Magic.SpecialAbilities)).Returns(abilities);

            var specificArmor = itemVerifier.CreateRandomTemplate(name);
            specificArmor.ItemType = ItemTypeConstants.Armor;
            mockSpecificGearGenerator.Setup(g => g.GenerateFrom(template)).Returns(specificArmor);
            mockSpecificGearGenerator.Setup(g => g.TemplateIsSpecific(template)).Returns(true);

            var armor = magicalArmorGenerator.Generate(template, true);
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.Name, Is.EqualTo(specificArmor.Name));
            Assert.That(armor.BaseNames, Is.EquivalentTo(specificArmor.BaseNames));
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Magic.SpecialAbilities, Is.EquivalentTo(specificArmor.Magic.SpecialAbilities));
        }

        [Test]
        public void GenerateFromSubset()
        {
            var abilityResult = new TypeAndAmountPercentileResult();
            abilityResult.Type = "SpecialAbility";
            abilityResult.Amount = 1;

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns(abilityResult).Returns(new TypeAndAmountPercentileResult { Type = "wrong armor type", Amount = 666 })
                .Returns(abilityResult).Returns(abilityResult).Returns(new TypeAndAmountPercentileResult { Type = "armor type", Amount = 9266 })
                .Returns(abilityResult).Returns(abilityResult).Returns(abilityResult).Returns(new TypeAndAmountPercentileResult { Type = "other armor type", Amount = 90210 });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "wrong armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong armor name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("armor name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "other armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other armor name");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "armor name")).Returns(baseNames);

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "armor name")).Returns(attributes);

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Armor, attributes, power, 9266, 2)).Returns(abilities);

            var subset = new[] { "other armor name", "armor name" };

            var armor = magicalArmorGenerator.GenerateFromSubset(power, subset);
            Assert.That(armor.Name, Is.EqualTo("armor name"));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
            Assert.That(armor.Magic.SpecialAbilities, Is.EquivalentTo(abilities));
        }

        [Test]
        public void GenerateFromSubsetWithBaseName()
        {
            var abilityResult = new TypeAndAmountPercentileResult();
            abilityResult.Type = "SpecialAbility";
            abilityResult.Amount = 1;

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns(abilityResult).Returns(new TypeAndAmountPercentileResult { Type = "wrong armor type", Amount = 666 })
                .Returns(abilityResult).Returns(abilityResult).Returns(new TypeAndAmountPercentileResult { Type = "armor type", Amount = 9266 })
                .Returns(abilityResult).Returns(abilityResult).Returns(abilityResult).Returns(new TypeAndAmountPercentileResult { Type = "other armor type", Amount = 90210 });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "wrong armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong armor name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("armor name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "other armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other armor name");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "armor name")).Returns(baseNames);

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "armor name")).Returns(attributes);

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Armor, attributes, power, 9266, 2)).Returns(abilities);

            var subset = new[] { "other armor name", "base name" };

            var armor = magicalArmorGenerator.GenerateFromSubset(power, subset);
            Assert.That(armor.Name, Is.EqualTo("armor name"));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
            Assert.That(armor.Magic.SpecialAbilities, Is.EquivalentTo(abilities));
        }

        [Test]
        public void GenerateSpecificFromSubset()
        {
            var abilityResult = new TypeAndAmountPercentileResult();
            abilityResult.Type = "SpecialAbility";
            abilityResult.Amount = 1;

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns(abilityResult).Returns(new TypeAndAmountPercentileResult { Type = "wrong armor type", Amount = 666 })
                .Returns(abilityResult).Returns(abilityResult).Returns(new TypeAndAmountPercentileResult { Type = "armor type", Amount = 0 })
                .Returns(abilityResult).Returns(abilityResult).Returns(abilityResult).Returns(new TypeAndAmountPercentileResult { Type = "other armor type", Amount = 90210 });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "wrong armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong armor name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "other armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other armor name");

            var baseNames = new[] { "base name", "other base name" };
            var attributes = new[] { "type 1", "type 2" };
            var abilities = new[] { new SpecialAbility(), new SpecialAbility() };

            var specificArmor = new Item();
            specificArmor.Name = "armor name";
            specificArmor.BaseNames = baseNames;
            specificArmor.ItemType = ItemTypeConstants.Armor;
            specificArmor.Attributes = attributes;
            specificArmor.Magic.Bonus = 42;
            specificArmor.Magic.SpecialAbilities = abilities;

            mockSpecificGearGenerator.Setup(g => g.GenerateFrom(power, "armor type")).Returns(specificArmor);

            var subset = new[] { "other armor name", "armor name" };

            var armor = magicalArmorGenerator.GenerateFromSubset(power, subset);
            Assert.That(armor, Is.EqualTo(specificArmor));
            Assert.That(armor.Name, Is.EqualTo("armor name"));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.Magic.Bonus, Is.EqualTo(42));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
            Assert.That(armor.Magic.SpecialAbilities, Is.EquivalentTo(abilities));
        }

        [Test]
        public void GenerateDefaultFromSubset()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(new TypeAndAmountPercentileResult { Type = "wrong armor type", Amount = 666 });
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountPercentileResult { Type = "wrong armor type", Amount = 42 },
                new TypeAndAmountPercentileResult { Type = "armor type", Amount = 9266 },
                new TypeAndAmountPercentileResult { Type = "other armor type", Amount = 90210 },
            });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "wrong armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong armor name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("armor name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "other armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other armor name");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "armor name")).Returns(baseNames);

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "armor name")).Returns(attributes);

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Armor, attributes, power, 9266, 2)).Returns(abilities);

            var subset = new[] { "other armor name", "armor name" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var armor = magicalArmorGenerator.GenerateFromSubset(power, subset);
            Assert.That(armor.Name, Is.EqualTo("armor name"));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.Magic.Bonus, Is.EqualTo(42));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
            Assert.That(armor.Magic.SpecialAbilities, Is.Empty);
        }

        [Test, Ignore("Cannot set the base name on a default")]
        public void GenerateDefaultFromSubsetWithBaseName()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(new TypeAndAmountPercentileResult { Type = "wrong armor type", Amount = 666 });
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountPercentileResult { Type = "wrong armor type", Amount = 666 },
                new TypeAndAmountPercentileResult { Type = "armor type", Amount = 9266 },
                new TypeAndAmountPercentileResult { Type = "other armor type", Amount = 90210 },
            });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "wrong armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong armor name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("armor name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "other armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other armor name");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "armor name")).Returns(baseNames);

            var attributes = new[] { "type 1", "type 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Armor);
            mockCollectionsSelector.Setup(p => p.SelectFrom(tableName, "armor name")).Returns(attributes);

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Armor, attributes, power, 9266, It.IsAny<int>())).Returns(abilities);

            var subset = new[] { "other armor name", "base name" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var armor = magicalArmorGenerator.GenerateFromSubset(power, subset);
            Assert.That(armor.Name, Is.EqualTo("armor name"));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
            Assert.That(armor.Magic.SpecialAbilities, Is.Empty);
        }

        [Test]
        public void GenerateDefaultSpecificFromSubset()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(new TypeAndAmountPercentileResult { Type = "wrong armor type", Amount = 666 });
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountPercentileResult { Type = "wrong armor type", Amount = 666 },
                new TypeAndAmountPercentileResult { Type = "armor type", Amount = 0 },
                new TypeAndAmountPercentileResult { Type = "other armor type", Amount = 90210 },
            });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "wrong armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong armor name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "other armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other armor name");

            var baseNames = new[] { "base name", "other base name" };
            var attributes = new[] { "type 1", "type 2" };
            var abilities = new[] { new SpecialAbility(), new SpecialAbility() };

            var specificArmor = new Item();
            specificArmor.Name = "armor name";
            specificArmor.BaseNames = baseNames;
            specificArmor.ItemType = ItemTypeConstants.Armor;
            specificArmor.Attributes = attributes;
            specificArmor.Magic.Bonus = 42;
            specificArmor.Magic.SpecialAbilities = abilities;

            mockSpecificGearGenerator.Setup(g => g.TemplateIsSpecific(It.Is<Item>(i => i.Name == "armor name"))).Returns(true);
            mockSpecificGearGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == "armor name"))).Returns(specificArmor);

            var subset = new[] { "other armor name", "armor name" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var armor = magicalArmorGenerator.GenerateFromSubset(power, subset);
            Assert.That(armor.Name, Is.EqualTo("armor name"));
            Assert.That(armor.BaseNames, Is.EqualTo(baseNames));
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.Magic.Bonus, Is.EqualTo(42));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
            Assert.That(armor.Magic.SpecialAbilities, Is.EquivalentTo(abilities));
        }
    }
}