using Ninject;
using NUnit.Framework;
using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Mundane;

namespace TreasureGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class MundaneArmorGeneratorTests : MundaneItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Armor)]
        public IMundaneItemGenerator MundaneArmorGenerator { get; set; }

        [TestCase("Mundane armor generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override void MakeAssertions()
        {
            var armor = GenerateItem();

            Assert.That(armor.Name, Is.Not.Empty);
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Small)
                .Or.Contains(TraitConstants.Medium)
                .Or.Contains(TraitConstants.Large));
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor), armor.Name);
            Assert.That(armor.Attributes, Is.Not.Null, armor.Name);
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.IsMagical, Is.False);
            Assert.That(armor.Contents, Is.Empty);
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
    }
}