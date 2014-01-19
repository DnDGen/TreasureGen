using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Generators
{
    [TestFixture]
    public class ArmorGeneratorTests : DurationTest
    {
        [Inject]
        public IGearGeneratorFactory GearGeneratorFactory { get; set; }

        private IGearGenerator armorGenerator;
        private String power;
        private Int32 level;

        [SetUp]
        public void Setup()
        {
            armorGenerator = GearGeneratorFactory.CreateWith(ItemsConstants.ItemTypes.Armor);
            power = GetNewPower();
            level = GetNewLevel();

            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void ArmorGeneratorAtPowerDuration()
        {
            armorGenerator.GenerateAtPower(power);
            AssertDuration();
        }

        [Test]
        public void ArmorGeneratorAtLevelDuration()
        {
            armorGenerator.GenerateAtLevel(level);
            AssertDuration();
        }
    }
}