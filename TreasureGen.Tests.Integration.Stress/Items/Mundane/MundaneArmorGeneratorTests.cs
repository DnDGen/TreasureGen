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
            Stress(StressItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item item)
        {
            Assert.That(item.Name, Is.Not.Empty);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Armor), item.Name);
            Assert.That(item.Attributes, Is.Not.Null, item.Name);
            Assert.That(item.Quantity, Is.EqualTo(1));
            Assert.That(item.IsMagical, Is.False);

            var sizes = TraitConstants.Sizes.All();
            Assert.That(item.Traits.Intersect(sizes), Is.Not.Empty);
        }

        [Test]
        public override void SpecialMaterialsHappen()
        {
            base.SpecialMaterialsHappen();
        }

        [Test]
        public override void NoDecorationsHappen()
        {
            AssertNoDecorationsHappen();
        }

        [Test]
        public void DarkwoodShieldsHappen()
        {
            var shield = GenerateOrFail(GenerateItem, s => s.Traits.Contains(TraitConstants.SpecialMaterials.Darkwood) && s.Attributes.Contains(AttributeConstants.Shield));
            AssertItem(shield);
            Assert.That(shield.Traits, Contains.Item(TraitConstants.SpecialMaterials.Darkwood));
            Assert.That(shield.Attributes, Contains.Item(AttributeConstants.Shield));
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return ArmorConstants.GetAllArmors(false);
        }

        [Test]
        public void StressCustomArmor()
        {
            Stress(StressCustomItem);
        }

        [Test]
        public void StressRandomCustomArmor()
        {
            Stress(StressRandomCustomItem);
        }
    }
}