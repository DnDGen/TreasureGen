using NUnit.Framework;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items
{
    public class ItemVerifier
    {
        public void AssertItem(Item item)
        {
            Assert.That(item.Name, Is.Not.Empty);
            Assert.That(item.Attributes, Is.Not.Null);
            Assert.That(item.Magic, Is.Not.Null);
            Assert.That(item.Quantity, Is.InRange(1, 50));
            Assert.That(item.Traits, Is.Not.Null);
            Assert.That(item.Contents, Is.Not.Null);
            Assert.That(item.ItemType, Is.Not.Empty);
            Assert.That(item.Traits, Is.Unique, item.Name);
        }

        public void AssertIntelligence(Intelligence intelligence)
        {
            Assert.That(intelligence.Ego, Is.Positive);
            Assert.That(intelligence.Alignment, Is.Not.Empty);
            Assert.That(intelligence.CharismaStat, Is.AtLeast(10));
            Assert.That(intelligence.WisdomStat, Is.AtLeast(10));
            Assert.That(intelligence.IntelligenceStat, Is.AtLeast(10));
            Assert.That(intelligence.Communication, Is.Not.Empty);
            Assert.That(intelligence.Personality, Is.Not.Empty);
            Assert.That(intelligence.Powers, Is.Not.Empty);
            Assert.That(intelligence.Senses, Is.Not.Empty);
        }

        public void AssertSpecificCursedItem(Item item)
        {
            var materials = TraitConstants.GetSpecialMaterials();

            AssertItem(item);
            Assert.That(item.Magic.Curse, Is.Not.Empty);
            Assert.That(item.Magic.Curse, Is.EqualTo(CurseConstants.SpecificCursedItem));
            Assert.That(item.Attributes, Contains.Item(AttributeConstants.Specific));
            Assert.That(item.Traits.Intersect(materials), Is.Empty);
        }
    }
}
