using NUnit.Framework;
using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Integration.Tables.Items.Mundane.Weapons
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
        [TestCase(AttributeConstants.Thrown,
            WeaponConstants.Dart,
            WeaponConstants.Javelin,
            WeaponConstants.JavelinOfLightning,
            WeaponConstants.Shuriken,
            WeaponConstants.ThrowingAxe)]
        public override void Attributes(String name, params String[] attributes)
        {
            base.Attributes(name, attributes);
        }
    }
}