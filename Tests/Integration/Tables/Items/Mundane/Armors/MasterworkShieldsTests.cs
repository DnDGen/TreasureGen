using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Armors
{
    [TestFixture]
    public class MasterworkShieldsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Percentiles.Set.MasterworkShields; }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(ArmorConstants.Buckler, 1, 17)]
        [TestCase(ArmorConstants.LightWoodenShield, 18, 40)]
        [TestCase(ArmorConstants.LightSteelShield, 41, 60)]
        [TestCase(ArmorConstants.HeavyWoodenShield, 61, 83)]
        [TestCase(ArmorConstants.HeavySteelShield, 84, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}