using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class WondrousItemGeneratorTests : MagicalItemGeneratorStressTests
    {
        protected override bool allowMinor
        {
            get { return true; }
        }

        protected override string itemType
        {
            get { return ItemTypeConstants.WondrousItem; }
        }

        [Test]
        public void StressWondrousItem()
        {
            Stress(StressItem);
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return WondrousItemConstants.GetAllWondrousItems();
        }

        [Test]
        public void StressCustomWondrousItem()
        {
            Stress(StressCustomItem);
        }

        [Test]
        public void StressRandomCustomWondrousItem()
        {
            Stress(StressRandomCustomItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item wondrousItem)
        {
            Assert.That(wondrousItem.Name, Is.Not.Empty);
            Assert.That(wondrousItem.Traits, Is.Not.Null);
            Assert.That(wondrousItem.Attributes, Is.Not.Null);
            Assert.That(wondrousItem.IsMagical, Is.True);
            Assert.That(wondrousItem.Contents, Is.Not.Null);
            Assert.That(wondrousItem.ItemType, Is.EqualTo(ItemTypeConstants.WondrousItem));
            Assert.That(wondrousItem.Magic.Bonus, Is.Not.Negative);
            Assert.That(wondrousItem.Magic.Charges, Is.Not.Negative);
            Assert.That(wondrousItem.Magic.SpecialAbilities, Is.Empty);

            var itemMaterials = wondrousItem.Traits.Intersect(materials);
            Assert.That(itemMaterials, Is.Empty);
        }

        [Test]
        public void ChargesHappen()
        {
            var item = GenerateOrFail(GenerateItem, i => i.ItemType == itemType && i.Attributes.Contains(AttributeConstants.Charged));
            AssertItem(item);
            Assert.That(item.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(item.Magic.Charges, Is.Positive);
        }

        [Test]
        public void ChargesDoNotHappen()
        {
            var item = GenerateOrFail(GenerateItem, i => i.ItemType == itemType && i.Attributes.Contains(AttributeConstants.Charged) == false);
            AssertItem(item);
            Assert.That(item.Attributes, Is.All.Not.EqualTo(AttributeConstants.Charged));
            Assert.That(item.Magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public override void IntelligenceHappens()
        {
            base.IntelligenceHappens();
        }

        [Test]
        public override void TraitsHappen()
        {
            base.TraitsHappen();
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
    }
}