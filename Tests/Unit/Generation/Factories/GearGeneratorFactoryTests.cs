using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Factories
{
    [TestFixture]
    public class GearGeneratorFactoryTests
    {
        private IGearGeneratorFactory factory;

        [SetUp]
        public void Setup()
        {
            factory = new GearGeneratorFactory();
        }

        [Test]
        public void GearGeneratorFactoryProducesArmorGenerator()
        {
            var generator = factory.CreateWith(ItemsConstants.ItemTypes.Armor);
            Assert.That(generator, Is.TypeOf<ArmorGenerator>());
        }

        [Test]
        public void GearGeneratorFactoryProducesWeaponGenerator()
        {
            var generator = factory.CreateWith(ItemsConstants.ItemTypes.Weapon);
            Assert.That(generator, Is.TypeOf<WeaponGenerator>());
        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InvalidTypeThrowsError()
        {
            factory.CreateWith("invalid type");
        }
    }
}