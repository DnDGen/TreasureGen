using System;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Generators
{
    [TestFixture]
    public class ItemGeneratorTests : DurationTest
    {
        [Inject]
        public IItemGenerator ItemGenerator { get; set; }

        private String power;

        [SetUp]
        public void Setup()
        {
            power = GetNewPower(true);
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void ItemGeneratorDuration()
        {
            ItemGenerator.GenerateAtPower(power);
            AssertDuration();
        }
    }
}