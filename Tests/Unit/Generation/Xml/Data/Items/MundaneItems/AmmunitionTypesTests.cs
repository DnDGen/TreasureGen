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
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Ranged,
                ItemsConstants.Gear.Types.Ammunition,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Wood,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.Arrow, types);
        }

        [Test]
        public void CrossbowBoltTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Ammunition, 
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.NotBludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.CrossbowBolt, types);
        }

        [Test]
        public void SlingBulletTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Ammunition,
                ItemsConstants.Gear.Types.Metal,
                ItemsConstants.Gear.Types.Bludgeoning
            };

            AssertContent(ItemsConstants.Gear.Weapons.SlingBullet, types);
        }
    }
}