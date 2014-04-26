using System;
using EquipmentGen.Common.Items;
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

        [TestCase("Bracelet of friends", 1, 4)]
        [TestCase("Brooch of shielding", 1, 101)]
        [TestCase("Chime of opening", 1, 10)]
        [TestCase("Deck of illusions", 14, 33)]
        [TestCase("Gem of brightness", 1, 50)]
        [TestCase("Keoghtom's ointment", 1, 5)]
        [TestCase("Scarab of protection", 1, 12)]
        [TestCase("Ram", 1, 50)]
        [TestCase(WeaponConstants.LuckBlade0, 0, 0)]
        [TestCase(WeaponConstants.LuckBlade1, 1, 1)]
        [TestCase(WeaponConstants.LuckBlade2, 2, 2)]
        [TestCase(WeaponConstants.LuckBlade3, 3, 3)]
        [TestCase(WeaponConstants.LuckBlade, 0, 3)]
        [TestCase("Full deck of illusions", 34, 34)]
        public void Attributes(String name, Int32 min, Int32 max)
        {
            var attributes = new[] { min.ToString(), max.ToString() };
            AssertAttributes(name, attributes);
        }
    }
}