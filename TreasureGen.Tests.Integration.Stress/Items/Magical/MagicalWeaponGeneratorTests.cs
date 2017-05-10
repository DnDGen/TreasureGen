using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
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
            Stress(StressItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item item)
        {
            Assert.That(item.Name, Is.Not.Empty);
            Assert.That(item.Attributes, Contains.Item(AttributeConstants.Common).Or.Contains(AttributeConstants.Uncommon).Or.Contains(AttributeConstants.Specific));
            Assert.That(item.Attributes, Contains.Item(AttributeConstants.Melee).Or.Contains(AttributeConstants.Ranged));
            Assert.That(item.Contents, Is.Not.Null);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(item.Traits, Is.Not.Null);
            Assert.That(item.Magic.Charges, Is.Not.Negative);
            Assert.That(item.Magic.SpecialAbilities, Is.Not.Null);
            Assert.That(item, Is.InstanceOf<Weapon>());

            var weapon = item as Weapon;
            Assert.That(weapon.BaseNames, Is.Not.Empty);
            Assert.That(weapon.CriticalMultiplier, Is.Not.Empty);
            Assert.That(weapon.Damage, Is.Not.Empty);
            Assert.That(weapon.DamageType, Is.Not.Empty);
            Assert.That(weapon.Size, Is.Not.Empty);
            Assert.That(weapon.ThreatRange, Is.Not.Empty);
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return WeaponConstants.GetAllWeapons();
        }

        [Test]
        public void BUG_AmmunitionWithQuantityGreaterThan1Happens()
        {
            var ammunition = GenerateOrFail(GenerateItem, w => w.ItemType == itemType && w.Attributes.Contains(AttributeConstants.Ammunition) && w.Quantity > 1);
            AssertItem(ammunition);
            Assert.That(ammunition.Attributes, Contains.Item(AttributeConstants.Ammunition), ammunition.Name);
            Assert.That(ammunition.Quantity, Is.InRange(2, 50), ammunition.Name);
        }

        [Test]
        public void BUG_ThrownWeaponWithQuantityGreaterThan1Happens()
        {
            var thrownWeapon = GenerateOrFail(GenerateItem, w => w.ItemType == itemType && w.Attributes.Contains(AttributeConstants.Thrown) && !w.Attributes.Contains(AttributeConstants.Melee) && w.Quantity > 1);
            AssertItem(thrownWeapon);
            Assert.That(thrownWeapon.Attributes, Contains.Item(AttributeConstants.Thrown), thrownWeapon.Name);
            Assert.That(thrownWeapon.Attributes, Contains.Item(AttributeConstants.Ranged), thrownWeapon.Name);
            Assert.That(thrownWeapon.Attributes, Is.All.Not.EqualTo(AttributeConstants.Melee), thrownWeapon.Name);

            var topRange = thrownWeapon.NameMatches(WeaponConstants.Shuriken) ? 50 : 20;
            Assert.That(thrownWeapon.Quantity, Is.InRange(2, topRange), thrownWeapon.Name);
        }

        [Test]
        public void BUG_ShurikenHappens()
        {
            var shuriken = GenerateOrFail(GenerateItem, w => w.NameMatches(WeaponConstants.Shuriken));
            AssertItem(shuriken);
            Assert.That(shuriken.NameMatches(WeaponConstants.Shuriken), Is.True);
            Assert.That(shuriken.Attributes, Contains.Item(AttributeConstants.Thrown), shuriken.Name);
            Assert.That(shuriken.Attributes, Contains.Item(AttributeConstants.Ranged), shuriken.Name);
            Assert.That(shuriken.Attributes, Contains.Item(AttributeConstants.Ammunition), shuriken.Name);
            Assert.That(shuriken.Attributes, Is.All.Not.EqualTo(AttributeConstants.Melee), shuriken.Name);
            Assert.That(shuriken.Quantity, Is.InRange(1, 50), shuriken.Name);
        }

        [Test]
        public void BUG_ShurikenWithQuantityGreaterThan1Happens()
        {
            var shuriken = GenerateOrFail(GenerateItem, w => w.NameMatches(WeaponConstants.Shuriken) && w.Quantity > 1);
            AssertItem(shuriken);
            Assert.That(shuriken.NameMatches(WeaponConstants.Shuriken), Is.True);
            Assert.That(shuriken.Attributes, Contains.Item(AttributeConstants.Thrown), shuriken.Name);
            Assert.That(shuriken.Attributes, Contains.Item(AttributeConstants.Ranged), shuriken.Name);
            Assert.That(shuriken.Attributes, Contains.Item(AttributeConstants.Ammunition), shuriken.Name);
            Assert.That(shuriken.Attributes, Is.All.Not.EqualTo(AttributeConstants.Melee), shuriken.Name);
            Assert.That(shuriken.Quantity, Is.InRange(2, 50), shuriken.Name);
        }

        [Test]
        public void RequiredAmmunitionHappens()
        {
            var item = GenerateOrFail(GenerateItem, w => w is Weapon && !string.IsNullOrEmpty((w as Weapon).Ammunition));
            Assert.That(item, Is.InstanceOf<Weapon>(), item.Name);
            Assert.That(item.Attributes, Contains.Item(AttributeConstants.Ranged), item.Name);

            var weapon = item as Weapon;
            Assert.That(weapon.Ammunition, Is.Not.Empty, weapon.Name);
        }

        [Test]
        public void StressCustomWeapon()
        {
            Stress(StressCustomItem);
        }

        [Test]
        public void StressWeaponFromSubset()
        {
            Stress(StressItemFromSubset);
        }

        [Test]
        public void BUG_ShurikenFromSubsetHappens()
        {
            var shuriken = GenerateOrFail(GenerateShuriken, w => w.NameMatches(WeaponConstants.Shuriken));
            AssertItem(shuriken);
            Assert.That(shuriken.NameMatches(WeaponConstants.Shuriken), Is.True);
            Assert.That(shuriken.Attributes, Contains.Item(AttributeConstants.Thrown), shuriken.Name);
            Assert.That(shuriken.Attributes, Contains.Item(AttributeConstants.Ranged), shuriken.Name);
            Assert.That(shuriken.Attributes, Contains.Item(AttributeConstants.Ammunition), shuriken.Name);
            Assert.That(shuriken.Attributes, Is.All.Not.EqualTo(AttributeConstants.Melee), shuriken.Name);
            Assert.That(shuriken.Quantity, Is.InRange(1, 50), shuriken.Name);
        }

        [Test]
        public void BUG_ShurikenFromSubsetWithQuantityGreaterThan1Happens()
        {
            var shuriken = GenerateOrFail(GenerateShuriken, w => w.NameMatches(WeaponConstants.Shuriken) && w.Quantity > 1);
            AssertItem(shuriken);
            Assert.That(shuriken.NameMatches(WeaponConstants.Shuriken), Is.True);
            Assert.That(shuriken.Attributes, Contains.Item(AttributeConstants.Thrown), shuriken.Name);
            Assert.That(shuriken.Attributes, Contains.Item(AttributeConstants.Ranged), shuriken.Name);
            Assert.That(shuriken.Attributes, Contains.Item(AttributeConstants.Ammunition), shuriken.Name);
            Assert.That(shuriken.Attributes, Is.All.Not.EqualTo(AttributeConstants.Melee), shuriken.Name);
            Assert.That(shuriken.Quantity, Is.InRange(2, 50), shuriken.Name);
        }

        private Item GenerateShuriken()
        {
            var subset = new[] { WeaponConstants.Shuriken };
            var power = GetNewPower();
            var shuriken = magicalItemGenerator.GenerateFromSubset(power, subset);

            return shuriken;
        }
    }
}