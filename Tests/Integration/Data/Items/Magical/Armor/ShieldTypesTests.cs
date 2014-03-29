using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor
{
    [TestFixture]
    public class ShieldTypesTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "ShieldTypes";
        }

        [TestCase(ArmorConstants.Buckler, 1, 10)]
        [TestCase(ArmorConstants.LightWoodenShield, 11, 15)]
        [TestCase(ArmorConstants.LightSteelShield, 16, 20)]
        [TestCase(ArmorConstants.HeavyWoodenShield, 21, 30)]
        [TestCase(ArmorConstants.HeavySteelShield, 31, 95)]
        [TestCase(ArmorConstants.TowerShield, 96, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}