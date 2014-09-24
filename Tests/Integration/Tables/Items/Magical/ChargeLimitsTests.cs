using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical
{
    [TestFixture]
    public class ChargeLimitsTests : AttributesTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Attributes.Set.ChargeLimits; }
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
        [TestCase("Three wishes", 1, 3)]
        [TestCase("Necklace of fireballs type I", 1, 3)]
        [TestCase("Necklace of fireballs type II", 1, 5)]
        [TestCase("Necklace of fireballs type III", 1, 7)]
        [TestCase("Necklace of fireballs type IV", 1, 9)]
        [TestCase("Necklace of fireballs type V", 1, 7)]
        [TestCase("Necklace of fireballs type VI", 1, 9)]
        [TestCase("Necklace of fireballs type VII", 1, 9)]
        [TestCase("Robe of bones", 1, 12)]
        [TestCase("Rod of absorption", 1, 50)]
        [TestCase("Rod of absorption (max)", 50, 50)]
        [TestCase("Rod of rulership", 1, 500)]
        public void Attributes(String name, Int32 min, Int32 max)
        {
            var attributes = new[] { min.ToString(), max.ToString() };
            base.Attributes(name, attributes);
        }
    }
}