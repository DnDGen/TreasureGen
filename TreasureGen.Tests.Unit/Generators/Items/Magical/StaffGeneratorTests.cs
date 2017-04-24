using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using TreasureGen.Domain.Generators.Items;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class StaffGeneratorTests
    {
        private MagicalItemGenerator staffGenerator;
        private Mock<IChargesGenerator> mockChargesGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private string power;
        private ItemVerifier itemVerifier;
        private Mock<ISpecialAbilitiesGenerator> mockSpecialAbilitiesGenerator;
        private Generator generator;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            generator = new ConfigurableIterativeGenerator(5);
            staffGenerator = new StaffGenerator(mockPercentileSelector.Object, mockChargesGenerator.Object, mockCollectionsSelector.Object, mockSpecialAbilitiesGenerator.Object, generator);
            power = "power";
            itemVerifier = new ItemVerifier();
        }

        [Test]
        public void GenerateStaff()
        {
            var staff = staffGenerator.GenerateAtPower(power);
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(staff.Attributes.Count(), Is.EqualTo(2));
            Assert.That(staff.Magic.Bonus, Is.EqualTo(0));
        }

        [Test]
        public void CannotGenerateMinorStaves()
        {
            Assert.That(() => staffGenerator.GenerateAtPower(PowerConstants.Minor), Throws.ArgumentException.With.Message.EqualTo("Cannot generate minor staves"));
        }

        [Test]
        public void GetKindOfStaffFromSelector()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("staffiness");

            var staff = staffGenerator.GenerateAtPower(power);
            Assert.That(staff.Name, Is.EqualTo("staffiness"));
        }

        [Test]
        public void GetBaseNames()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("staffiness");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "staffiness")).Returns(baseNames);

            var staff = staffGenerator.GenerateAtPower(power);
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
        }

        [Test]
        public void GetChargesFromGenerator()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("staffiness");
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "staffiness")).Returns(9266);

            var staff = staffGenerator.GenerateAtPower(power);
            Assert.That(staff.Magic.Charges, Is.EqualTo(9266));
        }

        [Test]
        public void StaffOfPowerHasBonusOf2()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(StaffConstants.Power);

            var staff = staffGenerator.GenerateAtPower(power);
            Assert.That(staff.Magic.Bonus, Is.EqualTo(2));
        }

        [Test]
        public void StaffOfPowerHasQuarterstaffAttributes()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(StaffConstants.Power);

            var attributes = new[] { "attribute 1", "attribute 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, WeaponConstants.Quarterstaff)).Returns(attributes);

            var staff = staffGenerator.GenerateAtPower(power);
            Assert.That(staff.Attributes, Is.EquivalentTo(attributes.Union(new[] { AttributeConstants.Charged })));
            Assert.That(staff.Attributes, Is.All.Not.EqualTo(AttributeConstants.OneTimeUse));
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

            var staff = staffGenerator.Generate(template);
            itemVerifier.AssertMagicalItemFromTemplate(staff, template);
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(staff.Attributes.Count(), Is.EqualTo(2));
            Assert.That(staff.Quantity, Is.EqualTo(1));
            Assert.That(staff.BaseNames, Is.EquivalentTo(baseNames));
        }

        [Test]
        public void GenerateCustomStaffOfPower()
        {
            var name = StaffConstants.Power;
            var template = itemVerifier.CreateRandomTemplate(name);
            var specialAbilityNames = template.Magic.SpecialAbilities.Select(a => a.Name);

            var abilities = new[]
            {
                new SpecialAbility { Name = specialAbilityNames.First() },
                new SpecialAbility { Name = specialAbilityNames.Last() }
            };

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(template.Magic.SpecialAbilities)).Returns(abilities);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, WeaponConstants.Quarterstaff)).Returns(attributes);

            //INFO: Hard-coding in quarterstaff here since a Staff of Power is one, and it makes the smart clone succeed
            var baseNames = new[] { "base name", "other base name", WeaponConstants.Quarterstaff };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var staff = staffGenerator.Generate(template);
            itemVerifier.AssertMagicalItemFromTemplate(staff, template);
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Is.EquivalentTo(attributes.Union(new[] { AttributeConstants.Charged })));
            Assert.That(staff.Attributes, Is.All.Not.EqualTo(AttributeConstants.OneTimeUse));
            Assert.That(staff.Quantity, Is.EqualTo(1));
            Assert.That(staff.Magic.SpecialAbilities, Is.EquivalentTo(abilities));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
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

            var staff = staffGenerator.Generate(template, true);
            itemVerifier.AssertMagicalItemFromTemplate(staff, template);
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(staff.Attributes.Count(), Is.EqualTo(2));
            Assert.That(staff.Quantity, Is.EqualTo(1));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
        }

        [Test]
        public void GenerateRandomCustomStaffOfPower()
        {
            var name = StaffConstants.Power;
            var template = itemVerifier.CreateRandomTemplate(name);
            var specialAbilityNames = template.Magic.SpecialAbilities.Select(a => a.Name);

            var abilities = new[]
            {
                new SpecialAbility { Name = specialAbilityNames.First() },
                new SpecialAbility { Name = specialAbilityNames.Last() }
            };

            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(template.Magic.SpecialAbilities)).Returns(abilities);

            var attributes = new[] { "attribute 1", "attribute 2" };
            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, WeaponConstants.Quarterstaff)).Returns(attributes);

            //INFO: Hard-coding in quarterstaff here since a Staff of Power is one, and it makes the smart clone succeed
            var baseNames = new[] { "base name", "other base name", WeaponConstants.Quarterstaff };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name)).Returns(baseNames);

            var staff = staffGenerator.Generate(template, true);
            itemVerifier.AssertMagicalItemFromTemplate(staff, template);
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Is.EquivalentTo(attributes.Union(new[] { AttributeConstants.Charged })));
            Assert.That(staff.Attributes, Is.All.Not.EqualTo(AttributeConstants.OneTimeUse));
            Assert.That(staff.Quantity, Is.EqualTo(1));
            Assert.That(staff.Magic.SpecialAbilities, Is.EqualTo(abilities));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
        }

        [Test]
        public void GenerateFromSubset()
        {
            var subset = new[] { "other staff", "staff" };

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(tableName))
                .Returns("wrong staff")
                .Returns("staff")
                .Returns("other staff");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "staff")).Returns(baseNames);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "wrong staff")).Returns(666);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "staff")).Returns(9266);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "other staff")).Returns(90210);

            var staff = staffGenerator.GenerateFromSubset(power, subset);
            Assert.That(staff.Name, Is.EqualTo("staff"));
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(staff.Attributes.Count(), Is.EqualTo(2));
            Assert.That(staff.Magic.Bonus, Is.EqualTo(0));
            Assert.That(staff.Magic.Charges, Is.EqualTo(9266));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
        }

        [Test]
        public void GenerateStaffAsWeaponFromSubset()
        {
            var subset = new[] { "other staff", "base name" };

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(tableName))
                .Returns("wrong staff")
                .Returns("staff")
                .Returns("other staff");

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "staff")).Returns(baseNames);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "wrong staff")).Returns(666);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "staff")).Returns(9266);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "other staff")).Returns(90210);

            var staff = staffGenerator.GenerateFromSubset(power, subset);
            Assert.That(staff.Name, Is.EqualTo("staff"));
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(staff.Attributes.Count(), Is.EqualTo(2));
            Assert.That(staff.Magic.Bonus, Is.EqualTo(0));
            Assert.That(staff.Magic.Charges, Is.EqualTo(9266));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
        }

        [Test]
        public void GenerateStaffOfPowerFromSubset()
        {
            var subset = new[] { "other staff", StaffConstants.Power };

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(tableName))
                .Returns("wrong staff")
                .Returns(StaffConstants.Power)
                .Returns("other staff");

            //INFO: Hard-coding in quarterstaff here since a Staff of Power is one, and it makes the smart clone succeed
            var baseNames = new[] { "base name", "other base name", WeaponConstants.Quarterstaff };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, StaffConstants.Power)).Returns(baseNames);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "wrong staff")).Returns(666);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, StaffConstants.Power)).Returns(9266);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "other staff")).Returns(90210);

            var attributes = new[] { "attribute 1", "attribute 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, WeaponConstants.Quarterstaff)).Returns(attributes);

            var staff = staffGenerator.GenerateFromSubset(power, subset);
            Assert.That(staff.Name, Is.EqualTo(StaffConstants.Power));
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Is.EquivalentTo(attributes.Union(new[] { AttributeConstants.Charged })));
            Assert.That(staff.Attributes, Is.All.Not.EqualTo(AttributeConstants.OneTimeUse));
            Assert.That(staff.Magic.Bonus, Is.EqualTo(2));
            Assert.That(staff.Magic.Charges, Is.EqualTo(9266));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
        }

        [Test]
        public void GenerateDefaultFromSubset()
        {
            var subset = new[] { "other staff", "staff" };

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("wrong staff");

            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "staff")).Returns(baseNames);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "wrong staff")).Returns(666);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "staff")).Returns(9266);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "other staff")).Returns(90210);

            var staff = staffGenerator.GenerateFromSubset(power, subset);
            Assert.That(staff.Name, Is.EqualTo("staff"));
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(staff.Attributes.Count(), Is.EqualTo(2));
            Assert.That(staff.Magic.Bonus, Is.EqualTo(0));
            Assert.That(staff.Magic.Charges, Is.EqualTo(9266));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
        }

        [Test, Ignore("Since defaults take a subset and make it a name, matching to a base name won't work")]
        public void GenerateDefaultAsWeaponFromSubset()
        {
            var subset = new[] { "other staff", "base name" };

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("wrong staff");

            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            var baseNames = new[] { "base name", "other base name" };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, "staff")).Returns(baseNames);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "wrong staff")).Returns(666);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "staff")).Returns(9266);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "other staff")).Returns(90210);

            var staff = staffGenerator.GenerateFromSubset(power, subset);
            Assert.That(staff.Name, Is.EqualTo("staff"));
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(staff.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(staff.Attributes.Count(), Is.EqualTo(2));
            Assert.That(staff.Magic.Bonus, Is.EqualTo(0));
            Assert.That(staff.Magic.Charges, Is.EqualTo(9266));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
        }

        [Test]
        public void GenerateDefaultStaffOfPowerFromSubset()
        {
            var subset = new[] { "other staff", StaffConstants.Power };

            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Staff);
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(tableName)).Returns("wrong staff");

            mockCollectionsSelector.Setup(s => s.SelectRandomFrom(subset)).Returns(subset.Last());

            //INFO: Hard-coding in quarterstaff here since a Staff of Power is one, and it makes the smart clone succeed
            var baseNames = new[] { "base name", "other base name", WeaponConstants.Quarterstaff };
            mockCollectionsSelector.Setup(s => s.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, StaffConstants.Power)).Returns(baseNames);

            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "wrong staff")).Returns(666);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, StaffConstants.Power)).Returns(9266);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Staff, "other staff")).Returns(90210);

            var attributes = new[] { "attribute 1", "attribute 2" };
            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockCollectionsSelector.Setup(s => s.SelectFrom(tableName, WeaponConstants.Quarterstaff)).Returns(attributes);

            var staff = staffGenerator.GenerateFromSubset(power, subset);
            Assert.That(staff.Name, Is.EqualTo(StaffConstants.Power));
            Assert.That(staff.ItemType, Is.EqualTo(ItemTypeConstants.Staff));
            Assert.That(staff.Attributes, Is.EquivalentTo(attributes.Union(new[] { AttributeConstants.Charged })));
            Assert.That(staff.Attributes, Is.All.Not.EqualTo(AttributeConstants.OneTimeUse));
            Assert.That(staff.Magic.Bonus, Is.EqualTo(2));
            Assert.That(staff.Magic.Charges, Is.EqualTo(9266));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
        }

        [Test]
        public void MinorPowerFromSubsetThrowsError()
        {
            var subset = new[] { "staff", "other staff" };
            Assert.That(() => staffGenerator.GenerateFromSubset(PowerConstants.Minor, subset), Throws.ArgumentException.With.Message.EqualTo("Cannot generate minor staffs"));
        }
    }
}