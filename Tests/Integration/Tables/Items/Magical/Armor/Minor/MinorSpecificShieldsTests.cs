using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Minor
{
    [TestFixture]
    public class MinorSpecificShieldsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MinorSpecificShields"; }
        }

        [TestCase(ArmorConstants.Buckler, 0, 1, 30)]
        [TestCase(ArmorConstants.HeavyWoodenShield, 0, 31, 80)]
        [TestCase(ArmorConstants.HeavySteelShield, 0, 81, 95)]
        [TestCase(ArmorConstants.CastersShield, 1, 96, 100)]
        public void Percentile(String shield, Int32 bonus, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", shield, bonus);
            AssertPercentile(content, lower, upper);
        }
    }
}