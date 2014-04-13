using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Weapons
{
    [TestFixture]
    public class MundaneWeaponsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MundaneWeapons"; }
        }

        [TestCase("CommonMelee", 1, 50)]
        [TestCase("Uncommon", 51, 70)]
        [TestCase("CommonRanged", 71, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}