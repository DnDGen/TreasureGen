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

        protected override void MakeSpecificAssertionsAgainst(Item weapon)
        {
            Assert.That(weapon.Name, Is.Not.Empty);
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Quantity, Is.Positive);
            Assert.That(weapon.IsMagical, Is.False);
            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Common)
                .Or.Contains(AttributeConstants.Uncommon));
            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Melee)
                .Or.Contains(AttributeConstants.Ranged));

            var sizes = TraitConstants.Sizes.All();
            Assert.That(weapon.Traits.Intersect(sizes), Is.Not.Empty);
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