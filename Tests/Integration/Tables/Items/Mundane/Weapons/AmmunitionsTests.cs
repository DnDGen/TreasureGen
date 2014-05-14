using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Weapons
{
    [TestFixture]
    public class AmmunitionsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Ammunitions"; }
        }

        [TestCase(WeaponConstants.Arrow, 1, 50)]
        [TestCase(WeaponConstants.CrossbowBolt, 51, 80)]
        [TestCase(WeaponConstants.SlingBullet, 81, 100)]
        public void Percentile(String name, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},1d50", name);
            AssertPercentile(content, lower, upper);
        }
    }
}