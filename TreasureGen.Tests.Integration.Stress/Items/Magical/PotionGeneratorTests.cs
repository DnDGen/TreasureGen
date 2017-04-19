using NUnit.Framework;
using System.Collections.Generic;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
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
            Stress(StressItem);
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
            Stress(StressCustomItem);
        }

        [Test]
        public void StressRandomCustomPotion()
        {
            Stress(StressRandomCustomItem);
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
        public override void SpecificCursedItemsWithTraitsHappen()
        {
            AssertSpecificCursedItemsWithTraitsHappen();
        }

        [Test]
        public override void SpecificCursedItemsWithIntelligenceHappen()
        {
            AssertSpecificCursedItemsWithIntelligenceHappen();
        }

        [Test]
        public override void SpecificCursedItemsWithNoDecorationHappen()
        {
            AssertSpecificCursedItemsWithNoDecorationHappen();
        }

        [Test]
        public override void StressSpecificCursedItems()
        {
            base.StressSpecificCursedItems();
        }

        [Test]
        public void StressPotionFromSubset()
        {
            Stress(StressItemFromSubset);
        }
    }
}