using Ninject;
using NUnit.Framework;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class MundaneArmorGeneratorTests : MundaneItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Armor)]
        public MundaneItemGenerator MundaneArmorGenerator { get; set; }

        [Test]
        public void StressArmor()
        {
            Stress(StressItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item item)
        {
            Assert.That(item.Name, Is.Not.Empty);
            Assert.That(item.Traits, Contains.Item(TraitConstants.Small)
                .Or.Contains(TraitConstants.Medium)
                .Or.Contains(TraitConstants.Large));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.Armor), item.Name);
            Assert.That(item.Attributes, Is.Not.Null, item.Name);
            Assert.That(item.Quantity, Is.EqualTo(1));
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.Contents, Is.Empty);
        }

        protected override Item GenerateItem()
        {
            return MundaneArmorGenerator.Generate();
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
            var shield = GenerateOrFail(GenerateItem, s => s.Traits.Contains(TraitConstants.Darkwood) && s.Attributes.Contains(AttributeConstants.Shield));
            AssertItem(shield);
            Assert.That(shield.Traits, Contains.Item(TraitConstants.Darkwood));
            Assert.That(shield.Attributes, Contains.Item(AttributeConstants.Shield));
        }
    }
}