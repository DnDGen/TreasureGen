using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Armors
{
    [TestFixture, PercentileTable("MasterworkShields")]
    public class MasterworkShieldsTests : PercentileTests
    {
        [TestCase(ArmorConstants.Buckler, 1, 17)]
        [TestCase(ArmorConstants.LightWoodenShield, 18, 40)]
        [TestCase(ArmorConstants.LightSteelShield, 41, 60)]
        [TestCase(ArmorConstants.HeavyWoodenShield, 61, 83)]
        [TestCase(ArmorConstants.HeavySteelShield, 84, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}