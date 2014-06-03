using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class MagicalArmorGeneratorTests : StressTests
    {
        [Inject, Named(ItemTypeConstants.Armor)]
        public IMagicalItemGenerator MagicalArmorGenerator { get; set; }

        private IEnumerable<String> materials;

        [SetUp]
        public void Setup()
        {
            materials = TraitConstants.GetSpecialMaterials();
        }

        [Test]
        public void StressedMagicalArmorGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var power = GetNewPower(false);
            var armor = MagicalArmorGenerator.GenerateAtPower(power);

            if (armor.ItemType == ItemTypeConstants.SpecificCursedItem)
                return;

            Assert.That(armor.Name, Is.Not.Empty);
            Assert.That(armor.Traits, Is.Not.Null);
            Assert.That(armor.Attributes, Is.Not.Null);
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.Contents, Is.Not.Null);
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Magic.Charges, Is.EqualTo(0));
            Assert.That(armor.Magic.SpecialAbilities, Is.Not.Null);

            if (armor.IsMagical)
                Assert.That(armor.Magic.Bonus, Is.GreaterThan(0));
            else
                Assert.That(armor.Magic.Bonus, Is.EqualTo(0));
        }

        [Test]
        public void IntelligenceHappens()
        {
            var armor = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && armor.Magic.Intelligence.Ego == 0)
            {
                var power = GetNewPower(false);
                armor = MagicalArmorGenerator.GenerateAtPower(power);
            }

            Assert.That(armor.Magic.Intelligence.Ego, Is.GreaterThan(0));
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void CursesHappen()
        {
            var armor = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && (String.IsNullOrEmpty(armor.Magic.Curse) || armor.ItemType == ItemTypeConstants.SpecificCursedItem))
            {
                var power = GetNewPower(false);
                armor = MagicalArmorGenerator.GenerateAtPower(power);
            }

            Assert.That(armor.ItemType, Is.Not.EqualTo(ItemTypeConstants.SpecificCursedItem));
            Assert.That(armor.Magic.Curse, Is.Not.Empty);
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void SpecificCursesHappen()
        {
            var armor = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && armor.ItemType != ItemTypeConstants.SpecificCursedItem)
            {
                var power = GetNewPower(false);
                armor = MagicalArmorGenerator.GenerateAtPower(power);
            }

            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.SpecificCursedItem));
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void TraitsHappen()
        {
            var armor = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && !armor.Traits.Except(materials).Any())
            {
                var power = GetNewPower(false);
                armor = MagicalArmorGenerator.GenerateAtPower(power);
            }

            var traits = armor.Traits.Except(materials);
            Assert.That(traits, Is.Not.Empty);
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void SpecialMaterialsHappen()
        {
            var armor = new Item();

            do
            {
                var power = GetNewPower(false);
                armor = MagicalArmorGenerator.GenerateAtPower(power);
            } while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && !armor.Traits.Intersect(materials).Any());

            var weaponMaterials = armor.Traits.Intersect(materials);
            Assert.That(weaponMaterials, Is.Not.Empty);
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void NoDecorationsHappen()
        {
            var armor = new Item();

            do
            {
                var power = GetNewPower(false);
                armor = MagicalArmorGenerator.GenerateAtPower(power);
            } while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && armor.Traits.Any() && armor.Magic.Curse.Any() && armor.Magic.Intelligence.Ego > 0);

            Assert.That(armor.Traits, Is.Empty);
            Assert.That(armor.Magic.Curse, Is.Empty);
            Assert.That(armor.Magic.Intelligence.Ego, Is.EqualTo(0));
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }
    }
}