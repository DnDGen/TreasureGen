using System;
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

        [Test]
        public void StressedRodGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var power = Random.Next(2) == 0 ? PowerConstants.Medium : PowerConstants.Major;
            var rod = RodGenerator.GenerateAtPower(power);

            if (rod.ItemType == ItemTypeConstants.SpecificCursedItem)
                return;

            Assert.That(rod.Name, Is.StringStarting("Rod of "));
            Assert.That(rod.Attributes, Is.Not.Null);
            Assert.That(rod.Contents, Is.Empty);
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.Magic.Bonus, Is.EqualTo(0));
            Assert.That(rod.Magic.Charges, Is.AtLeast(0));
            Assert.That(rod.Magic.SpecialAbilities, Is.Empty);
            Assert.That(rod.Quantity, Is.EqualTo(1));
            Assert.That(rod.Traits, Is.Empty);

            if (rod.Attributes.Contains(AttributeConstants.Charged))
                Assert.That(rod.Magic.Charges, Is.GreaterThan(0));
        }

        [Test]
        public void IntelligenceHappens()
        {
            Item rod = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && rod.Magic.Intelligence.Ego == 0)
            {
                var power = Random.Next(2) == 0 ? PowerConstants.Medium : PowerConstants.Major;
                rod = RodGenerator.GenerateAtPower(power);
            }

            Assert.That(rod.Magic.Intelligence.Ego, Is.GreaterThan(0));
        }

        [Test]
        public void CursesHappen()
        {
            Item rod = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && (String.IsNullOrEmpty(rod.Magic.Curse) || rod.ItemType == ItemTypeConstants.SpecificCursedItem))
            {
                var power = Random.Next(2) == 0 ? PowerConstants.Medium : PowerConstants.Major;
                rod = RodGenerator.GenerateAtPower(power);
            }

            Assert.That(rod.Magic.Curse, Is.Not.Empty);
        }

        [Test]
        public void SpecificCursesHappen()
        {
            Item rod = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && rod.ItemType != ItemTypeConstants.SpecificCursedItem)
            {
                var power = Random.Next(2) == 0 ? PowerConstants.Medium : PowerConstants.Major;
                rod = RodGenerator.GenerateAtPower(power);
            }

            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.SpecificCursedItem));
        }

        [Test]
        public void TraitsHappen()
        {
            Item rod = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && !rod.Traits.Any())
            {
                var power = Random.Next(2) == 0 ? PowerConstants.Medium : PowerConstants.Major;
                rod = RodGenerator.GenerateAtPower(power);
            }

            Assert.That(rod.Traits, Is.Not.Empty);
        }
    }
}