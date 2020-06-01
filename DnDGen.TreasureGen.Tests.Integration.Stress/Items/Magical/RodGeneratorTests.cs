using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Integration.Stress.Items.Magical
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
            stressor.Stress(GenerateAndAssertItem);
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

            if (!(rod is Weapon))
            {
                var rodMaterials = rod.Traits.Intersect(materials);
                Assert.That(rodMaterials, Is.Empty);
            }
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return RodConstants.GetAllRods();
        }

        [Test]
        public void StressCustomRod()
        {
            stressor.Stress(GenerateAndAssertCustomItem);
        }

        [Test]
        public void StressRodFromName()
        {
            stressor.Stress(GenerateAndAssertItemFromName);
        }
    }
}