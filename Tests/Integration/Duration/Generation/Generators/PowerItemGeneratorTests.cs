using System;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Generators
{
    [TestFixture]
    public class PowerItemGeneratorTests : DurationTest
    {
        [Inject]
        public IPowerItemGenerator PowerItemGenerator { get; set; }

        private String power;

        [SetUp]
        public void Setup()
        {
            power = GetNewPower();
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void PowerItemGeneratorDuration()
        {
            PowerItemGenerator.GenerateAtPower(power);
            AssertDuration();
        }
    }
}