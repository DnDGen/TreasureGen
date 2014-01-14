using System;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Factories
{
    [TestFixture]
    public class GoodsFactoryTests : DurationTest
    {
        [Inject]
        public IGoodsFactory GoodsFactory { get; set; }

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
        public void GoodsFactoryDuration()
        {
            GoodsFactory.CreateAtLevel(level);
            AssertDuration();
        }
    }
}