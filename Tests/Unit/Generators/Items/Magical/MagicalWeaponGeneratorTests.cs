using Moq;
using NUnit.Framework;
using RollGen;
using System;
using System.Collections.Generic;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Domain.Items.Magical;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Generators.Items.Mundane;
using TreasureGen.Selectors;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalWeaponGeneratorTests
    {
        private MagicalItemGenerator weaponGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private Mock<ISpecialAbilitiesGenerator> mockSpecialAbilitiesGenerator;
        private Mock<ISpecificGearGenerator> mockSpecificGearGenerator;
        private Mock<IAmmunitionGenerator> mockAmmunitionGenerator;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private Mock<ISpellGenerator> mockSpellGenerator;
        private string power;
        private Mock<Dice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            mockSpecificGearGenerator = new Mock<ISpecificGearGenerator>();
            mockAmmunitionGenerator = new Mock<IAmmunitionGenerator>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockSpellGenerator = new Mock<ISpellGenerator>();
            mockDice = new Mock<Dice>();
            weaponGenerator = new MagicalWeaponGenerator(mockAttributesSelector.Object, mockPercentileSelector.Object, mockAmmunitionGenerator.Object, mockSpecialAbilitiesGenerator.Object, mockSpecificGearGenerator.Object, mockBooleanPercentileSelector.Object, mockSpellGenerator.Object, mockDice.Object);

            power = "power";
            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.WeaponTypes)).Returns("weapon type");
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("weapon name");
        }

        [Test]
        public void GenerateWeapon()
        {
            var weapon = weaponGenerator.GenerateAtPower(power);
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Quantity, Is.AtLeast(1));
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
        }

        [Test]
        public void GetBonusFromSelector()
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("9266");

            var weapon = weaponGenerator.GenerateAtPower(power);
            Assert.That(weapon.Magic.Bonus, Is.EqualTo(9266));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "type 1", "type 2" };
            var tableName = String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockAttributesSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            var weapon = weaponGenerator.GenerateAtPower(power);
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GetSpecificItemsFromGenerator()
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(ItemTypeConstants.Weapon);

            var specificWeapon = new Item();
            mockSpecificGearGenerator.Setup(g => g.GenerateFrom(power, ItemTypeConstants.Weapon)).Returns(specificWeapon);

            var weapon = weaponGenerator.GenerateAtPower(power);
            Assert.That(weapon, Is.EqualTo(specificWeapon));
        }

        [Test]
        public void GetSpecialAbilitiesFromGenerator()
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("SpecialAbility").Returns("9266");

            var attributes = new[] { "type 1", "type 2" };
            tableName = String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            mockAttributesSelector.Setup(p => p.SelectFrom(tableName, "weapon name")).Returns(attributes);

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Weapon, attributes, power, 9266, 2)).Returns(abilities);

            var weapon = weaponGenerator.GenerateAtPower(power);
            Assert.That(weapon.Magic.SpecialAbilities, Is.EqualTo(abilities));
        }

        [Test]
        public void GetAmmunition()
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, "weapon type");
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(AttributeConstants.Ammunition);

            var ammo = new Item();
            mockAmmunitionGenerator.Setup(g => g.Generate()).Returns(ammo);

            var weapon = weaponGenerator.GenerateAtPower(power);
            Assert.That(weapon, Is.EqualTo(ammo));
        }

        [Test]
        public void SpellStoringWeaponHasSpellIfSelectorSaysSo()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.SpellStoringContainsSpell)).Returns(true);
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("0");

            var abilities = new[] { new SpecialAbility { Name = SpecialAbilityConstants.SpellStoring } };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Weapon, It.IsAny<IEnumerable<String>>(), power, It.IsAny<Int32>(), 1)).Returns(abilities);

            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Minor)).Returns(9266);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 9266)).Returns("spell");

            var weapon = weaponGenerator.GenerateAtPower(power);
            Assert.That(weapon.Contents, Contains.Item("spell"));
        }

        [Test]
        public void SpellStoringWeaponDoesNotHaveSpellIfSelectorSaysSo()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Percentiles.Set.SpellStoringContainsSpell)).Returns(false);
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom(tableName)).Returns("SpecialAbility").Returns("0");

            var abilities = new[] { new SpecialAbility { Name = SpecialAbilityConstants.SpellStoring } };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Weapon, It.IsAny<IEnumerable<String>>(), power, It.IsAny<Int32>(), 1)).Returns(abilities);

            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Minor)).Returns(9266);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 9266)).Returns("spell");

            var weapon = weaponGenerator.GenerateAtPower(power);
            Assert.That(weapon.Contents, Is.Empty);
        }

        [Test]
        public void ThrownWeaponReceivesQuantity()
        {
            mockAttributesSelector.Setup(
                s => s.SelectFrom(TableNameConstants.Attributes.Set.AmmunitionAttributes, AttributeConstants.Thrown))
                .Returns(new[] { "other weapon", "weapon name" });
            mockDice.Setup(d => d.Roll(1).d20()).Returns(9266);

            var weapon = weaponGenerator.GenerateAtPower(power);
            Assert.That(weapon.Quantity, Is.EqualTo(9266));
        }
    }
}