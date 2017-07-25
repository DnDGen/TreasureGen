using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class WandGeneratorTests : MagicalItemGeneratorStressTests
    {
        protected override bool allowMinor
        {
            get { return true; }
        }

        protected override string itemType
        {
            get { return ItemTypeConstants.Wand; }
        }

        [Test]
        public void StressWand()
        {
            stressor.Stress(GenerateAndAssertItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item wand)
        {
            Assert.That(wand.Name, Does.StartWith("Wand of"));
            Assert.That(wand.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(wand.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(wand.Contents, Is.Empty);
            Assert.That(wand.IsMagical, Is.True);
            Assert.That(wand.ItemType, Is.EqualTo(ItemTypeConstants.Wand));
            Assert.That(wand.Magic.Bonus, Is.EqualTo(0));
            Assert.That(wand.Magic.Charges, Is.Positive);
            Assert.That(wand.Magic.Curse, Is.Not.Null);
            Assert.That(wand.Magic.Intelligence.Ego, Is.EqualTo(0));
            Assert.That(wand.Magic.SpecialAbilities, Is.Empty);
            Assert.That(wand.Quantity, Is.EqualTo(1));
            Assert.That(wand.Traits, Is.Not.Null);

            var itemMaterials = wand.Traits.Intersect(materials);
            Assert.That(itemMaterials, Is.Empty);
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return new[] { "Wand of " + Guid.NewGuid().ToString() };
        }

        [Test]
        public void StressCustomWand()
        {
            stressor.Stress(GenerateAndAssertCustomItem);
        }

        [Test]
        public void StressWandFromSubset()
        {
            stressor.Stress(GenerateAndAssertItemFromSubset);
        }
    }
}