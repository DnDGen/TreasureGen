using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

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

        protected override void MakeSpecificAssertionsAgainst(Item weapon)
        {
            Assert.That(weapon.Name, Is.Not.Empty);
            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Common).Or.Contains(AttributeConstants.Uncommon).Or.Contains(AttributeConstants.Specific));
            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Melee).Or.Contains(AttributeConstants.Ranged));
            Assert.That(weapon.Contents, Is.Not.Null);
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Traits, Is.Not.Null);
            Assert.That(weapon.Magic.Charges, Is.Not.Negative);
            Assert.That(weapon.Magic.SpecialAbilities, Is.Not.Null);
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return WeaponConstants.GetAllWeapons();
        }

        [Test]
        public void StressCustomWeapon()
        {
            Stress(StressCustomItem);
        }

        [Test]
        public void StressRandomCustomWeapon()
        {
            Stress(StressRandomCustomItem);
        }

        [Test]
        public void SpecificWeaponHappens()
        {
            var weapon = GenerateOrFail(GenerateItem, w => w.ItemType == itemType && w.Attributes.Contains(AttributeConstants.Specific) && w.Magic.Curse != CurseConstants.SpecificCursedItem);
            AssertItem(weapon);
            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Specific));
            Assert.That(weapon.Magic.Curse, Is.Not.EqualTo(CurseConstants.SpecificCursedItem));
        }

        [Test]
        public void UndecoratedSpecificWeaponHappens()
        {
            var weapon = GenerateOrFail(GenerateItem, w => w.ItemType == itemType && w.Attributes.Contains(AttributeConstants.Specific) && w.Magic.Curse == string.Empty && w.Magic.Intelligence.Ego == 0);
            AssertItem(weapon);
            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Specific));
            Assert.That(weapon.Magic.Curse, Is.Empty);
            Assert.That(weapon.Magic.Intelligence.Ego, Is.EqualTo(0));
        }

        [Test]
        public void IntelligentSpecificWeaponHappens()
        {
            var weapon = GenerateOrFail(GenerateItem, w => w.ItemType == itemType && w.Attributes.Contains(AttributeConstants.Specific) && w.Magic.Curse != CurseConstants.SpecificCursedItem && w.Magic.Intelligence.Ego > 0);
            AssertItem(weapon);
            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Specific));
            Assert.That(weapon.Magic.Curse, Is.Not.EqualTo(CurseConstants.SpecificCursedItem));
            ItemVerifier.AssertIntelligence(weapon.Magic.Intelligence);
        }

        [Test]
        public void CursedSpecificWeaponHappens()
        {
            var weapon = GenerateOrFail(GenerateItem, w => w.ItemType == itemType && w.Attributes.Contains(AttributeConstants.Specific) && w.Magic.Curse != CurseConstants.SpecificCursedItem && w.Magic.Curse != string.Empty);
            AssertItem(weapon);
            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Specific));
            Assert.That(weapon.Magic.Curse, Is.Not.Empty);
            Assert.That(weapon.Magic.Curse, Is.Not.EqualTo(CurseConstants.SpecificCursedItem));
        }

        [Test]
        public void SpecificWeaponDoesNotHappen()
        {
            var weapon = GenerateOrFail(GenerateItem, w => w.ItemType == itemType && w.Attributes.Contains(AttributeConstants.Specific) == false);
            AssertItem(weapon);
            Assert.That(weapon.Attributes, Is.All.Not.EqualTo(AttributeConstants.Specific));
        }

        [Test]
        public void AmmunitionHappens()
        {
            var ammunition = GenerateOrFail(GenerateItem, w => w.ItemType == itemType && w.Attributes.Contains(AttributeConstants.Ammunition));
            AssertItem(ammunition);
            Assert.That(ammunition.Attributes, Contains.Item(AttributeConstants.Ammunition));
            Assert.That(ammunition.Quantity, Is.InRange(1, 50));
        }

        [Test]
        public void AmmunitionWithQuantityGreaterThan1Happens()
        {
            var ammunition = GenerateOrFail(GenerateItem, w => w.ItemType == itemType && w.Attributes.Contains(AttributeConstants.Ammunition) && w.Quantity > 1);
            AssertItem(ammunition);
            Assert.That(ammunition.Attributes, Contains.Item(AttributeConstants.Ammunition));
            Assert.That(ammunition.Quantity, Is.InRange(2, 50));
        }

        [Test]
        public void AmmunitionDoesNotHappen()
        {
            var weapon = GenerateOrFail(GenerateItem, w => w.ItemType == itemType && w.Attributes.Contains(AttributeConstants.Ammunition) == false);
            AssertItem(weapon);
            Assert.That(weapon.Attributes, Is.All.Not.EqualTo(AttributeConstants.Ammunition), weapon.Name);
        }

        [Test]
        public void MagicalWeaponHappens()
        {
            var weapon = GenerateOrFail(GenerateItem, w => w.ItemType == itemType && w.IsMagical);
            AssertItem(weapon);
            Assert.That(weapon.IsMagical, Is.True);
        }

        [Test]
        public void MundaneWeaponHappens()
        {
            var weapon = GenerateOrFail(GenerateItem, w => w.ItemType == itemType && w.IsMagical == false);
            AssertItem(weapon);
            Assert.That(weapon.IsMagical, Is.False);
        }

        [Test]
        public void SpecialAbilitiesHappen()
        {
            var weapon = GenerateOrFail(GenerateItem, w => w.ItemType == itemType && w.Magic.SpecialAbilities.Any());
            AssertItem(weapon);
            Assert.That(weapon.Magic.SpecialAbilities, Is.Not.Empty);
        }

        [Test]
        public void SpecialAbilitiesDoNotHappen()
        {
            var weapon = GenerateOrFail(GenerateItem, w => w.ItemType == itemType && w.IsMagical && w.Magic.SpecialAbilities.Any() == false);
            AssertItem(weapon);
            Assert.That(weapon.Magic.SpecialAbilities, Is.Empty);
        }

        [Test]
        public void ContentsHappen()
        {
            var weapon = GenerateOrFail(GenerateItem, w => w.ItemType == itemType && w.Contents.Any());
            AssertItem(weapon);
            Assert.That(weapon.Contents, Is.Not.Empty);
        }

        [Test]
        public void ContentsDoNotHappen()
        {
            var weapon = GenerateOrFail(GenerateItem, w => w.ItemType == itemType && w.Contents.Any() == false);
            AssertItem(weapon);
            Assert.That(weapon.Contents, Is.Empty);
        }

        [Test]
        public override void IntelligenceHappens()
        {
            base.IntelligenceHappens();
        }

        [Test]
        public override void TraitsHappen()
        {
            base.TraitsHappen();
        }

        [Test]
        public override void SpecialMaterialsHappen()
        {
            base.SpecialMaterialsHappen();
        }

        [Test]
        public override void CursesHappen()
        {
            AssertCursesHappen();
        }

        [Test]
        public override void SpecificCursesHappen()
        {
            AssertSpecificCursesHappen();
        }

        [Test]
        public override void NoDecorationsHappen()
        {
            //INFO: have to make our own method here, since all magic weapons are masterwork
            var item = GenerateOrFail(GenerateItem, i => i.ItemType == itemType && !i.Traits.Except(new[] { TraitConstants.Masterwork }).Any() && string.IsNullOrEmpty(i.Magic.Curse) && i.Magic.Intelligence.Ego == 0);
            AssertItem(item);
            Assert.That(item.Traits.Except(new[] { TraitConstants.Masterwork }), Is.Empty);
            Assert.That(item.Magic.Curse, Is.Empty);
            Assert.That(item.Magic.Intelligence.Ego, Is.EqualTo(0));
        }

        [Test]
        public override void SpecificCursedItemsWithTraitsHappen()
        {
            AssertSpecificCursedItemsWithTraitsHappen();
        }

        [Test]
        public override void SpecificCursedItemsWithIntelligenceHappen()
        {
            AssertSpecificCursedItemsWithIntelligenceHappen();
        }

        [Test]
        public override void SpecificCursedItemsWithNoDecorationHappen()
        {
            AssertSpecificCursedItemsWithNoDecorationHappen();
        }

        [Test]
        public override void StressSpecificCursedItems()
        {
            base.StressSpecificCursedItems();
        }

        [Test]
        public void StressWeaponFromSubset()
        {
            Stress(StressItemFromSubset);
        }
    }
}