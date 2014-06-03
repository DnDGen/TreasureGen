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
    public class RodGeneratorTests : StressTests
    {
        [Inject, Named(ItemTypeConstants.Rod)]
        public IMagicalItemGenerator RodGenerator { get; set; }

        private IEnumerable<String> materials;

        [SetUp]
        public void Setup()
        {
            materials = TraitConstants.GetSpecialMaterials();
        }

        [Test]
        public void StressedRodGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var power = GetRodPower();
            var rod = RodGenerator.GenerateAtPower(power);

            if (rod.ItemType == ItemTypeConstants.SpecificCursedItem)
                return;

            Assert.That(rod.Name, Is.Not.Empty);
            Assert.That(rod.Attributes, Is.Not.Null);
            Assert.That(rod.Contents, Is.Not.Null);
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.Magic.Bonus, Is.EqualTo(0));
            Assert.That(rod.Magic.Charges, Is.AtLeast(0));
            Assert.That(rod.Magic.SpecialAbilities, Is.Empty);
            Assert.That(rod.Quantity, Is.EqualTo(1));
            Assert.That(rod.Traits, Is.Empty);

            if (rod.Attributes.Contains(AttributeConstants.Charged))
                Assert.That(rod.Magic.Charges, Is.GreaterThan(0));

            var rodMaterials = rod.Traits.Intersect(materials);
            Assert.That(rodMaterials, Is.Empty);
        }

        private String GetRodPower()
        {
            if (Random.Next(2) == 0)
                return PowerConstants.Medium;

            return PowerConstants.Major;
        }

        [Test]
        public void IntelligenceHappens()
        {
            var rod = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && rod.Magic.Intelligence.Ego == 0)
            {
                var power = GetRodPower();
                rod = RodGenerator.GenerateAtPower(power);
            }

            Assert.That(rod.Magic.Intelligence.Ego, Is.GreaterThan(0));
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void CursesHappen()
        {
            var rod = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && (String.IsNullOrEmpty(rod.Magic.Curse) || rod.ItemType == ItemTypeConstants.SpecificCursedItem))
            {
                var power = GetRodPower();
                rod = RodGenerator.GenerateAtPower(power);
            }

            Assert.That(rod.ItemType, Is.Not.EqualTo(ItemTypeConstants.SpecificCursedItem));
            Assert.That(rod.Magic.Curse, Is.Not.Empty);
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void SpecificCursesHappen()
        {
            var rod = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && rod.ItemType != ItemTypeConstants.SpecificCursedItem)
            {
                var power = GetRodPower();
                rod = RodGenerator.GenerateAtPower(power);
            }

            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.SpecificCursedItem));
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void TraitsHappen()
        {
            var rod = new Item();

            do
            {
                var power = GetNewPower(false);
                rod = RodGenerator.GenerateAtPower(power);
            } while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && !rod.Traits.Any());

            Assert.That(rod.Traits, Is.Not.Empty);
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void NoDecorationsHappen()
        {
            var rod = new Item();

            do
            {
                var power = GetNewPower(false);
                rod = RodGenerator.GenerateAtPower(power);
            } while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && rod.Traits.Any() && rod.Magic.Curse.Any() && rod.Magic.Intelligence.Ego > 0);

            Assert.That(rod.Traits, Is.Empty);
            Assert.That(rod.Magic.Curse, Is.Empty);
            Assert.That(rod.Magic.Intelligence.Ego, Is.EqualTo(0));
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }
    }
}