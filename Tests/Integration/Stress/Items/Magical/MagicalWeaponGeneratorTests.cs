using System;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class MagicalWeaponGeneratorTests : StressTests
    {
        [Inject, Named(ItemTypeConstants.Weapon)]
        public IMagicalItemGenerator MagicalWeaponGenerator { get; set; }

        [Test]
        public void StressedMagicalWeaponGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var power = GetNewPower(false);
            var weapon = MagicalWeaponGenerator.GenerateAtPower(power);

            if (weapon.ItemType == ItemTypeConstants.SpecificCursedItem)
                return;

            Assert.That(weapon.Name, Is.Not.Empty);
            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Common).Or.Contains(AttributeConstants.Uncommon).Or.Contains(AttributeConstants.Specific));
            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Melee).Or.Contains(AttributeConstants.Ranged));
            Assert.That(weapon.Contents, Is.Not.Null);
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));

            if (weapon.IsMagical && !weapon.Attributes.Contains(AttributeConstants.Specific))
                Assert.That(weapon.Magic.Bonus, Is.GreaterThan(0), weapon.Name);

            if (weapon.Attributes.Contains(AttributeConstants.Ammunition))
                Assert.That(weapon.Quantity, Is.InRange<Int32>(1, 50));
            else
                Assert.That(weapon.Quantity, Is.EqualTo(1));

            Assert.That(weapon.Traits, Is.Not.Null);
            Assert.That(weapon.Magic.Charges, Is.AtLeast(0));
            Assert.That(weapon.Magic.SpecialAbilities, Is.Not.Null);

            if (weapon.Attributes.Contains(AttributeConstants.Charged))
                Assert.That(weapon.Magic.Charges, Is.GreaterThan(0));
        }

        [Test]
        public void IntelligenceHappens()
        {
            Item weapon = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && weapon.Magic.Intelligence.Ego == 0)
            {
                var power = GetNewPower(false);
                weapon = MagicalWeaponGenerator.GenerateAtPower(power);
            }

            Assert.That(weapon.Magic.Intelligence.Ego, Is.GreaterThan(0));
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void CursesHappen()
        {
            Item weapon = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && (String.IsNullOrEmpty(weapon.Magic.Curse) || weapon.ItemType == ItemTypeConstants.SpecificCursedItem))
            {
                var power = GetNewPower(false);
                weapon = MagicalWeaponGenerator.GenerateAtPower(power);
            }

            Assert.That(weapon.ItemType, Is.Not.EqualTo(ItemTypeConstants.SpecificCursedItem));
            Assert.That(weapon.Magic.Curse, Is.Not.Empty);
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void SpecificCursesHappen()
        {
            Item weapon = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && weapon.ItemType != ItemTypeConstants.SpecificCursedItem)
            {
                var power = GetNewPower(false);
                weapon = MagicalWeaponGenerator.GenerateAtPower(power);
            }

            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.SpecificCursedItem));
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void TraitsHappen()
        {
            Item weapon = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && !weapon.Traits.Any())
            {
                var power = GetNewPower(false);
                weapon = MagicalWeaponGenerator.GenerateAtPower(power);
            }

            Assert.That(weapon.Traits, Is.Not.Empty);
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }
    }
}