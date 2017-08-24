using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class MundaneWeaponGeneratorTests : MundaneItemGeneratorStressTests
    {
        [SetUp]
        public void Setup()
        {
            mundaneItemGenerator = GetNewInstanceOf<MundaneItemGenerator>(ItemTypeConstants.Weapon);
        }

        [Test]
        public void StressWeapon()
        {
            stressor.Stress(GenerateAndAssertItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item item)
        {
            Assert.That(item.Name, Is.Not.Empty);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(item.Quantity, Is.Positive);
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.Attributes, Contains.Item(AttributeConstants.Common)
                .Or.Contains(AttributeConstants.Uncommon));
            Assert.That(item.Attributes, Contains.Item(AttributeConstants.Melee)
                .Or.Contains(AttributeConstants.Ranged));

            var sizes = TraitConstants.Sizes.All();
            Assert.That(item.Traits.Intersect(sizes), Is.Empty);
            Assert.That(item, Is.InstanceOf<Weapon>());

            var weapon = item as Weapon;
            Assert.That(weapon.Size, Is.Not.Empty);
            Assert.That(sizes, Contains.Item(weapon.Size));
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return WeaponConstants.GetBaseNames();
        }

        [Test]
        public void BUG_AmmunitionWithQuantityGreaterThan1Happens()
        {
            var ammunition = stressor.GenerateOrFail(GenerateItem, w => w.ItemType == ItemTypeConstants.Weapon && w.Attributes.Contains(AttributeConstants.Ammunition) && w.Quantity > 1);
            AssertItem(ammunition);
            Assert.That(ammunition.Attributes, Contains.Item(AttributeConstants.Ammunition), ammunition.Name);
            Assert.That(ammunition.Quantity, Is.InRange(2, 50), ammunition.Name);
        }

        [Test]
        public void BUG_ThrownWeaponWithQuantityGreaterThan1Happens()
        {
            var thrownWeapon = stressor.GenerateOrFail(GenerateItem, w => w.ItemType == ItemTypeConstants.Weapon && w.Attributes.Contains(AttributeConstants.Thrown) && !w.Attributes.Contains(AttributeConstants.Melee) && w.Quantity > 1);
            AssertItem(thrownWeapon);
            Assert.That(thrownWeapon.Attributes, Contains.Item(AttributeConstants.Thrown), thrownWeapon.Name);
            Assert.That(thrownWeapon.Attributes, Contains.Item(AttributeConstants.Ranged), thrownWeapon.Name);
            Assert.That(thrownWeapon.Attributes, Is.All.Not.EqualTo(AttributeConstants.Melee), thrownWeapon.Name);

            var topRange = thrownWeapon.NameMatches(WeaponConstants.Shuriken) ? 50 : 20;
            Assert.That(thrownWeapon.Quantity, Is.InRange(2, topRange), thrownWeapon.Name);
        }

        [Test]
        [Ignore("Shurikens are rare enough that they do not always occur within the time limit.")]
        public void BUG_ShurikenWithQuantityGreaterThan20Happens()
        {
            var shuriken = stressor.GenerateOrFail(GenerateItem, w => w.NameMatches(WeaponConstants.Shuriken) && w.Quantity > 20);
            AssertItem(shuriken);
            Assert.That(shuriken.NameMatches(WeaponConstants.Shuriken), Is.True);
            Assert.That(shuriken.Attributes, Contains.Item(AttributeConstants.Thrown), shuriken.Name);
            Assert.That(shuriken.Attributes, Contains.Item(AttributeConstants.Ranged), shuriken.Name);
            Assert.That(shuriken.Attributes, Contains.Item(AttributeConstants.Ammunition), shuriken.Name);
            Assert.That(shuriken.Attributes, Is.All.Not.EqualTo(AttributeConstants.Melee), shuriken.Name);
            Assert.That(shuriken.Quantity, Is.InRange(21, 50), shuriken.Name);
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
        public void StressMundaneWeaponFromSubset()
        {
            stressor.Stress(GenerateAndAssertItemFromSubset);
        }

        [Test]
        public void BUG_ShurikenFromSubsetWithQuantityGreaterThan20Happens()
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
            var shuriken = mundaneItemGenerator.GenerateFrom(subset);

            return shuriken;
        }
    }
}