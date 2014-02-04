using System;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration
{
    [TestFixture]
    public class SpellGeneratorTests : DurationTest
    {
        [Inject]
        public ISpellGenerator SpellGenerator { get; set; }

        private String spellType;
        private Int32 level;

        [SetUp]
        public void Setup()
        {
            spellType = SpellGenerator.GenerateType();
            level = Random.Next(9) + 1;

            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void SpellGeneratorSpellTypeDuration()
        {
            SpellGenerator.GenerateType();
            AssertDuration();
        }

        [Test]
        public void SpellGeneratorSpellDuration()
        {
            SpellGenerator.GenerateOfTypeAtLevel(spellType, level);
            AssertDuration();
        }
    }
}