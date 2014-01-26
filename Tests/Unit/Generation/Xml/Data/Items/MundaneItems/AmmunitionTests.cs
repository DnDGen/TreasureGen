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
            AssertContent(ItemsConstants.Gear.Weapons.Arrow, 1, 50);
        }

        [Test]
        public void CrossbowBoltPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.CrossbowBolt, 51, 80);
        }

        [Test]
        public void SlingBulletPercentile()
        {
            AssertContent(ItemsConstants.Gear.Weapons.SlingBullet, 81, 100);
        }
    }
}