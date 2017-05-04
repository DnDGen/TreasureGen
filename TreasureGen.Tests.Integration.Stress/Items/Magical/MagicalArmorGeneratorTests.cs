using NUnit.Framework;
using System.Collections.Generic;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class MagicalArmorGeneratorTests : MagicalItemGeneratorStressTests
    {
        protected override bool allowMinor
        {
            get { return true; }
        }

        protected override string itemType
        {
            get { return ItemTypeConstants.Armor; }
        }

        [Test]
        public void StressArmor()
        {
            Stress(StressItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item armor)
        {
            Assert.That(armor.Quantity, Is.EqualTo(1), armor.Name);
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor), armor.Name);
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return ArmorConstants.GetAllArmors(true);
        }

        [Test]
        public void StressCustomArmor()
        {
            Stress(StressCustomItem);
        }

        [Test]
        public void StressArmorFromSubset()
        {
            Stress(StressItemFromSubset);
        }
    }
}