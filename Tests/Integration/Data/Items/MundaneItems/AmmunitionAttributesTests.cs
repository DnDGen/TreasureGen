using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MundaneItems
{
    [TestFixture, AttributesTable("AmmunitionAttributes")]
    public class AmmunitionAttributesTests : AttributesTests
    {
        [Test]
        public void ArrowTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common,
                AttributeConstants.Ranged,
                AttributeConstants.Ammunition,
                AttributeConstants.Metal, 
                AttributeConstants.Wood,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Arrow, types);
        }

        [Test]
        public void CrossbowBoltTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged, 
                AttributeConstants.Ammunition, 
                AttributeConstants.Metal,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CrossbowBolt, types);
        }

        [Test]
        public void SlingBulletTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged, 
                AttributeConstants.Ammunition,
                AttributeConstants.Metal,
                AttributeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.SlingBullet, types);
        }
    }
}