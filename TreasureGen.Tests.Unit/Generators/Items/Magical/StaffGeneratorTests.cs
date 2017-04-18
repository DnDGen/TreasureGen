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
    public class StaffGeneratorTests
    {
        private MagicalItemGenerator staffGenerator;
        private Mock<IChargesGenerator> mockChargesGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<ICollectionsSelector> mockCollectionsSelector;
        private string power;
        private ItemVerifier itemVerifier;
        private Mock<ISpecialAbilitiesGenerator> mockSpecialAbilitiesGenerator;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            mockCollectionsSelector = new Mock<ICollectionsSelector>();
            mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            staffGenerator = new StaffGenerator(mockPercentileSelector.Object, mockChargesGenerator.Object, mockCollectionsSelector.Object, mockSpecialAbilitiesGenerator.Object);
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
            Assert.That(staff.Quantity, Is.EqualTo(1));
            Assert.That(staff.Magic.SpecialAbilities, Is.EqualTo(abilities));
            Assert.That(staff.BaseNames, Is.EqualTo(baseNames));
        }
    }
}