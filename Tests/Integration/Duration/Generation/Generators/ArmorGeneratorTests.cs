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

        [SetUp]
        public void Setup()
        {
            armorGenerator = GearGeneratorFactory.CreateWith(ItemsConstants.ItemTypes.Armor);
            power = GetNewPower();

            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void ArmorGeneratorDuration()
        {
            armorGenerator.GenerateAtPower(power);
            AssertDuration();
        }
    }
}