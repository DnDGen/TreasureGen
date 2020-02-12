using DnDGen.Infrastructure.Generators;
using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Generators.Items.Magical;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Items.Mundane;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Selectors.Selections;
using DnDGen.TreasureGen.Tables;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class RodGeneratorTests
    {
        private MagicalItemGenerator rodGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<ICollectionSelector> mockCollectionsSelector;
        private Mock<IChargesGenerator> mockChargesGenerator;
        private Mock<ITreasurePercentileSelector> mockPercentileSelector;
        private TypeAndAmountSelection selection;
        private string power;
        private ItemVerifier itemVerifier;
        private Mock<ISpecialAbilitiesGenerator> mockSpecialAbilitiesGenerator;
        private Mock<MundaneItemGenerator> mockMundaneWeaponGenerator;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockCollectionsSelector = new Mock<ICollectionSelector>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            selection = new TypeAndAmountSelection();
            mockPercentileSelector = new Mock<ITreasurePercentileSelector>();
            mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            mockMundaneWeaponGenerator = new Mock<MundaneItemGenerator>();
            var mockJustInTimeFactory = new Mock<JustInTimeFactory>();

            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>(ItemTypeConstants.Weapon)).Returns(mockMundaneWeaponGenerator.Object);

            rodGenerator = new RodGenerator(mockTypeAndAmountPercentileSelector.Object,
                mockCollectionsSelector.Object,
                mockChargesGenerator.Object,
                mockPercentileSelector.Object,
                mockSpecialAbilitiesGenerator.Object,
                mockJustInTimeFactory.Object);
            itemVerifier = new ItemVerifier();

            selection.Type = "rod of ability";
            selection.Amount = 9266;
            power = "power";

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Rod);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(selection);
        }

        [Test]
        public void GenerateRod()
        {
            var rod = rodGenerator.GenerateFrom(power);
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.Name, Is.EqualTo(selection.Type));
            Assert.That(rod.Magic.Bonus, Is.EqualTo(selection.Amount));
            Assert.That(rod, Is.Not.InstanceOf<Weapon>());
        }

        [Test]
        public void GetBaseNames()
        {
            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, selection.Type)).Returns(baseNames);

            var rod = rodGenerator.GenerateFrom(power);
            Assert.That(rod.BaseNames, Is.EqualTo(baseNames));
        }

        [Test]
        public void MinorPowerThrowsError()
        {
            Assert.That(() => rodGenerator.GenerateFrom(PowerConstants.Minor), Throws.ArgumentException.With.Message.EqualTo("Cannot generate minor rods"));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(attributes);

            var rod = rodGenerator.GenerateFrom(power);
            Assert.That(rod.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GetChargesIfCharged()
        {
            var attributes = new[] { AttributeConstants.Charged };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, selection.Type)).Returns(90210);

            var rod = rodGenerator.GenerateFrom(power);
            Assert.That(rod.Magic.Charges, Is.EqualTo(90210));
        }

        [Test]
        public void DoNotGetChargesIfNotCharged()
        {
            var attributes = new[] { "new attribute" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, selection.Type)).Returns(90210);

            var rod = rodGenerator.GenerateFrom(power);
            Assert.That(rod.Magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public void RodOfAbsorptionContainsLevelsIfSelectorSaysSo()
        {
            selection.Type = RodConstants.Absorption;
            var attributes = new[] { AttributeConstants.Charged };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, selection.Type)).Returns(42);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, RodConstants.Absorption_Full)).Returns(50);
            mockPercentileSelector.Setup(s => s.SelectFrom<bool>(TableNameConstants.Percentiles.Set.RodOfAbsorptionContainsSpellLevels)).Returns(true);

            var rod = rodGenerator.GenerateFrom(power);
            Assert.That(rod.Magic.Charges, Is.EqualTo(42));
            Assert.That(rod.Contents, Contains.Item("4 spell levels"));
            Assert.That(rod.Contents.Count, Is.EqualTo(1));
        }

        [Test]
        public void RodOfAbsorptionDoesNotContainLevelsIfSelectorSaysSo()
        {
            selection.Type = RodConstants.Absorption;
            var attributes = new[] { AttributeConstants.Charged };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, selection.Type)).Returns(42);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, RodConstants.Absorption_Full)).Returns(50);
            mockPercentileSelector.Setup(s => s.SelectFrom<bool>(TableNameConstants.Percentiles.Set.RodOfAbsorptionContainsSpellLevels)).Returns(false);

            var rod = rodGenerator.GenerateFrom(power);
            Assert.That(rod.Magic.Charges, Is.EqualTo(42));
            Assert.That(rod.Contents, Is.Empty);
        }

        [Test]
        public void GetRodThatIsAlsoWeapon()
        {
            var baseNames = new[] { "base name", "other base name", WeaponConstants.LightMace };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, selection.Type)).Returns(baseNames);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, selection.Type)).Returns(attributes);

            var mundaneWeapon = itemVerifier.CreateRandomWeaponTemplate(WeaponConstants.LightMace);
            mockMundaneWeaponGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == WeaponConstants.LightMace), false)).Returns(mundaneWeapon);

            var rod = rodGenerator.GenerateFrom(power);
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.Name, Is.EqualTo(selection.Type));
            Assert.That(rod.Magic.Bonus, Is.EqualTo(selection.Amount));
            Assert.That(rod.BaseNames, Is.EqualTo(baseNames));
            Assert.That(rod, Is.InstanceOf<Weapon>());

            var weapon = rod as Weapon;
            Assert.That(weapon.Attributes, Is.SupersetOf(mundaneWeapon.Attributes));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo(mundaneWeapon.CriticalMultiplier));
            Assert.That(weapon.Damage, Is.EqualTo(mundaneWeapon.Damage));
            Assert.That(weapon.DamageType, Is.EqualTo(mundaneWeapon.DamageType));
            Assert.That(weapon.Size, Is.EqualTo(mundaneWeapon.Size));
            Assert.That(weapon.ThreatRange, Is.EqualTo(mundaneWeapon.ThreatRange));
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
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

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(template.Magic.SpecialAbilities)).Returns(abilities);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Rod);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Amount = 9266, Type = "other rod" },
                new TypeAndAmountSelection { Amount = 0, Type = name },
            });

            var rod = rodGenerator.GenerateFrom(template);
            itemVerifier.AssertMagicalItemFromTemplate(rod, template);
            Assert.That(rod.Attributes, Is.EquivalentTo(attributes));
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.Quantity, Is.EqualTo(1));
            Assert.That(rod.BaseNames, Is.EqualTo(baseNames));
            Assert.That(rod.Magic.Bonus, Is.EqualTo(0));
        }

        [Test]
        public void GenerateCustomRodWithBonus()
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

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(template.Magic.SpecialAbilities)).Returns(abilities);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Rod);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Amount = 90210, Type = "other rod" },
                new TypeAndAmountSelection { Amount = 9266, Type = name },
            });

            var rod = rodGenerator.GenerateFrom(template);
            itemVerifier.AssertMagicalItemFromTemplate(rod, template);
            Assert.That(rod.Attributes, Is.EquivalentTo(attributes));
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.Quantity, Is.EqualTo(1));
            Assert.That(rod.BaseNames, Is.EqualTo(baseNames));
            Assert.That(rod.Magic.Bonus, Is.EqualTo(9266));
        }

        [Test]
        public void GenerateCustomRodThatCanBeAWeapon()
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

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(template.Magic.SpecialAbilities)).Returns(abilities);

            var baseNames = new[] { "base name", "other base name", WeaponConstants.Club };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Rod);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Amount = 90210, Type = "other rod" },
                new TypeAndAmountSelection { Amount = 9266, Type = name },
            });

            var mundaneWeapon = itemVerifier.CreateRandomWeaponTemplate(WeaponConstants.Club);
            mockMundaneWeaponGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == WeaponConstants.Club), false)).Returns(mundaneWeapon);

            var rod = rodGenerator.GenerateFrom(template);
            itemVerifier.AssertMagicalItemFromTemplate(rod, template);
            Assert.That(rod.Attributes, Is.SupersetOf(attributes));
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.Quantity, Is.EqualTo(1));
            Assert.That(rod.Magic.SpecialAbilities, Is.EqualTo(abilities));
            Assert.That(rod.BaseNames, Is.EqualTo(baseNames));
            Assert.That(rod.Magic.Bonus, Is.EqualTo(9266));
            Assert.That(rod, Is.InstanceOf<Weapon>());

            var weapon = rod as Weapon;
            Assert.That(weapon.Attributes, Is.SupersetOf(mundaneWeapon.Attributes));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo(mundaneWeapon.CriticalMultiplier));
            Assert.That(weapon.Damage, Is.EqualTo(mundaneWeapon.Damage));
            Assert.That(weapon.DamageType, Is.EqualTo(mundaneWeapon.DamageType));
            Assert.That(weapon.Size, Is.EqualTo(mundaneWeapon.Size));
            Assert.That(weapon.ThreatRange, Is.EqualTo(mundaneWeapon.ThreatRange));
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
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

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(template.Magic.SpecialAbilities)).Returns(abilities);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Rod);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Amount = 90210, Type = "other rod" },
                new TypeAndAmountSelection { Amount = 9266, Type = name },
            });

            var rod = rodGenerator.GenerateFrom(template, true);
            itemVerifier.AssertMagicalItemFromTemplate(rod, template);
            Assert.That(rod.Attributes, Is.EquivalentTo(attributes));
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.Quantity, Is.EqualTo(1));
            Assert.That(rod.BaseNames, Is.EqualTo(baseNames));
            Assert.That(rod.Magic.Bonus, Is.EqualTo(9266));
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

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(template.Magic.SpecialAbilities)).Returns(abilities);

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Rod);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Amount = 90210, Type = "other rod" },
                new TypeAndAmountSelection { Amount = 0, Type = name },
            });

            var rod = rodGenerator.GenerateFrom(template);
            itemVerifier.AssertMagicalItemFromTemplate(rod, template);
            Assert.That(rod.Attributes, Is.EquivalentTo(attributes));
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.Quantity, Is.EqualTo(1));
            Assert.That(rod.BaseNames, Is.EqualTo(baseNames));
            Assert.That(rod.Magic.Bonus, Is.EqualTo(0));
        }

        [Test]
        public void GenerateFromName()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Rod);
            mockTypeAndAmountPercentileSelector
                .Setup(s => s.SelectAllFrom(tableName))
                .Returns(new[]
                {
                    new TypeAndAmountSelection { Type = "wrong rod", Amount = 9266 },
                    new TypeAndAmountSelection { Type = "rod", Amount = 90210 },
                    new TypeAndAmountSelection { Type = "other rod", Amount = 42 },
                });

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "rod")).Returns(baseNames);

            var attributes = new[] { "attribute 1", "attribute 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, "rod")).Returns(attributes);

            mockCollectionsSelector
                .Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<TypeAndAmountSelection>>()))
                .Returns((IEnumerable<TypeAndAmountSelection> c) => c.Last());

            var rod = rodGenerator.GenerateFrom(power, "rod");
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.Name, Is.EqualTo("rod"));
            Assert.That(rod.BaseNames, Is.EqualTo(baseNames));
            Assert.That(rod.Magic.Bonus, Is.EqualTo(90210));
            Assert.That(rod.Attributes, Is.EqualTo(attributes));
            Assert.That(rod, Is.Not.InstanceOf<Weapon>());
        }

        [Test]
        public void GenerateFromBaseName()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Rod);
            mockTypeAndAmountPercentileSelector
                .Setup(s => s.SelectAllFrom(tableName))
                .Returns(new[]
                {
                    new TypeAndAmountSelection { Type = "wrong rod", Amount = 9266 },
                    new TypeAndAmountSelection { Type = "rod", Amount = 90210 },
                    new TypeAndAmountSelection { Type = "other rod", Amount = 42 },
                });

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "rod")).Returns(baseNames);

            var attributes = new[] { "attribute 1", "attribute 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, "rod")).Returns(attributes);

            mockCollectionsSelector
                .Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<TypeAndAmountSelection>>()))
                .Returns((IEnumerable<TypeAndAmountSelection> c) => c.Last());

            var rod = rodGenerator.GenerateFrom(power, "base name");
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.Name, Is.EqualTo("rod"));
            Assert.That(rod.BaseNames, Is.EqualTo(baseNames));
            Assert.That(rod.Magic.Bonus, Is.EqualTo(90210));
            Assert.That(rod.Attributes, Is.EqualTo(attributes));
            Assert.That(rod, Is.Not.InstanceOf<Weapon>());
        }

        [Test]
        public void GenerateAsWeaponFromName()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Rod);
            mockTypeAndAmountPercentileSelector
                .Setup(s => s.SelectAllFrom(tableName))
                .Returns(new[]
                {
                    new TypeAndAmountSelection { Type = "wrong rod", Amount = 9266 },
                    new TypeAndAmountSelection { Type = "rod", Amount = 90210 },
                    new TypeAndAmountSelection { Type = "other rod", Amount = 42 },
                });

            var baseNames = new[] { WeaponConstants.LightMace, "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "rod")).Returns(baseNames);

            var attributes = new[] { "attribute 1", "attribute 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, "rod")).Returns(attributes);

            var mundaneWeapon = itemVerifier.CreateRandomWeaponTemplate(WeaponConstants.LightMace);
            mockMundaneWeaponGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == WeaponConstants.LightMace), false)).Returns(mundaneWeapon);

            mockCollectionsSelector
                .Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<TypeAndAmountSelection>>()))
                .Returns((IEnumerable<TypeAndAmountSelection> c) => c.Last());

            var rod = rodGenerator.GenerateFrom(power, "rod");
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.Name, Is.EqualTo("rod"));
            Assert.That(rod.BaseNames, Is.EqualTo(baseNames));
            Assert.That(rod.Magic.Bonus, Is.EqualTo(90210));
            Assert.That(rod.Attributes, Is.SupersetOf(attributes));
            Assert.That(rod, Is.InstanceOf<Weapon>());

            var weapon = rod as Weapon;
            Assert.That(weapon.Attributes, Is.SupersetOf(mundaneWeapon.Attributes));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo(mundaneWeapon.CriticalMultiplier));
            Assert.That(weapon.Damage, Is.EqualTo(mundaneWeapon.Damage));
            Assert.That(weapon.DamageType, Is.EqualTo(mundaneWeapon.DamageType));
            Assert.That(weapon.Size, Is.EqualTo(mundaneWeapon.Size));
            Assert.That(weapon.ThreatRange, Is.EqualTo(mundaneWeapon.ThreatRange));
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void MinorPowerFromNameThrowsError()
        {
            Assert.That(() => rodGenerator.GenerateFrom(PowerConstants.Minor, "rod"), Throws.ArgumentException.With.Message.EqualTo("Cannot generate minor rods"));
        }

        [Test]
        public void GenerateFromName_MultipleOfPower()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Rod);
            mockTypeAndAmountPercentileSelector
                .Setup(s => s.SelectAllFrom(tableName))
                .Returns(new[]
                {
                    new TypeAndAmountSelection { Type = "wrong rod", Amount = 9266 },
                    new TypeAndAmountSelection { Type = "rod", Amount = 90210 },
                    new TypeAndAmountSelection { Type = "rod", Amount = 42 },
                });

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "rod")).Returns(baseNames);

            var attributes = new[] { "attribute 1", "attribute 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, "rod")).Returns(attributes);

            mockCollectionsSelector
                .Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<TypeAndAmountSelection>>()))
                .Returns((IEnumerable<TypeAndAmountSelection> c) => c.Last());

            var rod = rodGenerator.GenerateFrom(power, "rod");
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.Name, Is.EqualTo("rod"));
            Assert.That(rod.BaseNames, Is.EqualTo(baseNames));
            Assert.That(rod.Magic.Bonus, Is.EqualTo(42));
            Assert.That(rod.Attributes, Is.EqualTo(attributes));
            Assert.That(rod, Is.Not.InstanceOf<Weapon>());
        }

        [Test]
        public void GenerateFromName_NoneOfPower()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Rod);
            mockTypeAndAmountPercentileSelector
                .Setup(s => s.SelectAllFrom(tableName))
                .Returns(new[]
                {
                    new TypeAndAmountSelection { Type = "wrong rod", Amount = 9266 },
                    new TypeAndAmountSelection { Type = "other rod", Amount = 42 },
                });

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "rod")).Returns(baseNames);

            var attributes = new[] { "attribute 1", "attribute 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, "rod")).Returns(attributes);

            mockCollectionsSelector
                .Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<TypeAndAmountSelection>>()))
                .Returns((IEnumerable<TypeAndAmountSelection> c) => c.Last());

            Assert.That(() => rodGenerator.GenerateFrom(power, "rod"),
                Throws.ArgumentException.With.Message.EqualTo("rod is not a valid power Rod"));
        }

        [Test]
        public void IsItemOfPower_ReturnsFalse_WhenMinorPower()
        {
            var isOfPower = rodGenerator.IsItemOfPower("rod", PowerConstants.Minor);
            Assert.That(isOfPower, Is.False);
        }

        [Test]
        public void IsItemOfPower_ReturnsFalse()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Rod);
            mockTypeAndAmountPercentileSelector
                .Setup(s => s.SelectAllFrom(tableName))
                .Returns(new[]
                {
                    new TypeAndAmountSelection { Type = "wrong rod", Amount = 9266 },
                    new TypeAndAmountSelection { Type = "other rod", Amount = 42 },
                });

            var isOfPower = rodGenerator.IsItemOfPower("rod", power);
            Assert.That(isOfPower, Is.False);
        }

        [Test]
        public void IsItemOfPower_ReturnsTrue_Name()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Rod);
            mockTypeAndAmountPercentileSelector
                .Setup(s => s.SelectAllFrom(tableName))
                .Returns(new[]
                {
                    new TypeAndAmountSelection { Type = "wrong rod", Amount = 9266 },
                    new TypeAndAmountSelection { Type = "rod", Amount = 90210 },
                    new TypeAndAmountSelection { Type = "other rod", Amount = 42 },
                });

            var isOfPower = rodGenerator.IsItemOfPower("rod", power);
            Assert.That(isOfPower, Is.True);
        }

        [Test]
        public void IsItemOfPower_ReturnsTrue_BaseName()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Rod);
            mockTypeAndAmountPercentileSelector
                .Setup(s => s.SelectAllFrom(tableName))
                .Returns(new[]
                {
                    new TypeAndAmountSelection { Type = "wrong rod", Amount = 9266 },
                    new TypeAndAmountSelection { Type = "other rod", Amount = 42 },
                });

            var baseNames = new[] { "base name", "rod" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "other rod")).Returns(baseNames);

            var isOfPower = rodGenerator.IsItemOfPower("rod", power);
            Assert.That(isOfPower, Is.True);
        }
    }
}