using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Generators
{
    [TestFixture]
    public class MagicalArmorGeneratorTests : DurationTest
    {
        [Inject]
        public IMagicalGearGeneratorFactory GearGeneratorFactory { get; set; }

        private IMagicalGearGenerator magicalArmorGenerator;
        private String power;

        [SetUp]
        public void Setup()
        {
            magicalArmorGenerator = GearGeneratorFactory.CreateWith(ItemsConstants.ItemTypes.Armor);
            power = GetNewPower(false);

            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void MagicalArmorGeneratorDuration()
        {
            magicalArmorGenerator.GenerateAtPower(power);
            AssertDuration();
        }
    }
}