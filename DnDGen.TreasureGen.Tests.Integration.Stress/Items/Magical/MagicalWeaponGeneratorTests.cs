using DnDGen.TreasureGen.Items;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class MagicalWeaponGeneratorTests : MagicalItemGeneratorStressTests
    {
        protected override bool allowMinor
        {
            get { return true; }
        }

        protected override string itemType
        {
            get { return ItemTypeConstants.Weapon; }
        }

        [Test]
        public void StressWeapon()
        {
            stressor.Stress(GenerateAndAssertItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item item)
        {
            Assert.That(item.Name, Is.Not.Empty);
            Assert.That(item.Attributes, Is.Not.Empty, item.Name);
            Assert.That(item.Attributes, Contains.Item(AttributeConstants.Simple)
                .Or.Contains(AttributeConstants.Martial)
                .Or.Contains(AttributeConstants.Exotic), item.Name);
            Assert.That(item.Attributes, Contains.Item(AttributeConstants.Light)
                .Or.Contains(AttributeConstants.OneHanded)
                .Or.Contains(AttributeConstants.TwoHanded)
                .Or.Contains(AttributeConstants.Ranged), item.Name);
            Assert.That(item.Attributes, Contains.Item(AttributeConstants.Melee).Or.Contains(AttributeConstants.Ranged), item.Name);
            Assert.That(item.Contents, Is.Not.Null, item.Name);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon), item.Name);
            Assert.That(item.Traits, Is.Not.Null, item.Name);
            Assert.That(item.Magic.Charges, Is.Not.Negative, item.Name);
            Assert.That(item.Magic.SpecialAbilities, Is.Not.Null, item.Name);
            Assert.That(item, Is.InstanceOf<Weapon>(), item.Name);

            var weapon = item as Weapon;
            Assert.That(weapon.BaseNames, Is.Not.Empty, item.Name);
            Assert.That(weapon.CriticalMultiplier, Is.Not.Empty, item.Name);
            Assert.That(weapon.Damage, Is.Not.Empty, item.Name);
            Assert.That(weapon.DamageType, Is.Not.Empty, item.Name);
            Assert.That(weapon.DamageType, Contains.Substring(AttributeConstants.DamageTypes.Bludgeoning)
                .Or.Contains(AttributeConstants.DamageTypes.Piercing)
                .Or.Contains(AttributeConstants.DamageTypes.Slashing), item.Name);
            Assert.That(weapon.Size, Is.Not.Empty, item.Name);
            Assert.That(weapon.ThreatRange, Is.Not.Empty, item.Name);
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return WeaponConstants.GetAllWeapons();
        }

        private void GenerateAndAssertThrownMeleeWeapon()
        {
            var thrownWeapon = GenerateItem(w => w.ItemType == itemType && w.Attributes.Contains(AttributeConstants.Thrown) && w.Attributes.Contains(AttributeConstants.Melee));

            AssertItem(thrownWeapon);
            Assert.That(thrownWeapon.Attributes, Contains.Item(AttributeConstants.Thrown), thrownWeapon.Name);
            Assert.That(thrownWeapon.Attributes, Contains.Item(AttributeConstants.Ranged), thrownWeapon.Name);
            Assert.That(thrownWeapon.Attributes, Contains.Item(AttributeConstants.Melee), thrownWeapon.Name);
            Assert.That(thrownWeapon.Quantity, Is.EqualTo(1), thrownWeapon.Name);
        }

        [Test]
        public void RequiredAmmunitionHappens()
        {
            var item = stressor.GenerateOrFail(GenerateItem, w => w is Weapon && !string.IsNullOrEmpty((w as Weapon).Ammunition));
            Assert.That(item, Is.InstanceOf<Weapon>(), item.Name);
            Assert.That(item.Attributes, Contains.Item(AttributeConstants.Ranged), item.Name);

            var weapon = item as Weapon;
            Assert.That(weapon.Ammunition, Is.Not.Empty, weapon.Name);
        }

        [Test]
        public void StressCustomWeapon()
        {
            stressor.Stress(GenerateAndAssertCustomItem);
        }

        [Test]
        public void StressWeaponFromSubset()
        {
            stressor.Stress(GenerateAndAssertItemFromSubset);
        }

        [Test]
        //[Ignore("Shuriken does not always appear within the time limit.  Mundane weapon tests verify this quantity")]
        public void BUG_ShurikenWithQuantityGreaterThan20Happens()
        {
            var shuriken = stressor.GenerateOrFail(GenerateShuriken, w => w.NameMatches(WeaponConstants.Shuriken) && w.Quantity > 20);
            AssertItem(shuriken);
            Assert.That(shuriken.NameMatches(WeaponConstants.Shuriken), Is.True);
            Assert.That(shuriken.Attributes, Contains.Item(AttributeConstants.Thrown), shuriken.Name);
            Assert.That(shuriken.Attributes, Contains.Item(AttributeConstants.Ranged), shuriken.Name);
            Assert.That(shuriken.Attributes, Contains.Item(AttributeConstants.Ammunition), shuriken.Name);
            Assert.That(shuriken.Attributes, Is.All.Not.EqualTo(AttributeConstants.Melee), shuriken.Name);
            Assert.That(shuriken.Quantity, Is.InRange(21, 50), shuriken.Name);
        }

        private Item GenerateShuriken()
        {
            var subset = new[] { WeaponConstants.Shuriken };
            var power = GetNewPower();
            var shuriken = magicalItemGenerator.GenerateFrom(power, subset);

            return shuriken;
        }
    }
}