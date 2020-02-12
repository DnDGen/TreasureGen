using DnDGen.TreasureGen.Items;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class ScrollGeneratorTests : MagicalItemGeneratorStressTests
    {
        protected override bool allowMinor
        {
            get { return true; }
        }

        protected override string itemType
        {
            get { return ItemTypeConstants.Scroll; }
        }

        [Test]
        public void StressScroll()
        {
            stressor.Stress(GenerateAndAssertItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item scroll)
        {
            Assert.That(scroll.Name, Is.EqualTo(ItemTypeConstants.Scroll));

            var trash = Guid.Empty;
            if (scroll.Traits.Any(t => Guid.TryParse(t, out trash) == false))
            {
                Assert.That(scroll.Traits.Single(), Is.EqualTo("Arcane").Or.EqualTo("Divine"));
            }

            Assert.That(scroll.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(scroll.Attributes.Count(), Is.EqualTo(1));
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

        protected override IEnumerable<string> GetItemNames()
        {
            return new[] { ItemTypeConstants.Scroll };
        }

        [Test]
        public void StressCustomScroll()
        {
            stressor.Stress(GenerateAndAssertCustomItem);
        }

        [Test]
        public void StressScrollFromName()
        {
            stressor.Stress(GenerateAndAssertItemFromName);
        }
    }
}