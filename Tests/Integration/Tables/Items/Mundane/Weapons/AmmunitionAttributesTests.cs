using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Weapons
{
    [TestFixture]
    public class AmmunitionAttributesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "AmmunitionAttributes"; }
        }

        [TestCase(WeaponConstants.Arrow, ItemTypeConstants.Weapon,
                                         AttributeConstants.Common,
                                         AttributeConstants.Ranged,
                                         AttributeConstants.Ammunition,
                                         AttributeConstants.Metal,
                                         AttributeConstants.Wood,
                                         AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.CrossbowBolt, ItemTypeConstants.Weapon,
                                                AttributeConstants.Common,
                                                AttributeConstants.Ranged,
                                                AttributeConstants.Ammunition,
                                                AttributeConstants.Metal,
                                                AttributeConstants.NotBludgeoning)]
        [TestCase(WeaponConstants.SlingBullet, ItemTypeConstants.Weapon,
                                               AttributeConstants.Common,
                                               AttributeConstants.Ranged,
                                               AttributeConstants.Ammunition,
                                               AttributeConstants.Metal,
                                               AttributeConstants.Bludgeoning)]
        public void Attributes(String name, params String[] attributes)
        {
            AssertAttributes(name, attributes);
        }
    }
}