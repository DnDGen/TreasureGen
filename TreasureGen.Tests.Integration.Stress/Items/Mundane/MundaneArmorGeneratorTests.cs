using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class MundaneArmorGeneratorTests : MundaneItemGeneratorStressTests
    {
        [SetUp]
        public void Setup()
        {
            mundaneItemGenerator = GetNewInstanceOf<MundaneItemGenerator>(ItemTypeConstants.Armor);
        }

        [Test]
        public void StressArmor()
        {
            stressor.Stress(GenerateAndAssertItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item item)
        {
            Assert.That(item.Name, Is.Not.Empty);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Armor), item.Name);
            Assert.That(item.Attributes, Is.Not.Null, item.Name);
            Assert.That(item.Quantity, Is.EqualTo(1));
            Assert.That(item.IsMagical, Is.False);

            var sizes = TraitConstants.Sizes.All();
            Assert.That(item.Traits.Intersect(sizes), Is.Empty);

            Assert.That(item, Is.InstanceOf<Armor>());

            var armor = item as Armor;
            Assert.That(armor.ArmorBonus, Is.Positive);
            Assert.That(armor.ArmorCheckPenalty, Is.Not.Positive);
            Assert.That(armor.MaxDexterityBonus, Is.Not.Negative);
            Assert.That(armor.Size, Is.Not.Empty);
            Assert.That(sizes, Contains.Item(armor.Size));
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return ArmorConstants.GetAllArmors(false);
        }

        [Test]
        public void StressCustomArmor()
        {
            stressor.Stress(GenerateAndAssertCustomItem);
        }

        [Test]
        public void StressMundaneArmorFromSubset()
        {
            stressor.Stress(GenerateAndAssertItemFromSubset);
        }
    }
}