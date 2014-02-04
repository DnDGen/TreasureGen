using System;
using System.Collections.Generic;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Generators
{
    [TestFixture]
    public class SpecialAbilitiesGeneratorTests : DurationTest
    {
        [Inject]
        public ISpecialAbilitiesGenerator SpecialAbilitiesGenerator { get; set; }

        private IEnumerable<String> types;
        private String power;
        private Int32 bonus;
        private Int32 quantity;

        [SetUp]
        public void Setup()
        {
            types = GetNewTypes(true);
            power = GetNewPower(false);
            bonus = Random.Next(5) + 1;
            quantity = Random.Next(10) + 1;

            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void SpecialAbilitiesGeneratorMultipleDuration()
        {
            SpecialAbilitiesGenerator.GenerateFor(types, power, bonus, quantity);
            AssertDuration();
        }

        [Test]
        public void SpecialAbilitiesGeneratorSingleDuration()
        {
            SpecialAbilitiesGenerator.GenerateFor(types, power);
            AssertDuration();
        }
    }
}