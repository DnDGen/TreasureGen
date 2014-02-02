using System;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Generators
{
    [TestFixture]
    public class ItemsGeneratorTests : DurationTest
    {
        [Inject]
        public IItemsGenerator ItemsGenerator { get; set; }

        private Int32 level;
        private String power;

        [SetUp]
        public void Setup()
        {
            level = GetNewLevel();
            power = GetNewPower(true);

            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void ItemsGeneratorAtLevelDuration()
        {
            ItemsGenerator.GenerateAtLevel(level);
            AssertDuration();
        }

        [Test]
        public void ItemsGeneratorAtPowerDuration()
        {
            ItemsGenerator.GenerateAtPower(power);
            AssertDuration();
        }
    }
}