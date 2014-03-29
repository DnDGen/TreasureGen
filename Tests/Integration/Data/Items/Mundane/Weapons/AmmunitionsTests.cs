using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Weapons
{
    [TestFixture]
    public class AmmunitionsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Ammunitions";
        }

        [Test]
        public void ArrowPercentile()
        {
            var content = String.Format("{0},1d50", WeaponConstants.Arrow);
            AssertPercentile(content, 1, 50);
        }

        [Test]
        public void CrossbowBoltPercentile()
        {
            var content = String.Format("{0},1d50", WeaponConstants.CrossbowBolt);
            AssertPercentile(content, 51, 80);
        }

        [Test]
        public void SlingBulletPercentile()
        {
            var content = String.Format("{0},1d50", WeaponConstants.SlingBullet);
            AssertPercentile(content, 81, 100);
        }
    }
}