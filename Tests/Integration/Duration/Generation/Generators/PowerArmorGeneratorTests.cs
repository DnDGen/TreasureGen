using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Generators
{
    [TestFixture]
    public class PowerArmorGeneratorTests : DurationTest
    {
        [Inject]
        public IPowerGearGeneratorFactory GearGeneratorFactory { get; set; }

        private IPowerGearGenerator powerArmorGenerator;
        private String power;

        [SetUp]
        public void Setup()
        {
            powerArmorGenerator = GearGeneratorFactory.CreateWith(ItemsConstants.ItemTypes.Armor);
            power = GetNewPower();

            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void PowerArmorGeneratorDuration()
        {
            powerArmorGenerator.GenerateAtPower(power);
            AssertDuration();
        }
    }
}