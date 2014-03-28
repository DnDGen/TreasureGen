using System;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Weapons
{
    [TestFixture, PercentileTable("MundaneWeapons")]
    public class MundaneWeaponsTests : PercentileTests
    {
        [TestCase("CommonMelee", 1, 50)]
        [TestCase("Uncommon", 51, 70)]
        [TestCase("CommonRanged", 71, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}