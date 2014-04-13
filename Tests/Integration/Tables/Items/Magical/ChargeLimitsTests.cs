using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical
{
    [TestFixture]
    public class ChargeLimitsTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "ChargeLimits"; }
        }

        [TestCase("Bracelet of fiends", 1, 4)]
        [TestCase("Brooch of shielding", 1, 101)]
        [TestCase("Chime of opening", 1, 10)]
        [TestCase("Deck of illusions", 14, 33)] //90% of the time is full (34), 10% rolls here. See http://www.d20srd.org/srd/magicItems/wondrousItems.htm
        [TestCase("Gem of brightness", 1, 50)]
        [TestCase("Keoghtom's ointment", 1, 5)]
        [TestCase("Scarab of protection", 1, 12)]
        [TestCase("Ram", 1, 50)]
        [TestCase("Three wishes", 1, 3)]
        public void Attributes(String name, Int32 min, Int32 max)
        {
            var attributes = new[] { min.ToString(), max.ToString() };
            AssertAttributes(name, attributes);
        }
    }
}