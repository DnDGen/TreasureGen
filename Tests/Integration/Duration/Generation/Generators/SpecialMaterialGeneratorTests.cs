using System;
using System.Collections.Generic;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Generators
{
    [TestFixture]
    public class SpecialMaterialGeneratorTests : DurationTest
    {
        [Inject]
        public ISpecialMaterialGenerator SpecialMaterialGenerator { get; set; }

        private IEnumerable<String> types;

        [SetUp]
        public void Setup()
        {
            types = GetNewTypes(false);
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void SpecialMaterialGeneratorDuration()
        {
            SpecialMaterialGenerator.GenerateFor(types);
            AssertDuration();
        }
    }
}