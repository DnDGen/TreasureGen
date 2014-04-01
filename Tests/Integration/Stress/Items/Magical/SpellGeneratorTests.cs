using System;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class SpellGeneratorTests : StressTests
    {
        [Inject]
        public ISpellGenerator SpellGenerator { get; set; }

        protected override void StressGenerator()
        {
            var spellType = SpellGenerator.GenerateType();
            Assert.That(spellType, Is.EqualTo("Arcane").Or.EqualTo("Divine"));

            var power = GetNewPower(false);
            var level = SpellGenerator.GenerateLevel(power);
            Assert.That(level, Is.InRange<Int32>(0, 9));

            var spell = SpellGenerator.Generate(spellType, level);
            Assert.That(spell, Is.Not.Empty);
        }
    }
}