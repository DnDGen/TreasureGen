using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class RodGeneratorTests : MagicalItemGeneratorStressTests
    {
        protected override bool allowMinor
        {
            get { return false; }
        }

        protected override string itemType
        {
            get { return ItemTypeConstants.Rod; }
        }

        [Test]
        public void StressRod()
        {
            Stress(StressItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item rod)
        {
            Assert.That(rod.Name, Is.Not.Empty);
            Assert.That(rod.Attributes, Is.Not.Null);
            Assert.That(rod.Contents, Is.Not.Null);
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.Magic.Bonus, Is.Not.Negative);
            Assert.That(rod.Magic.Charges, Is.Not.Negative);
            Assert.That(rod.Quantity, Is.EqualTo(1));
            Assert.That(rod.Traits, Is.Not.Null);

            var rodMaterials = rod.Traits.Intersect(materials);
            Assert.That(rodMaterials, Is.Empty);
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return RodConstants.GetAllRods();
        }

        [Test]
        public void StressCustomRod()
        {
            Stress(StressCustomItem);
        }

        [Test]
        public void StressRandomCustomRod()
        {
            Stress(StressRandomCustomItem);
        }

        [Test]
        public void ChargesHappen()
        {
            var rod = GenerateOrFail(GenerateItem, r => r.ItemType == itemType && r.Attributes.Contains(AttributeConstants.Charged));
            AssertItem(rod);
            Assert.That(rod.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(rod.Magic.Charges, Is.Positive);
        }

        [Test]
        public void ChargesDoNotHappen()
        {
            var rod = GenerateOrFail(GenerateItem, r => r.ItemType == itemType && r.Attributes.Contains(AttributeConstants.Charged) == false);
            AssertItem(rod);
            Assert.That(rod.Attributes, Is.All.Not.EqualTo(AttributeConstants.Charged));
            Assert.That(rod.Magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public void ContentsHappen()
        {
            var rod = GenerateOrFail(GenerateItem, r => r.ItemType == itemType && r.Contents.Any());
            AssertItem(rod);
            Assert.That(rod.Contents, Is.Not.Empty);
        }

        [Test]
        public void ContentsDoNotHappen()
        {
            var rod = GenerateOrFail(GenerateItem, r => r.ItemType == itemType && r.Contents.Any() == false);
            AssertItem(rod);
            Assert.That(rod.Contents, Is.Empty);
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