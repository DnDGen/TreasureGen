using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
{
    [TestFixture]
    public class GearSpecialAbilitiesGeneratorTests
    {
        private IGearSpecialAbilitiesGenerator specialAbilitiesGenerator;

        private List<String> types;

        [SetUp]
        public void Setup()
        {
            types = new List<String>();
            specialAbilitiesGenerator = new GearSpecialAbilitiesGenerator();
        }

        [Test]
        public void SpecialAbilitiesGeneratorGeneratesSpecialAbilities()
        {
            var abilities = specialAbilitiesGenerator.GenerateFor(types, "power", 1, 1);
            Assert.That(abilities.Count(), Is.EqualTo(1));
        }
    }
}