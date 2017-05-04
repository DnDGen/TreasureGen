using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class RingGeneratorTests : MagicalItemGeneratorStressTests
    {
        protected override bool allowMinor
        {
            get { return true; }
        }

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
            Assert.That(ring.Name, Does.StartWith("Ring of "), ring.Name);
            Assert.That(ring.Traits, Is.Not.Null, ring.Name);
            Assert.That(ring.Attributes, Is.Not.Null, ring.Name);
            Assert.That(ring.Quantity, Is.EqualTo(1), ring.Name);
            Assert.That(ring.IsMagical, Is.True, ring.Name);
            Assert.That(ring.Contents, Is.Not.Null, ring.Name);
            Assert.That(ring.ItemType, Is.EqualTo(ItemTypeConstants.Ring), ring.Name);
            Assert.That(ring.Magic.Bonus, Is.Not.Negative, ring.Name);
            Assert.That(ring.Magic.Charges, Is.Not.Negative, ring.Name);
            Assert.That(ring.Magic.SpecialAbilities, Is.Empty, ring.Name);

            var itemMaterials = ring.Traits.Intersect(materials);
            Assert.That(itemMaterials, Is.Empty, ring.Name);
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return RingConstants.GetAllRings();
        }

        [Test]
        public void StressCustomRing()
        {
            Stress(StressCustomItem);
        }

        [Test]
        public void StressRingFromSubset()
        {
            Stress(StressItemFromSubset);
        }
    }
}