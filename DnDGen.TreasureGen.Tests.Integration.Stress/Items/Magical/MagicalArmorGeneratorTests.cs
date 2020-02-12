using DnDGen.TreasureGen.Items;
using NUnit.Framework;
using System.Collections.Generic;

namespace DnDGen.TreasureGen.Tests.Integration.Stress.Items.Magical
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
            stressor.Stress(GenerateAndAssertItem);
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
            stressor.Stress(GenerateAndAssertCustomItem);
        }

        [Test]
        public void StressArmorFromName()
        {
            stressor.Stress(GenerateAndAssertItemFromName);
        }
    }
}