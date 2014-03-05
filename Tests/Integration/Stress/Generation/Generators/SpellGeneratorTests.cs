using System;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class SpellGeneratorTests : StressTests
    {
        [Inject]
        public ISpellGenerator SpellGenerator { get; set; }

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
        public void StressedSpellGeneratorSpellType()
        {
            while (TestShouldKeepRunning())
            {
                var spellType = SpellGenerator.GenerateType();
                Assert.That(spellType, Is.Not.Empty);
            }

            AssertIterations();
        }

        [Test]
        public void StressedSpellGeneratorSpell()
        {
            while (TestShouldKeepRunning())
            {
                var spellType = SpellGenerator.GenerateType();
                var level = Random.Next(9) + 1;
                var spell = SpellGenerator.GenerateOfTypeAtLevel(spellType, level);

                Assert.That(spell, Is.Not.Empty);
            }

            AssertIterations();
        }
    }
}