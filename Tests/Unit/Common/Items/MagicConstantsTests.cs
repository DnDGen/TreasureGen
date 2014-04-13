using System;
using System.Collections.Generic;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Common.Items
{
    [TestFixture]
    public class MagicConstantsTests
    {
        private IEnumerable<String> names;

        [SetUp]
        public void Setup()
        {
            names = Enum.GetNames(typeof(Magic));
        }

        [TestCase("Bonus")]
        [TestCase("Abilities")]
        [TestCase("Charges")]
        [TestCase("Intelligence")]
        [TestCase("Curse")]
        [TestCase("IsMagical")]
        public void MagicEnumerationContains(String name)
        {
            Assert.That(names, Contains.Item(name));
        }
    }
}