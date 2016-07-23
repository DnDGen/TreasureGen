using Ninject;
using NUnit.Framework;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class WandGeneratorTests : MagicalItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Wand)]
        public MagicalItemGenerator WandGenerator { get; set; }

        protected override string itemType
        {
            get { return ItemTypeConstants.Wand; }
        }

        [Test]
        public void StressWand()
        {
            Stress(StressItem);
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
            Assert.That(wand.Magic.Charges, Is.InRange(1, 50));
            Assert.That(wand.Magic.Curse, Is.Not.Null);
            Assert.That(wand.Magic.Intelligence.Ego, Is.EqualTo(0));
            Assert.That(wand.Magic.SpecialAbilities, Is.Empty);
            Assert.That(wand.Quantity, Is.EqualTo(1));
            Assert.That(wand.Traits, Is.Not.Null);

            var itemMaterials = wand.Traits.Intersect(materials);
            Assert.That(itemMaterials, Is.Empty);
        }

        protected override Item GenerateItem()
        {
            var power = GetNewPower();
            return WandGenerator.GenerateAtPower(power);
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