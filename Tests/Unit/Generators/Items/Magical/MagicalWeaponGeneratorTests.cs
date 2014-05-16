using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalWeaponGeneratorTests
    {
        private IMagicalItemGenerator weaponGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private Mock<ISpecialAbilitiesGenerator> mockSpecialAbilitiesGenerator;
        private Mock<IMagicalItemTraitsGenerator> mockMagicItemTraitsGenerator;
        private Mock<ISpecificGearGenerator> mockSpecificGearGenerator;
        private Mock<IMundaneItemGenerator> mockAmmunitionGenerator;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private Mock<ISpellGenerator> mockSpellGenerator;
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            mockMagicItemTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            mockSpecificGearGenerator = new Mock<ISpecificGearGenerator>();
            mockAmmunitionGenerator = new Mock<IMundaneItemGenerator>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockSpellGenerator = new Mock<ISpellGenerator>();
            mockDice = new Mock<IDice>();
            weaponGenerator = new MagicalWeaponGenerator(mockAttributesSelector.Object, mockPercentileSelector.Object);

            mockPercentileSelector.Setup(s => s.SelectFrom("WeaponTypes")).Returns("weapon type");
            mockPercentileSelector.Setup(s => s.SelectFrom("weapon typeWeapons")).Returns("weapon name");
        }

        [Test]
        public void GenerateWeapon()
        {
            var weapon = weaponGenerator.GenerateAtPower("power");
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Quantity, Is.AtLeast(1));
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
        }

        [Test]
        public void GetBonusFromSelector()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom("powerWeapons")).Returns("9266");
            var weapon = weaponGenerator.GenerateAtPower("power");
            Assert.That(weapon.Magic.Bonus, Is.EqualTo(9266));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "type 1", "type 2" };
            mockAttributesSelector.Setup(p => p.SelectFrom("WeaponAttributes", "weapon name")).Returns(attributes);

            var weapon = weaponGenerator.GenerateAtPower("power");
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GetSpecificItemsFromGenerator()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom("powerWeapons")).Returns("SpecificWeapon");

            var specificWeapon = new Item();
            mockSpecificGearGenerator.Setup(g => g.GenerateFrom("power", "SpecificWeapon")).Returns(specificWeapon);

            var weapon = weaponGenerator.GenerateAtPower("power");
            Assert.That(weapon, Is.EqualTo(specificWeapon));
        }

        [Test]
        public void GetSpecialAbilitiesFromGenerator()
        {
            mockPercentileSelector.SetupSequence(p => p.SelectFrom("powerWeapons")).Returns("SpecialAbility").Returns("SpecialAbility").Returns("0");

            var abilities = new[] { new SpecialAbility() };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Weapon, It.IsAny<IEnumerable<String>>(), "power", It.IsAny<Int32>(),
                2)).Returns(abilities);

            var weapon = weaponGenerator.GenerateAtPower("power");
            Assert.That(weapon.Magic.SpecialAbilities, Is.EqualTo(abilities));
        }

        [Test]
        public void GetTraitsFromGenerator()
        {
            var traits = new[] { "trait 1", "trait 2" };
            mockMagicItemTraitsGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Weapon)).Returns(traits);

            var weapon = weaponGenerator.GenerateAtPower("power");
            foreach (var trait in traits)
                Assert.That(weapon.Traits, Contains.Item(trait));
        }

        [Test]
        public void GetAmmunition()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom("weapon typeWeapons")).Returns(AttributeConstants.Ammunition);

            var ammo = new Item();
            mockAmmunitionGenerator.Setup(g => g.Generate()).Returns(ammo);

            var weapon = weaponGenerator.GenerateAtPower("power");
            Assert.That(weapon, Is.EqualTo(ammo));
        }

        [Test]
        public void SpellStoringWeaponHasSpellIfSelectorSaysSo()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("SpellStoringContainsSpell")).Returns(true);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom("powerWeapons")).Returns("SpecialAbility").Returns("0");

            var abilities = new[] { new SpecialAbility { Name = SpecialAbilityConstants.SpellStoring } };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Weapon, It.IsAny<IEnumerable<String>>(), "power", It.IsAny<Int32>(),
                1)).Returns(abilities);

            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockDice.Setup(d => d.d4(1)).Returns(9266);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 9265)).Returns("spell");

            var weapon = weaponGenerator.GenerateAtPower("power");
            Assert.That(weapon.Contents, Contains.Item("spell"));
        }

        [Test]
        public void SpellStoringWeaponDoesNotHaveSpellIfSelectorSaysSo()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("SpellStoringContainsSpell")).Returns(false);
            mockPercentileSelector.SetupSequence(p => p.SelectFrom("powerWeapons")).Returns("SpecialAbility").Returns("0");

            var abilities = new[] { new SpecialAbility { Name = SpecialAbilityConstants.SpellStoring } };
            mockSpecialAbilitiesGenerator.Setup(p => p.GenerateFor(ItemTypeConstants.Weapon, It.IsAny<IEnumerable<String>>(), "power", It.IsAny<Int32>(),
                1)).Returns(abilities);

            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockDice.Setup(d => d.d4(1)).Returns(9266);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 9265)).Returns("spell");

            var weapon = weaponGenerator.GenerateAtPower("power");
            Assert.That(weapon.Contents, Is.Empty);
        }
    }
}