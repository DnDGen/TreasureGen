using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Factories
{
    [TestFixture]
    public class PowerGearGeneratorFactoryTests
    {
        private IPowerGearGeneratorFactory factory;

        [SetUp]
        public void Setup()
        {
            factory = new PowerGearGeneratorFactory();
        }

        [Test]
        public void PowerGearGeneratorFactoryProducesArmorGenerator()
        {
            var generator = factory.CreateWith(ItemsConstants.ItemTypes.Armor);
            Assert.That(generator, Is.TypeOf<PowerArmorGenerator>());
        }

        [Test]
        public void PowerGearGeneratorFactoryProducesWeaponGenerator()
        {
            var generator = factory.CreateWith(ItemsConstants.ItemTypes.Weapon);
            Assert.That(generator, Is.TypeOf<PowerWeaponGenerator>());
        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InvalidTypeThrowsError()
        {
            factory.CreateWith("invalid type");
        }
    }
}