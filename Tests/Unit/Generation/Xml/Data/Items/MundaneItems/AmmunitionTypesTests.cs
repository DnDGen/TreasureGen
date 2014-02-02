using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture, TypesTableName("AmmunitionTypes")]
    public class AmmunitionTypesTests : TypesTest
    {
        [Test]
        public void ArrowGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common,
                ItemsConstants.Gear.Types.Ranged,
                ItemsConstants.Gear.Types.Ammunition,
                ItemsConstants.Gear.Types.Metal, 
                ItemsConstants.Gear.Types.Wood 
            };

            AssertContent(ItemsConstants.Gear.Weapons.Arrow, types);
        }

        [Test]
        public void CrossbowBoltGearTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Ammunition, 
                ItemsConstants.Gear.Types.Metal 
            };

            AssertContent(ItemsConstants.Gear.Weapons.CrossbowBolt, types);
        }

        [Test]
        public void SlingBulletGearTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Weapon, 
                ItemsConstants.Gear.Types.Common, 
                ItemsConstants.Gear.Types.Ranged, 
                ItemsConstants.Gear.Types.Ammunition,
                ItemsConstants.Gear.Types.Metal 
            };

            AssertContent(ItemsConstants.Gear.Weapons.SlingBullet, types);
        }
    }
}