using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Armors
{
    [TestFixture, PercentileTable("DarkwoodShields")]
    public class DarkwoodShieldsTests : PercentileTests
    {
        [TestCase(ArmorConstants.DarkwoodBuckler, 1, 50)]
        [TestCase(ArmorConstants.DarkwoodShield, 51, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}