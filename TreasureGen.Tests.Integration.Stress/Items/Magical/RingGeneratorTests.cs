using Ninject;
using NUnit.Framework;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class RingGeneratorTests : MagicalItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Ring)]
        public MagicalItemGenerator RingGenerator { get; set; }

        protected override string itemType
        {
            get { return ItemTypeConstants.Ring; }
        }

        [Test]
        public void StressRing()
        {
            Stress(StressItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item ring)
        {
            Assert.That(ring.Name, Does.StartWith("Ring of "));
            Assert.That(ring.Traits, Is.Not.Null);
            Assert.That(ring.Attributes, Is.Not.Null);
            Assert.That(ring.Quantity, Is.EqualTo(1));
            Assert.That(ring.IsMagical, Is.True);
            Assert.That(ring.Contents, Is.Not.Null);
            Assert.That(ring.ItemType, Is.EqualTo(ItemTypeConstants.Ring));
            Assert.That(ring.Magic.Bonus, Is.Not.Negative);
            Assert.That(ring.Magic.Charges, Is.Not.Negative);
            Assert.That(ring.Magic.SpecialAbilities, Is.Empty);

            var itemMaterials = ring.Traits.Intersect(materials);
            Assert.That(itemMaterials, Is.Empty);
        }

        protected override Item GenerateItem()
        {
            var power = GetNewPower();
            return RingGenerator.GenerateAtPower(power);
        }

        [Test]
        public void ChargesHappen()
        {
            var ring = GenerateOrFail(GenerateItem, r => r.ItemType == itemType && r.Attributes.Contains(AttributeConstants.Charged));
            AssertItem(ring);
            Assert.That(ring.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(ring.Magic.Charges, Is.Positive);
        }

        [Test]
        public void ChargesDoNotHappen()
        {
            var ring = GenerateOrFail(GenerateItem, r => r.ItemType == itemType && r.Attributes.Contains(AttributeConstants.Charged) == false);
            AssertItem(ring);
            Assert.That(ring.Attributes, Is.All.Not.EqualTo(AttributeConstants.Charged));
            Assert.That(ring.Magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public void ContentsHappen()
        {
            var ring = GenerateOrFail(GenerateItem, r => r.ItemType == itemType && r.Contents.Any());
            AssertItem(ring);
            Assert.That(ring.Contents, Is.Not.Empty);
        }

        [Test]
        public void ContentsDoNotHappen()
        {
            var ring = GenerateOrFail(GenerateItem, r => r.ItemType == itemType && r.Contents.Any() == false);
            AssertItem(ring);
            Assert.That(ring.Contents, Is.Empty);
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