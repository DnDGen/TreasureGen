using System;
using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture]
    public class AmmunitionTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "Ammunition";
        }

        [Test]
        public void ArrowPercentile()
        {
            var content = String.Format("{0},1d50", ItemsConstants.Gear.Weapons.Arrow);
            AssertContent(content, 1, 50);
        }

        [Test]
        public void CrossbowBoltPercentile()
        {
            var content = String.Format("{0},1d50", ItemsConstants.Gear.Weapons.CrossbowBolt);
            AssertContent(content, 51, 80);
        }

        [Test]
        public void SlingBulletPercentile()
        {
            var content = String.Format("{0},1d50", ItemsConstants.Gear.Weapons.SlingBullet);
            AssertContent(content, 81, 100);
        }
    }
}