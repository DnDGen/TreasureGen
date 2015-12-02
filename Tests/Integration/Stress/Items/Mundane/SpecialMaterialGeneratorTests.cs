using Ninject;
using NUnit.Framework;
using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Generators.Items.Mundane;

namespace TreasureGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class SpecialMaterialGeneratorTests : ItemTests
    {
        [Inject]
        public ISpecialMaterialGenerator SpecialMaterialGenerator { get; set; }
        [Inject, Named(ItemTypeConstants.Weapon)]
        public IMundaneItemGenerator WeaponGenerator { get; set; }
        [Inject, Named(ItemTypeConstants.Armor)]
        public IMagicalItemGenerator ArmorGenerator { get; set; }

        [TestCase("Special material generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override void MakeAssertions()
        {
            var item = Generate(i => SpecialMaterialGenerator.CanHaveSpecialMaterial(i.ItemType, i.Attributes, i.Traits));

            var material = SpecialMaterialGenerator.GenerateFor(item.ItemType, item.Attributes, item.Traits);
            Assert.That(material, Is.Not.Empty);
        }

        protected override Item GenerateItem()
        {
            var itemType = GetNewGearItemType();

            switch (itemType)
            {
                case ItemTypeConstants.Armor: return ArmorGenerator.GenerateAtPower(PowerConstants.Minor);
                case ItemTypeConstants.Weapon: return WeaponGenerator.Generate();
                default: throw new ArgumentOutOfRangeException();
            }
        }

        [Test]
        public void SpecialMaterialHappens()
        {
            GenerateOrFail(i => SpecialMaterialGenerator.CanHaveSpecialMaterial(i.ItemType, i.Attributes, i.Traits));
        }

        [Test]
        public void SpecialMaterialDoesNotHappen()
        {
            GenerateOrFail(i => SpecialMaterialGenerator.CanHaveSpecialMaterial(i.ItemType, i.Attributes, i.Traits) == false);
        }
    }
}