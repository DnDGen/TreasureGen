using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Weapons
{
    [TestFixture, AttributesTable("AmmunitionAttributes")]
    public class AmmunitionAttributesTests : AttributesTests
    {
        [Test]
        public void ArrowAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common,
                AttributeConstants.Ranged,
                AttributeConstants.Ammunition,
                AttributeConstants.Metal, 
                AttributeConstants.Wood,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.Arrow, attributes);
        }

        [Test]
        public void CrossbowBoltAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged, 
                AttributeConstants.Ammunition, 
                AttributeConstants.Metal,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(WeaponConstants.CrossbowBolt, attributes);
        }

        [Test]
        public void SlingBulletAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Weapon, 
                AttributeConstants.Common, 
                AttributeConstants.Ranged, 
                AttributeConstants.Ammunition,
                AttributeConstants.Metal,
                AttributeConstants.Bludgeoning
            };

            AssertContent(WeaponConstants.SlingBullet, attributes);
        }
    }
}