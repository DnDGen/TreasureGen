using System;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class ScrollGeneratorTests : StressTests
    {
        [Inject, Named(ItemTypeConstants.Scroll)]
        public IMagicalItemGenerator ScrollGenerator { get; set; }

        [Test]
        public void StressedScrollGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var power = GetNewPower(false);
            var scroll = ScrollGenerator.GenerateAtPower(power);

            if (scroll.ItemType == ItemTypeConstants.SpecificCursedItem)
                return;

            Assert.That(scroll.Name, Is.EqualTo("Divine scroll").Or.EqualTo("Arcane scroll"));
            Assert.That(scroll.Traits, Is.Empty);
            Assert.That(scroll.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(scroll.Quantity, Is.EqualTo(1));
            Assert.That(scroll.IsMagical, Is.True);
            Assert.That(scroll.Contents, Is.Not.Empty);
            Assert.That(scroll.ItemType, Is.EqualTo(ItemTypeConstants.Scroll));
            Assert.That(scroll.Magic.Bonus, Is.EqualTo(0));
            Assert.That(scroll.Magic.Charges, Is.EqualTo(0));
            Assert.That(scroll.Magic.Curse, Is.Not.Null);
            Assert.That(scroll.Magic.Intelligence.Ego, Is.EqualTo(0));
            Assert.That(scroll.Magic.SpecialAbilities, Is.Empty);
        }

        [Test]
        public void CursesHappen()
        {
            var scroll = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && (String.IsNullOrEmpty(scroll.Magic.Curse) || scroll.ItemType == ItemTypeConstants.SpecificCursedItem))
            {
                var power = GetNewPower(false);
                scroll = ScrollGenerator.GenerateAtPower(power);
            }

            Assert.That(scroll.ItemType, Is.Not.EqualTo(ItemTypeConstants.SpecificCursedItem));
            Assert.That(scroll.Magic.Curse, Is.Not.Empty);
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void SpecificCursesHappen()
        {
            var scroll = new Item();

            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && scroll.ItemType != ItemTypeConstants.SpecificCursedItem)
            {
                var power = GetNewPower(false);
                scroll = ScrollGenerator.GenerateAtPower(power);
            }

            Assert.That(scroll.ItemType, Is.EqualTo(ItemTypeConstants.SpecificCursedItem));
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void NoDecorationsHappen()
        {
            var scroll = new Item();

            do
            {
                var power = GetNewPower(false);
                scroll = ScrollGenerator.GenerateAtPower(power);
            } while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && scroll.Magic.Curse.Any());

            Assert.That(scroll.Magic.Curse, Is.Empty);
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }
    }
}