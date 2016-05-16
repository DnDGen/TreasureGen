using Ninject;
using NUnit.Framework;
using System;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class MagicalWeaponGeneratorTests : MagicalItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Weapon)]
        public MagicalItemGenerator MagicalWeaponGenerator { get; set; }

        [TestCase("Magical weapon generator")]
        public override void Stress(string thingToStress)
        {
            Stress();
        }

        protected override string itemType
        {
            get { return ItemTypeConstants.Weapon; }
        }

        protected override void MakeAssertionsAgainst(Item weapon)
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

        protected override Item GenerateItem()
        {
            var power = GetNewPower();
            return MagicalWeaponGenerator.GenerateAtPower(power);
        }

        [Test]
        public void SpecificWeaponHappens()
        {
            GenerateOrFail(w => w.Attributes.Contains(AttributeConstants.Specific) && w.Magic.Curse != CurseConstants.SpecificCursedItem);
        }

        [Test]
        public void UndecoratedSpecificWeaponHappens()
        {
            GenerateOrFail(w => w.Attributes.Contains(AttributeConstants.Specific) && w.Magic.Curse != CurseConstants.SpecificCursedItem && w.Magic.Intelligence.Ego == 0);
        }

        [Test]
        public void IntelligentSpecificWeaponHappens()
        {
            GenerateOrFail(w => w.Attributes.Contains(AttributeConstants.Specific) && w.Magic.Curse != CurseConstants.SpecificCursedItem && w.Magic.Intelligence.Ego > 0);
        }

        [Test]
        public void CursedSpecificWeaponHappens()
        {
            GenerateOrFail(w => w.Attributes.Contains(AttributeConstants.Specific) && w.Magic.Curse != CurseConstants.SpecificCursedItem && w.Magic.Curse != String.Empty);
        }

        [Test]
        public void SpecificWeaponDoesNotHappen()
        {
            GenerateOrFail(w => w.Attributes.Contains(AttributeConstants.Specific) == false);
        }

        [Test]
        public void AmmunitionHappens()
        {
            var ammunition = GenerateOrFail(w => w.Attributes.Contains(AttributeConstants.Ammunition));
            Assert.That(ammunition.Quantity, Is.InRange(1, 50));
        }

        [Test]
        public void AmmunitionWithQuantityGreaterThan1Happens()
        {
            var ammunition = GenerateOrFail(w => w.Attributes.Contains(AttributeConstants.Ammunition) && w.Quantity > 1);
            Assert.That(ammunition.Quantity, Is.InRange(2, 50));
        }

        [Test]
        public void AmmunitionDoesNotHappen()
        {
            var weapon = GenerateOrFail(w => w.Attributes.Contains(AttributeConstants.Ammunition) == false);
            Assert.That(weapon.Attributes, Is.All.Not.EqualTo(AttributeConstants.Ammunition), weapon.Name);
        }

        [Test]
        public void MagicalWeaponHappens()
        {
            GenerateOrFail(w => w.IsMagical);
        }

        [Test]
        public void MundaneWeaponHappens()
        {
            GenerateOrFail(w => w.IsMagical == false);
        }

        [Test]
        public void SpecialAbilitiesHappen()
        {
            GenerateOrFail(w => w.Magic.SpecialAbilities.Any());
        }

        [Test]
        public void SpecialAbilitiesDoNotHappen()
        {
            GenerateOrFail(w => w.IsMagical && w.Magic.SpecialAbilities.Any() == false);
        }

        [Test]
        public void ContentsHappen()
        {
            GenerateOrFail(w => w.Contents.Any());
        }

        [Test]
        public void ContentsDoNotHappen()
        {
            GenerateOrFail(w => w.Contents.Any() == false);
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
            AssertNoDecorationsHappen();
        }

        [Test]
        public override void SpecificCursedItemsAreNotDecorated()
        {
            AssertSpecificCursedItemsAreNotDecorated();
        }

        [Test]
        public override void SpecificCursedItemsHaveTraits()
        {
            AssertSpecificCursedItemsHaveTraits();
        }

        [Test]
        public override void SpecificCursedItemsDoNotHaveSpecialMaterials()
        {
            AssertSpecificCursedItemsDoNotHaveSpecialMaterials();
        }
    }
}