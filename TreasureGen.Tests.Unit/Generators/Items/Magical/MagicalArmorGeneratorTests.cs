using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Generators.Items;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Selectors.Selections;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;
using TreasureGen.Items.Mundane;

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
        private Mock<MundaneItemGenerator> mockMundaneArmorGenerator;
        private Mock<IMundaneItemGeneratorRuntimeFactory> mockMundaneGeneratorFactory;
        private TypeAndAmountSelection selection;
        private string power;
        private ItemVerifier itemVerifier;
        private Item mundaneArmor;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            mockMagicItemTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            mockSpecificGearGenerator = new Mock<ISpecificGearGenerator>();
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockMundaneArmorGenerator = new Mock<MundaneItemGenerator>();
            mockMundaneGeneratorFactory = new Mock<IMundaneItemGeneratorRuntimeFactory>();

            mockMundaneGeneratorFactory.Setup(f => f.CreateGeneratorOf(ItemTypeConstants.Armor)).Returns(mockMundaneArmorGenerator.Object);

            var generator = new ConfigurableIterativeGenerator(5);
            magicalArmorGenerator = new MagicalArmorGenerator(
                mockTypeAndAmountPercentileSelector.Object,
                mockPercentileSelector.Object,
                mockCollectionsSelector.Object,
                mockSpecialAbilitiesGenerator.Object,
                mockSpecificGearGenerator.Object,
                generator,
                mockMundaneGeneratorFactory.Object);

            itemVerifier = new ItemVerifier();

            selection = new TypeAndAmountSelection();
            selection.Type = "armor type";
            selection.Amount = 9266;
            power = "power";

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(selection);

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, selection.Type);
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("armor name");

            mundaneArmor = new Item();
            mundaneArmor.Name = "armor name";
            mockMundaneArmorGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.NameMatches("armor name")), false)).Returns(mundaneArmor);
        }

        [Test]
        public void GetArmor()
        {
            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor, Is.EqualTo(mundaneArmor));
        }

        [Test]
        public void GetBonusFromSelector()
        {
            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor.Magic.Bonus, Is.EqualTo(9266));
        }

        [Test]
        public void MagicArmorIsMasterwork()
        {
            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GetNameFromPercentileSelector()
        {
            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor.Name, Is.EqualTo("armor name"));
        }

        [Test]
        public void GetSpecialAbilitiesFromGenerator()
        {
            var abilityResult = new TypeAndAmountSelection();
            abilityResult.Type = "SpecialAbility";
            abilityResult.Amount = 1;

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns(abilityResult).Returns(abilityResult).Returns(selection);

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Armor, mundaneArmor.Attributes, power, 9266, 2)).Returns(abilities);

            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor.Magic.SpecialAbilities, Is.EqualTo(abilities));
        }

        [Test]
        public void GetSpecificArmorsFromGenerator()
        {
            selection.Amount = 0;

            var specificArmor = new Item();
            mockSpecificGearGenerator.Setup(g => g.GenerateFrom(power, selection.Type)).Returns(specificArmor);

            var armor = magicalArmorGenerator.GenerateAtPower(power);
            Assert.That(armor, Is.EqualTo(specificArmor));
        }

        [Test]
        public void GenerateCustomArmor()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var specialAbilityNames = template.Magic.SpecialAbilities.Select(a => a.Name);
            var abilities = new[]
            {
                new SpecialAbility { Name = specialAbilityNames.First() },
                new SpecialAbility { Name = specialAbilityNames.Last() }
            };

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(template.Magic.SpecialAbilities)).Returns(abilities);

            var templateMundaneArmor = new Item();
            templateMundaneArmor.Name = name;
            mockMundaneArmorGenerator.Setup(g => g.Generate(template, false)).Returns(templateMundaneArmor);

            var armor = magicalArmorGenerator.Generate(template);
            Assert.That(armor, Is.EqualTo(templateMundaneArmor));
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.Magic.Bonus, Is.EqualTo(template.Magic.Bonus));
            Assert.That(armor.Magic.Charges, Is.EqualTo(template.Magic.Charges));
            Assert.That(armor.Magic.Curse, Is.EqualTo(template.Magic.Curse));
            Assert.That(armor.Magic.Intelligence, Is.EqualTo(template.Magic.Intelligence));
            Assert.That(armor.Magic.SpecialAbilities, Is.EquivalentTo(abilities));

            //INFO: Custom magic armor should be masterwork
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GenerateRandomCustomArmor()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            var specialAbilityNames = template.Magic.SpecialAbilities.Select(a => a.Name);

            var abilities = new[]
            {
                new SpecialAbility { Name = specialAbilityNames.First() },
                new SpecialAbility { Name = specialAbilityNames.Last() }
            };

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(template.Magic.SpecialAbilities)).Returns(abilities);

            var templateMundaneArmor = new Item();
            templateMundaneArmor.Name = name;
            mockMundaneArmorGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.NameMatches(name)), false)).Returns(templateMundaneArmor);

            var armor = magicalArmorGenerator.Generate(template, true);
            Assert.That(armor, Is.EqualTo(templateMundaneArmor));
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.Magic.Bonus, Is.EqualTo(template.Magic.Bonus));
            Assert.That(armor.Magic.Charges, Is.EqualTo(template.Magic.Charges));
            Assert.That(armor.Magic.Curse, Is.EqualTo(template.Magic.Curse));
            Assert.That(armor.Magic.Intelligence, Is.EqualTo(template.Magic.Intelligence));
            Assert.That(armor.Magic.SpecialAbilities, Is.EquivalentTo(abilities));

            //INFO: Custom magic armor should be masterwork
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
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
            var abilityResult = new TypeAndAmountSelection();
            abilityResult.Type = "SpecialAbility";
            abilityResult.Amount = 1;

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns(abilityResult).Returns(new TypeAndAmountSelection { Type = "wrong armor type", Amount = 666 })
                .Returns(abilityResult).Returns(abilityResult).Returns(new TypeAndAmountSelection { Type = "armor type", Amount = 9266 })
                .Returns(abilityResult).Returns(abilityResult).Returns(abilityResult).Returns(new TypeAndAmountSelection { Type = "other armor type", Amount = 90210 });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "wrong armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong armor name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("armor name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "other armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other armor name");

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Armor, It.IsAny<IEnumerable<string>>(), power, 9266, 2)).Returns(abilities);
            mockMundaneArmorGenerator.Setup(g => g.Generate(It.IsAny<Item>(), false)).Returns((Item template, bool decorate) => new Armor { Name = template.Name, BaseNames = new[] { "from mundane" } });

            var subset = new[] { "other armor name", "armor name" };

            var armor = magicalArmorGenerator.GenerateFromSubset(power, subset);
            Assert.That(armor.Name, Is.EqualTo("armor name"));
            Assert.That(armor.BaseNames, Contains.Item("from mundane"));
            Assert.That(armor.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(armor.Magic.SpecialAbilities, Is.EquivalentTo(abilities));
        }

        [Test]
        public void GenerateFromSubsetWithBaseName()
        {
            var abilityResult = new TypeAndAmountSelection();
            abilityResult.Type = "SpecialAbility";
            abilityResult.Amount = 1;

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns(abilityResult).Returns(abilityResult).Returns(new TypeAndAmountSelection { Type = "armor type", Amount = 9266 });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("armor name");

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Armor, It.IsAny<IEnumerable<string>>(), power, 9266, 2)).Returns(abilities);

            var subset = new[] { "other armor name", "base name" };

            mockMundaneArmorGenerator.Setup(g => g.Generate(It.IsAny<Item>(), false)).Returns((Item template, bool decorate) => new Armor { Name = template.Name, BaseNames = new[] { "from mundane", "base name" } });

            var armor = magicalArmorGenerator.GenerateFromSubset(power, subset);
            Assert.That(armor.Name, Is.EqualTo("armor name"));
            Assert.That(armor.BaseNames, Contains.Item("from mundane"));
            Assert.That(armor.BaseNames, Contains.Item("base name"));
            Assert.That(armor.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(armor.Magic.SpecialAbilities, Is.EquivalentTo(abilities));
        }

        [Test]
        public void GenerateSpecificFromSubset()
        {
            var abilityResult = new TypeAndAmountSelection();
            abilityResult.Type = "SpecialAbility";
            abilityResult.Amount = 1;

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            mockTypeAndAmountPercentileSelector.SetupSequence(p => p.SelectFrom(tableName))
                .Returns(abilityResult).Returns(new TypeAndAmountSelection { Type = "wrong armor type", Amount = 666 })
                .Returns(abilityResult).Returns(abilityResult).Returns(new TypeAndAmountSelection { Type = "armor type", Amount = 0 })
                .Returns(abilityResult).Returns(abilityResult).Returns(abilityResult).Returns(new TypeAndAmountSelection { Type = "other armor type", Amount = 90210 });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "wrong armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong armor name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "other armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other armor name");

            mockMundaneArmorGenerator.Setup(g => g.Generate(It.IsAny<Item>(), false)).Returns((Item template, bool decorate) => new Armor { Name = template.Name, BaseNames = new[] { "from mundane" } });

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
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong armor type", Amount = 666 });
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong armor type", Amount = 42 },
                new TypeAndAmountSelection { Type = "armor type", Amount = 9266 },
                new TypeAndAmountSelection { Type = "other armor type", Amount = 90210 },
                new TypeAndAmountSelection { Type = "SpecialAbility", Amount = 1 },
                new TypeAndAmountSelection { Type = "specific armor type", Amount = 0 },
            });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "wrong armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong armor name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("armor name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "other armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other armor name");

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Armor, It.IsAny<IEnumerable<string>>(), power, 9266, 2)).Returns(abilities);

            mockMundaneArmorGenerator.Setup(g => g.Generate(It.IsAny<Item>(), false)).Returns((Item template, bool decorate) => new Armor { Name = template.Name, BaseNames = new[] { "from mundane" } });

            var subset = new[] { "other armor name", "armor name" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var armor = magicalArmorGenerator.GenerateFromSubset(power, subset);
            Assert.That(armor.Name, Is.EqualTo("armor name"));
            Assert.That(armor.BaseNames, Contains.Item("from mundane"));
            Assert.That(armor.Magic.Bonus, Is.EqualTo(42));
            Assert.That(armor.Magic.SpecialAbilities, Is.Empty);
        }

        [Test, Ignore("Cannot set the base name on a default")]
        public void GenerateDefaultFromSubsetWithBaseName()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong armor type", Amount = 666 });
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong armor type", Amount = 666 },
                new TypeAndAmountSelection { Type = "armor type", Amount = 9266 },
                new TypeAndAmountSelection { Type = "other armor type", Amount = 90210 },
                new TypeAndAmountSelection { Type = "SpecialAbility", Amount = 1 },
                new TypeAndAmountSelection { Type = "specific armor type", Amount = 0 },
            });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "wrong armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong armor name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("armor name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "other armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other armor name");

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Armor, It.IsAny<IEnumerable<string>>(), power, 9266, 2)).Returns(abilities);

            mockMundaneArmorGenerator.Setup(g => g.Generate(It.IsAny<Item>(), false)).Returns((Item template, bool decorate) => new Armor { Name = template.Name, BaseNames = new[] { "from mundane" } });

            var subset = new[] { "other armor name", "base name" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var armor = magicalArmorGenerator.GenerateFromSubset(power, subset);
            Assert.That(armor.Name, Is.EqualTo("armor name"));
            Assert.That(armor.BaseNames, Contains.Item("from mundane"));
            Assert.That(armor.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(armor.Magic.SpecialAbilities, Is.Empty);
        }

        [Test]
        public void GenerateDefaultSpecificFromSubset()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong armor type", Amount = 666 });
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong armor type", Amount = 666 },
                new TypeAndAmountSelection { Type = "armor type", Amount = 0 },
                new TypeAndAmountSelection { Type = "other armor type", Amount = 90210 },
                new TypeAndAmountSelection { Type = "SpecialAbility", Amount = 1 },
                new TypeAndAmountSelection { Type = "specific armor type", Amount = 0 },
            });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "wrong armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("wrong armor name");

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, "other armor type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("other armor name");

            mockMundaneArmorGenerator.Setup(g => g.Generate(It.IsAny<Item>(), false)).Returns((Item template, bool decorate) => new Armor { Name = template.Name, BaseNames = new[] { "from mundane" } });

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