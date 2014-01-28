﻿using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Generators
{
    [TestFixture]
    public class MundaneItemGeneratorTests : DurationTest
    {
        [Inject]
        public IMundaneItemGenerator MundaneItemGenerator { get; set; }

        [SetUp]
        public void Setup()
        {
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void MundaneItemGeneratorDuration()
        {
            MundaneItemGenerator.Generate();
            AssertDuration();
        }
    }
}