using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items.Mundane;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class SpecialMaterialGeneratorTests : StressTests
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
            Boolean hasSpecialMaterial;
            Item item;

            do
            {
                item = GenerateItem();
                hasSpecialMaterial = SpecialMaterialGenerator.CanHaveSpecialMaterial(item.ItemType, item.Attributes, item.Traits);
            }
            while (TestShouldKeepRunning() && !hasSpecialMaterial);

            if (hasSpecialMaterial)
            {
                var material = SpecialMaterialGenerator.GenerateFor(item.ItemType, item.Attributes, item.Traits);
                Assert.That(material, Is.Not.Empty);
            }
        }

        private Item GenerateItem()
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
            Boolean hasSpecialMaterial;

            do
            {
                var item = GenerateItem();
                hasSpecialMaterial = SpecialMaterialGenerator.CanHaveSpecialMaterial(item.ItemType, item.Attributes, item.Traits);
            }
            while (TestShouldKeepRunning() && !hasSpecialMaterial);

            Assert.That(hasSpecialMaterial, Is.True);
        }

        [Test]
        public void SpecialMaterialDoesNotHappen()
        {
            Boolean hasSpecialMaterial;

            do
            {
                var item = GenerateItem();
                hasSpecialMaterial = SpecialMaterialGenerator.CanHaveSpecialMaterial(item.ItemType, item.Attributes, item.Traits);
            }
            while (TestShouldKeepRunning() && hasSpecialMaterial);

            Assert.That(hasSpecialMaterial, Is.False);
        }
    }
}