using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture, TypesTable("AmmunitionTypes")]
    public class AmmunitionTypesTests : TypesTest
    {
        [Test]
        public void ArrowTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Common,
                TypeConstants.Ranged,
                TypeConstants.Ammunition,
                TypeConstants.Metal, 
                TypeConstants.Wood,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Arrow, types);
        }

        [Test]
        public void CrossbowBoltTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Common, 
                TypeConstants.Ranged, 
                TypeConstants.Ammunition, 
                TypeConstants.Metal,
                TypeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CrossbowBolt, types);
        }

        [Test]
        public void SlingBulletTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                TypeConstants.Common, 
                TypeConstants.Ranged, 
                TypeConstants.Ammunition,
                TypeConstants.Metal,
                TypeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.SlingBullet, types);
        }
    }
}