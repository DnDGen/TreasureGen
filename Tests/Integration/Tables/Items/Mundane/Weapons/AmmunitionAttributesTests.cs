using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Weapons
{
    [TestFixture]
    public class AmmunitionAttributesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Attributes.Set.AmmunitionAttributes; }
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
        public override void Attributes(String name, params String[] attributes)
        {
            base.Attributes(name, attributes);
        }
    }
}