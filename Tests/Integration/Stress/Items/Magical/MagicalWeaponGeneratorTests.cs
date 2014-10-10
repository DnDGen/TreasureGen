using System;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class MagicalWeaponGeneratorTests : MagicalItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Weapon)]
        public IMagicalItemGenerator MagicalWeaponGenerator { get; set; }

        [TestCase("Magical weapon generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override String itemType
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
            Item weapon;

            do weapon = GenerateItem();
            while (TestShouldKeepRunning() && (!weapon.Attributes.Contains(AttributeConstants.Specific) || weapon.Magic.Curse == CurseConstants.SpecificCursedItem));

            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Specific));
            AssertIterations();
        }

        [Test]
        public void UndecoratedSpecificWeaponHappens()
        {
            Item weapon;

            do weapon = GenerateItem();
            while (TestShouldKeepRunning() && (!weapon.Attributes.Contains(AttributeConstants.Specific) || weapon.Magic.Intelligence.Ego > 0 || !String.IsNullOrEmpty(weapon.Magic.Curse)));

            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Specific));
            Assert.That(weapon.Magic.Curse, Is.Empty);
            Assert.That(weapon.Magic.Intelligence.Ego, Is.EqualTo(0));
            AssertIterations();
        }

        [Test]
        public void IntelligentSpecificWeaponHappens()
        {
            Item weapon;

            do weapon = GenerateItem();
            while (TestShouldKeepRunning() && (!weapon.Attributes.Contains(AttributeConstants.Specific) || weapon.Magic.Intelligence.Ego == 0 || weapon.Magic.Curse == CurseConstants.SpecificCursedItem));

            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Specific));
            Assert.That(weapon.Magic.Intelligence.Ego, Is.Positive);
            AssertIterations();
        }

        [Test]
        public void CursedSpecificWeaponHappens()
        {
            Item weapon;

            do weapon = GenerateItem();
            while (TestShouldKeepRunning() && (!weapon.Attributes.Contains(AttributeConstants.Specific) || String.IsNullOrEmpty(weapon.Magic.Curse) || weapon.Magic.Curse == CurseConstants.SpecificCursedItem));

            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Specific));
            Assert.That(weapon.Magic.Curse, Is.Not.Empty);
            AssertIterations();
        }

        [Test]
        public void SpecificWeaponDoesNotHappen()
        {
            Item weapon;

            do weapon = GenerateItem();
            while (TestShouldKeepRunning() && weapon.Attributes.Contains(AttributeConstants.Specific));

            Assert.That(weapon.Attributes, Is.Not.Contains(AttributeConstants.Specific));
            AssertIterations();
        }

        [Test]
        public void AmmunitionHappens()
        {
            Item weapon;

            do weapon = GenerateItem();
            while (TestShouldKeepRunning() && !weapon.Attributes.Contains(AttributeConstants.Ammunition));

            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Ammunition));
            Assert.That(weapon.Quantity, Is.InRange<Int32>(1, 50));
            AssertIterations();
        }

        [Test]
        public void MultipleAmmunitionHappens()
        {
            Item weapon;

            do weapon = GenerateItem();
            while (TestShouldKeepRunning() && weapon.Quantity == 1);

            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Ammunition));
            Assert.That(weapon.Quantity, Is.InRange<Int32>(2, 50));
            AssertIterations();
        }

        [Test]
        public void AmmunitionDoesNotHappen()
        {
            Item weapon;

            do weapon = GenerateItem();
            while (TestShouldKeepRunning() && weapon.Attributes.Contains(AttributeConstants.Ammunition));

            Assert.That(weapon.Attributes, Is.Not.Contains(AttributeConstants.Ammunition));
            Assert.That(weapon.Quantity, Is.EqualTo(1));
            AssertIterations();
        }

        [Test]
        public void MagicalWeaponHappens()
        {
            Item weapon;

            do weapon = GenerateItem();
            while (TestShouldKeepRunning() && (weapon.IsMagical == false || weapon.Attributes.Contains(AttributeConstants.Specific)));

            Assert.That(weapon.IsMagical, Is.True);
            Assert.That(weapon.Magic.Bonus, Is.Positive);
            AssertIterations();
        }

        [Test]
        public void MundaneWeaponHappens()
        {
            Item weapon;

            do weapon = GenerateItem();
            while (TestShouldKeepRunning() && weapon.IsMagical);

            Assert.That(weapon.IsMagical, Is.False);
            Assert.That(weapon.Magic.Bonus, Is.EqualTo(0));
            AssertIterations();
        }

        [Test]
        public void SpecialAbilitiesHappen()
        {
            Item weapon;

            do weapon = GenerateItem();
            while (TestShouldKeepRunning() && !weapon.Magic.SpecialAbilities.Any());

            Assert.That(weapon.Magic.SpecialAbilities, Is.Not.Empty);
            AssertIterations();
        }

        [Test]
        public void SpecialAbilitiesDoNotHappen()
        {
            Item weapon;

            do weapon = GenerateItem();
            while (TestShouldKeepRunning() && weapon.Magic.SpecialAbilities.Any());

            Assert.That(weapon.Magic.SpecialAbilities, Is.Empty);
            AssertIterations();
        }

        [Test]
        public void ContentsHappen()
        {
            Item weapon;

            do weapon = GenerateItem();
            while (TestShouldKeepRunning() && !weapon.Contents.Any());

            Assert.That(weapon.Contents, Is.Not.Empty);
            AssertIterations();
        }

        [Test]
        public void ContentsDoNotHappen()
        {
            Item weapon;

            do weapon = GenerateItem();
            while (TestShouldKeepRunning() && weapon.Contents.Any());

            Assert.That(weapon.Contents, Is.Empty);
            AssertIterations();
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
        public override void SpecificCursedItemsAreIntelligent()
        {
            AssertSpecificCursedItemsAreIntelligent();
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