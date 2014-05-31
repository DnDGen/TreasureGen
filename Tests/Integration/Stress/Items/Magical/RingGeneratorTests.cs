using System;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class RingGeneratorTests : StressTests
    {
        [Inject, Named(ItemTypeConstants.Ring)]
        public IMagicalItemGenerator RingGenerator { get; set; }

        [Test]
        public void StressedRingGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var power = GetNewPower(false);
            var ring = RingGenerator.GenerateAtPower(power);

            if (ring.ItemType == ItemTypeConstants.SpecificCursedItem)
                return;

            Assert.That(ring.Name, Is.StringStarting("Ring of "));
            Assert.That(ring.Traits, Is.Not.Null);
            Assert.That(ring.Attributes, Is.Not.Null);
            Assert.That(ring.Quantity, Is.EqualTo(1));
            Assert.That(ring.IsMagical, Is.True);
            Assert.That(ring.Contents, Is.Not.Null);
            Assert.That(ring.ItemType, Is.EqualTo(ItemTypeConstants.Ring));
            Assert.That(ring.Magic.Bonus, Is.AtLeast(0));
            Assert.That(ring.Magic.Charges, Is.AtLeast(0));
            Assert.That(ring.Magic.SpecialAbilities, Is.Empty);

            if (ring.Attributes.Contains(AttributeConstants.Charged))
                Assert.That(ring.Magic.Charges, Is.GreaterThan(0));
        }

        [Test]
        public void IntelligenceHappens()
        {
            Item ring = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && ring.Magic.Intelligence.Ego == 0)
            {
                var power = GetNewPower(false);
                ring = RingGenerator.GenerateAtPower(power);
            }

            Assert.That(ring.Magic.Intelligence.Ego, Is.GreaterThan(0));
        }

        [Test]
        public void CursesHappen()
        {
            Item ring = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && (String.IsNullOrEmpty(ring.Magic.Curse) || ring.ItemType == ItemTypeConstants.SpecificCursedItem))
            {
                var power = GetNewPower(false);
                ring = RingGenerator.GenerateAtPower(power);
            }

            Assert.That(ring.Magic.Curse, Is.Not.Empty);
        }

        [Test]
        public void SpecificCursesHappen()
        {
            Item ring = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && ring.ItemType != ItemTypeConstants.SpecificCursedItem)
            {
                var power = GetNewPower(false);
                ring = RingGenerator.GenerateAtPower(power);
            }

            Assert.That(ring.ItemType, Is.EqualTo(ItemTypeConstants.SpecificCursedItem));
        }

        [Test]
        public void TraitsHappen()
        {
            Item ring = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && !ring.Traits.Any())
            {
                var power = GetNewPower(false);
                ring = RingGenerator.GenerateAtPower(power);
            }

            Assert.That(ring.Traits, Is.Not.Empty);
        }
    }
}