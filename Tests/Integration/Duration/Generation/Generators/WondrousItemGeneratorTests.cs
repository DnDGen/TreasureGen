using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Generators
{
    [TestFixture]
    public class WondrousItemGeneratorTests : DurationTest
    {
        [Inject]
        public IMagicalItemGeneratorFactory MagicalItemGeneratorFactory { get; set; }

        private IMagicalItemGenerator wondrousItemGenerator;
        private String power;

        [SetUp]
        public void Setup()
        {
            wondrousItemGenerator = MagicalItemGeneratorFactory.CreateWith(ItemTypeConstants.WondrousItem);
            power = GetNewPower(false);

            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void WondrousItemGeneratorDuration()
        {
            wondrousItemGenerator.GenerateAtPower(power);
            AssertDuration();
        }
    }
}