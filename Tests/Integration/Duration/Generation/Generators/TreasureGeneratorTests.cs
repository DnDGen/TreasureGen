using System;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Generators
{
    [TestFixture]
    public class TreasureGeneratorTests : DurationTest
    {
        [Inject]
        public ITreasureGenerator TreasureGenerator { get; set; }

        private Int32 level;

        [SetUp]
        public void Setup()
        {
            level = GetNewLevel();
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void TreasureGeneratorDuration()
        {
            TreasureGenerator.GenerateAtLevel(level);
            AssertDuration();
        }
    }
}