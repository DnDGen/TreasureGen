using NUnit.Framework;
using System.Collections.Generic;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;

namespace DnDGen.TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class PotionGeneratorTests : MagicalItemGeneratorStressTests
    {
        protected override bool allowMinor
        {
            get { return true; }
        }

        protected override string itemType
        {
            get { return ItemTypeConstants.Potion; }
        }

        [Test]
        public void StressPotion()
        {
            stressor.Stress(GenerateAndAssertItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item potion)
        {
            Assert.That(potion.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(potion.IsMagical, Is.True);
            Assert.That(potion.Magic.Bonus, Is.Not.Negative);
            Assert.That(potion.Quantity, Is.EqualTo(1));
            Assert.That(potion.ItemType, Is.EqualTo(ItemTypeConstants.Potion));
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return PotionConstants.GetAllPotions();
        }

        [Test]
        public void StressCustomPotion()
        {
            stressor.Stress(GenerateAndAssertCustomItem);
        }

        [Test]
        [Ignore("There is no currently-known use case where we generate a potion from a subset")]
        public void StressPotionFromSubset()
        {
            stressor.Stress(GenerateAndAssertItemFromSubset);
        }
    }
}