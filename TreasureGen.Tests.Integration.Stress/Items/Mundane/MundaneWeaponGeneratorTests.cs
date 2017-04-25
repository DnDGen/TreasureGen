using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class MundaneWeaponGeneratorTests : MundaneItemGeneratorStressTests
    {
        [SetUp]
        public void Setup()
        {
            mundaneItemGenerator = GetNewInstanceOf<MundaneItemGenerator>(ItemTypeConstants.Weapon);
        }

        [Test]
        public void StressWeapon()
        {
            Stress(StressItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item item)
        {
            Assert.That(item.Name, Is.Not.Empty);
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(item.Quantity, Is.Positive);
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.Attributes, Contains.Item(AttributeConstants.Common)
                .Or.Contains(AttributeConstants.Uncommon));
            Assert.That(item.Attributes, Contains.Item(AttributeConstants.Melee)
                .Or.Contains(AttributeConstants.Ranged));

            var sizes = TraitConstants.Sizes.All();
            Assert.That(item.Traits.Intersect(sizes), Is.Empty);
            Assert.That(item, Is.InstanceOf<Weapon>());

            var weapon = item as Weapon;
            Assert.That(weapon.Size, Is.Not.Empty);
            Assert.That(sizes, Contains.Item(weapon.Size));
        }

        [Test]
        public override void SpecialMaterialsHappen()
        {
            base.SpecialMaterialsHappen();
        }

        [Test]
        public void MasterworkHappens()
        {
            var weapon = GenerateOrFail(GenerateItem, w => w.Traits.Contains(TraitConstants.Masterwork));
            AssertItem(weapon);
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public override void NoDecorationsHappen()
        {
            AssertNoDecorationsHappen();
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return WeaponConstants.GetBaseNames();
        }

        [Test]
        public void StressCustomWeapon()
        {
            Stress(StressCustomItem);
        }

        [Test]
        public void StressRandomCustomWeapon()
        {
            Stress(StressRandomCustomItem);
        }

        [Test]
        public void StressMundaneWeaponFromSubset()
        {
            Stress(StressItemFromSubset);
        }
    }
}