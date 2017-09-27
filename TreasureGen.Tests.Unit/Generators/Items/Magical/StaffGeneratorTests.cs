using DnDGen.Core.Generators;
using DnDGen.Core.Selectors.Collections;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Selectors.Selections;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class StaffGeneratorTests
    {
        private MagicalItemGenerator staffGenerator;
        private Mock<IChargesGenerator> mockChargesGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<ICollectionSelector> mockCollectionsSelector;
        private string power;
        private ItemVerifier itemVerifier;
        private Mock<ISpecialAbilitiesGenerator> mockSpecialAbilitiesGenerator;
        private Generator generator;
        private Mock<MundaneItemGenerator> mockMundaneWeaponGenerator;
        private TypeAndAmountSelection selection;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            mockCollectionsSelector = new Mock<ICollectionSelector>();
            mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            generator = new IterativeGeneratorWithoutLogging(5);
            mockMundaneWeaponGenerator = new Mock<MundaneItemGenerator>();
            var mockJustInTimeFactory = new Mock<JustInTimeFactory>();

            mockJustInTimeFactory.Setup(f => f.Build<MundaneItemGenerator>(ItemTypeConstants.Weapon)).Returns(mockMundaneWeaponGenerator.Object);

            staffGenerator = new StaffGenerator(mockTypeAndAmountPercentileSelector.Object, mockChargesGenerator.Object, mockCollectionsSelector.Object, mockSpecialAbilitiesGenerator.Object, generator, mockJustInTimeFactory.Object);
            power = "power";
            itemVerifier = new ItemVerifier();
            selection = new TypeAndAmountSelection();

            selection.Type = "staffiness";
            selection.Amount = 90210;

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(selection);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, selection.Type)).Returns(9266);
        }

        [Test]
        public void GenerateStaff()
        {
            var staff = staffGenerator.GenerateFrom(power);
            Assert.That(staff.Name, Is.EqualTo("staffiness"));
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(staff.Attributes.Count(), Is.EqualTo(2));
            Assert.That(staff.Magic.Bonus, Is.EqualTo(90210));
            Assert.That(staff, Is.Not.InstanceOf<Weapon>());
            Assert.That(staff.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
            Assert.That(staff.Magic.Charges, Is.EqualTo(9266));
        }

        [Test]
        public void CannotGenerateMinorStaves()
        {
            Assert.That(() => staffGenerator.GenerateFrom(PowerConstants.Minor), Throws.ArgumentException.With.Message.EqualTo("Cannot generate minor staves"));
        }

        [Test]
        public void GetBaseNames()
        {
            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, selection.Type)).Returns(baseNames);

            var staff = staffGenerator.GenerateFrom(power);
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
        }

        [Test]
        public void GetStaffThatIsAlsoWeapon()
        {
            var baseNames = new[] { "base name", "other base name", WeaponConstants.Dagger };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, selection.Type)).Returns(baseNames);

            var mundaneWeapon = itemVerifier.CreateRandomWeaponTemplate(WeaponConstants.Dagger);
            mockMundaneWeaponGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == WeaponConstants.Dagger), false)).Returns(mundaneWeapon);

            var staff = staffGenerator.GenerateFrom(power);
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Is.EquivalentTo(mundaneWeapon.Attributes.Union(new[] { AttributeConstants.Charged })));
            Assert.That(staff.Magic.Bonus, Is.EqualTo(90210));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
            Assert.That(staff.Magic.Charges, Is.EqualTo(9266));
            Assert.That(staff, Is.InstanceOf<Weapon>());

            var weapon = staff as Weapon;
            Assert.That(weapon.Attributes, Is.SupersetOf(mundaneWeapon.Attributes));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo(mundaneWeapon.CriticalMultiplier));
            Assert.That(weapon.Damage, Is.EqualTo(mundaneWeapon.Damage));
            Assert.That(weapon.DamageType, Is.EqualTo(mundaneWeapon.DamageType));
            Assert.That(weapon.Size, Is.EqualTo(mundaneWeapon.Size));
            Assert.That(weapon.ThreatRange, Is.EqualTo(mundaneWeapon.ThreatRange));
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GenerateCustomStaff()
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

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var staff = staffGenerator.GenerateFrom(template);
            itemVerifier.AssertMagicalItemFromTemplate(staff, template);
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(staff.Attributes.Count(), Is.EqualTo(2));
            Assert.That(staff.Quantity, Is.EqualTo(1));
            Assert.That(staff.BaseNames, Is.EquivalentTo(baseNames));
            Assert.That(staff, Is.Not.InstanceOf<Weapon>());
            Assert.That(staff.Traits, Is.All.Not.EqualTo(TraitConstants.Masterwork));
        }

        [Test]
        public void GenerateCustomStaffThatIsAlsoAWeapon()
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
            var baseNames = new[] { "base name", "other base name", WeaponConstants.Dagger };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var mundaneWeapon = itemVerifier.CreateRandomWeaponTemplate(WeaponConstants.Dagger);
            mockMundaneWeaponGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == WeaponConstants.Dagger), false)).Returns(mundaneWeapon);

            var staff = staffGenerator.GenerateFrom(template);
            itemVerifier.AssertMagicalItemFromTemplate(staff, template);
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Is.EquivalentTo(mundaneWeapon.Attributes.Union(new[] { AttributeConstants.Charged })));
            Assert.That(staff.Attributes, Is.All.Not.EqualTo(AttributeConstants.OneTimeUse));
            Assert.That(staff.Quantity, Is.EqualTo(1));
            Assert.That(staff.Magic.SpecialAbilities, Is.EquivalentTo(abilities));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
            Assert.That(staff, Is.InstanceOf<Weapon>());

            var weapon = staff as Weapon;
            Assert.That(weapon.Attributes, Is.SupersetOf(mundaneWeapon.Attributes));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo(mundaneWeapon.CriticalMultiplier));
            Assert.That(weapon.Damage, Is.EqualTo(mundaneWeapon.Damage));
            Assert.That(weapon.DamageType, Is.EqualTo(mundaneWeapon.DamageType));
            Assert.That(weapon.Size, Is.EqualTo(mundaneWeapon.Size));
            Assert.That(weapon.ThreatRange, Is.EqualTo(mundaneWeapon.ThreatRange));
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GenerateRandomCustomStaff()
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

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var staff = staffGenerator.GenerateFrom(template, true);
            itemVerifier.AssertMagicalItemFromTemplate(staff, template);
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(staff.Attributes.Count(), Is.EqualTo(2));
            Assert.That(staff.Quantity, Is.EqualTo(1));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
            Assert.That(staff, Is.Not.InstanceOf<Weapon>());
        }

        [Test]
        public void GenerateFromSubset()
        {
            var subset = new[] { "other staff", "staff" };

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockTypeAndAmountPercentileSelector.SetupSequence(s => s.SelectFrom(tableName))
                .Returns(new TypeAndAmountSelection { Type = "wrong staff" })
                .Returns(new TypeAndAmountSelection { Type = "staff" })
                .Returns(new TypeAndAmountSelection { Type = "other staff" });

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "staff")).Returns(baseNames);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "wrong staff")).Returns(666);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "staff")).Returns(9266);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "other staff")).Returns(90210);

            var staff = staffGenerator.GenerateFrom(power, subset);
            Assert.That(staff.Name, Is.EqualTo("staff"));
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(staff.Attributes.Count(), Is.EqualTo(2));
            Assert.That(staff.Magic.Bonus, Is.EqualTo(0));
            Assert.That(staff.Magic.Charges, Is.EqualTo(9266));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
            Assert.That(staff, Is.Not.InstanceOf<Weapon>());
        }

        [Test]
        public void GenerateStaffAsWeaponFromSubset()
        {
            var subset = new[] { "other staff", "staff" };

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockTypeAndAmountPercentileSelector.SetupSequence(s => s.SelectFrom(tableName))
                .Returns(new TypeAndAmountSelection { Type = "wrong staff", Amount = 666 })
                .Returns(new TypeAndAmountSelection { Type = "staff", Amount = 42 })
                .Returns(new TypeAndAmountSelection { Type = "other staff", Amount = 600 });

            var baseNames = new[] { "base name", "other base name", WeaponConstants.Quarterstaff };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "staff")).Returns(baseNames);

            var quarterstaff = itemVerifier.CreateRandomWeaponTemplate(WeaponConstants.Quarterstaff);
            mockMundaneWeaponGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == WeaponConstants.Quarterstaff), false)).Returns(quarterstaff);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "wrong staff")).Returns(666);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "staff")).Returns(9266);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "other staff")).Returns(90210);

            var staff = staffGenerator.GenerateFrom(power, subset);
            Assert.That(staff.Name, Is.EqualTo("staff"));
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Is.EquivalentTo(quarterstaff.Attributes.Union(new[] { AttributeConstants.Charged })));
            Assert.That(staff.Attributes, Is.All.Not.EqualTo(AttributeConstants.OneTimeUse));
            Assert.That(staff.Magic.Bonus, Is.EqualTo(42));
            Assert.That(staff.Magic.Charges, Is.EqualTo(9266));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
            Assert.That(staff, Is.InstanceOf<Weapon>());

            var weapon = staff as Weapon;
            Assert.That(weapon.Attributes, Is.SupersetOf(quarterstaff.Attributes));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo(quarterstaff.CriticalMultiplier));
            Assert.That(weapon.Damage, Is.EqualTo(quarterstaff.Damage));
            Assert.That(weapon.DamageType, Is.EqualTo(quarterstaff.DamageType));
            Assert.That(weapon.Size, Is.EqualTo(quarterstaff.Size));
            Assert.That(weapon.ThreatRange, Is.EqualTo(quarterstaff.ThreatRange));
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GenerateDefaultFromSubset()
        {
            var subset = new[] { "other staff", "staff" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong staff", Amount = 666 });

            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong staff", Amount = 666 },
                new TypeAndAmountSelection { Type = "staff", Amount = 42 },
                new TypeAndAmountSelection { Type = "other staff", Amount = 600 },
            });

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "staff")).Returns(baseNames);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "wrong staff")).Returns(666);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "staff")).Returns(9266);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "other staff")).Returns(90210);

            var staff = staffGenerator.GenerateFrom(power, subset);
            Assert.That(staff.Name, Is.EqualTo("staff"));
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(staff.Attributes.Count(), Is.EqualTo(2));
            Assert.That(staff.Magic.Bonus, Is.EqualTo(42));
            Assert.That(staff.Magic.Charges, Is.EqualTo(9266));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
            Assert.That(staff, Is.Not.InstanceOf<Weapon>());
        }

        [Test]
        public void GenerateDefaultFromSubsetFromMedium()
        {
            var subset = new[] { "other staff", "staff" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong staff", Amount = 666 });

            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong staff", Amount = 666 },
                new TypeAndAmountSelection { Type = "other staff", Amount = 600 },
            });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Staff);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong staff", Amount = 666 },
                new TypeAndAmountSelection { Type = "staff", Amount = 42 },
                new TypeAndAmountSelection { Type = "other staff", Amount = 600 },
            });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Major, ItemTypeConstants.Staff);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong staff", Amount = 666 },
                new TypeAndAmountSelection { Type = "other staff", Amount = 600 },
            });

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "staff")).Returns(baseNames);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "wrong staff")).Returns(666);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "staff")).Returns(9266);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "other staff")).Returns(90210);

            var staff = staffGenerator.GenerateFrom(power, subset);
            Assert.That(staff.Name, Is.EqualTo("staff"));
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(staff.Attributes.Count(), Is.EqualTo(2));
            Assert.That(staff.Magic.Bonus, Is.EqualTo(42));
            Assert.That(staff.Magic.Charges, Is.EqualTo(9266));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
            Assert.That(staff, Is.Not.InstanceOf<Weapon>());
        }

        [Test]
        public void GenerateDefaultFromSubsetFromMajor()
        {
            var subset = new[] { "other staff", "staff" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong staff", Amount = 666 });

            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong staff", Amount = 666 },
                new TypeAndAmountSelection { Type = "other staff", Amount = 600 },
            });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Staff);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong staff", Amount = 666 },
                new TypeAndAmountSelection { Type = "other staff", Amount = 600 },
            });

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Major, ItemTypeConstants.Staff);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong staff", Amount = 666 },
                new TypeAndAmountSelection { Type = "staff", Amount = 42 },
                new TypeAndAmountSelection { Type = "other staff", Amount = 600 },
            });

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "staff")).Returns(baseNames);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "wrong staff")).Returns(666);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "staff")).Returns(9266);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "other staff")).Returns(90210);

            var staff = staffGenerator.GenerateFrom(power, subset);
            Assert.That(staff.Name, Is.EqualTo("staff"));
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(staff.Attributes.Count(), Is.EqualTo(2));
            Assert.That(staff.Magic.Bonus, Is.EqualTo(42));
            Assert.That(staff.Magic.Charges, Is.EqualTo(9266));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
            Assert.That(staff, Is.Not.InstanceOf<Weapon>());
        }

        [Test]
        public void GenerateDefaultStaffAsWeaponFromSubset()
        {
            var subset = new[] { "other staff", "staff" };
            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(new TypeAndAmountSelection { Type = "wrong staff", Amount = 666 });

            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(new[]
            {
                new TypeAndAmountSelection { Type = "wrong staff", Amount = 666 },
                new TypeAndAmountSelection { Type = "staff", Amount = 42 },
                new TypeAndAmountSelection { Type = "other staff", Amount = 600 },
            });

            var baseNames = new[] { "base name", "other base name", WeaponConstants.Quarterstaff };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "staff")).Returns(baseNames);

            var quarterstaff = itemVerifier.CreateRandomWeaponTemplate(WeaponConstants.Quarterstaff);
            mockMundaneWeaponGenerator.Setup(g => g.GenerateFrom(It.Is<Item>(i => i.Name == WeaponConstants.Quarterstaff), false)).Returns(quarterstaff);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "wrong staff")).Returns(666);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "staff")).Returns(9266);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "other staff")).Returns(90210);

            var staff = staffGenerator.GenerateFrom(power, subset);
            Assert.That(staff.Name, Is.EqualTo("staff"));
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Is.EquivalentTo(quarterstaff.Attributes.Union(new[] { AttributeConstants.Charged })));
            Assert.That(staff.Attributes, Is.All.Not.EqualTo(AttributeConstants.OneTimeUse));
            Assert.That(staff.Magic.Bonus, Is.EqualTo(42));
            Assert.That(staff.Magic.Charges, Is.EqualTo(9266));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
            Assert.That(staff, Is.InstanceOf<Weapon>());

            var weapon = staff as Weapon;
            Assert.That(weapon.Attributes, Is.SupersetOf(quarterstaff.Attributes));
            Assert.That(weapon.CriticalMultiplier, Is.EqualTo(quarterstaff.CriticalMultiplier));
            Assert.That(weapon.Damage, Is.EqualTo(quarterstaff.Damage));
            Assert.That(weapon.DamageType, Is.EqualTo(quarterstaff.DamageType));
            Assert.That(weapon.Size, Is.EqualTo(quarterstaff.Size));
            Assert.That(weapon.ThreatRange, Is.EqualTo(quarterstaff.ThreatRange));
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void MinorPowerFromSubsetThrowsError()
        {
            var subset = new[] { "staff", "other staff" };
            Assert.That(() => staffGenerator.GenerateFrom(PowerConstants.Minor, subset), Throws.ArgumentException.With.Message.EqualTo("Cannot generate minor staffs"));
        }
    }
}