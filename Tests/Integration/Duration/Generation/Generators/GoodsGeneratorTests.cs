using System;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Generators
{
    [TestFixture]
    public class GoodsGeneratorTests : DurationTest
    {
        [Inject]
        public IGoodsGenerator GoodsGenerator { get; set; }

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
        public void GoodsGeneratorDuration()
        {
            GoodsGenerator.GenerateAtLevel(level);
            AssertDuration();
        }
    }
}