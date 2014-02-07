using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture, PercentileTable("Ammunition")]
    public class AmmunitionTests : PercentileTests
    {
        [Test]
        public void ArrowPercentile()
        {
            var content = String.Format("{0},1d50", WeaponConstants.Arrow);
            AssertContent(content, 1, 50);
        }

        [Test]
        public void CrossbowBoltPercentile()
        {
            var content = String.Format("{0},1d50", WeaponConstants.CrossbowBolt);
            AssertContent(content, 51, 80);
        }

        [Test]
        public void SlingBulletPercentile()
        {
            var content = String.Format("{0},1d50", WeaponConstants.SlingBullet);
            AssertContent(content, 81, 100);
        }
    }
}