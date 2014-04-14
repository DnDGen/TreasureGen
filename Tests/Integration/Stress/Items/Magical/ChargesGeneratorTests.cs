using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Mappers.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class ChargesGeneratorTests : StressTests
    {
        [Inject]
        public IChargesGenerator ChargesGenerator { get; set; }
        [Inject]
        public IAttributesMapper AttributesMapper { get; set; }

        private Dictionary<String, IEnumerable<String>> table;

        [Test]
        public void StressedChargesGenerator()
        {
            table = AttributesMapper.Map("ChargeLimits");
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var charges = ChargesGenerator.GenerateFor(ItemTypeConstants.Wand, String.Empty);
            Assert.That(charges, Is.InRange<Int32>(1, 50));

            charges = ChargesGenerator.GenerateFor(ItemTypeConstants.Staff, String.Empty);
            Assert.That(charges, Is.InRange<Int32>(1, 50));

            var name = GetRandomName();
            charges = ChargesGenerator.GenerateFor(String.Empty, name);
            var min = Convert.ToInt32(table[name].First());
            var max = Convert.ToInt32(table[name].Last());

            if (name == "Deck of illusions")
                max = 34;

            Assert.That(charges, Is.InRange<Int32>(min, max));
        }

        private String GetRandomName()
        {
            var index = Random.Next(table.Count);
            return table.Keys.ElementAt(index);
        }
    }
}