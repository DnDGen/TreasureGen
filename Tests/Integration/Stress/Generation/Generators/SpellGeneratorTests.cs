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
        public void StressedSpellGeneratorSpellLevel()
        {
            while (TestShouldKeepRunning())
            {
                var power = GetNewPower(false);
                var level = SpellGenerator.GenerateLevel(power);
                Assert.That(level, Is.InRange<Int32>(0, 9));
            }

            AssertIterations();
        }

        [Test]
        public void StressedSpellGeneratorSpell()
        {
            while (TestShouldKeepRunning())
            {
                var spellType = SpellGenerator.GenerateType();
                var power = GetNewPower(false);
                var level = SpellGenerator.GenerateLevel(power);
                var spell = SpellGenerator.Generate(spellType, level);

                Assert.That(spell, Is.Not.Empty);
            }

            AssertIterations();
        }
    }
}