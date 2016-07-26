using NUnit.Framework;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Tables.Items.Mundane.Weapons
{
    [TestFixture]
    public class AmmunitionAttributesTests : CollectionsTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Collections.Set.AmmunitionAttributes; }
        }

        [TestCase(WeaponConstants.Arrow,
            ItemTypeConstants.Weapon,
            AttributeConstants.Common,
            AttributeConstants.Ranged,
            AttributeConstants.Ammunition,
            AttributeConstants.Metal,
            AttributeConstants.Wood,
            AttributeConstants.Piercing)]
        [TestCase(WeaponConstants.CrossbowBolt,
            ItemTypeConstants.Weapon,
            AttributeConstants.Common,
            AttributeConstants.Ranged,
            AttributeConstants.Ammunition,
            AttributeConstants.Metal,
            AttributeConstants.Piercing)]
        [TestCase(WeaponConstants.SlingBullet,
            ItemTypeConstants.Weapon,
            AttributeConstants.Common,
            AttributeConstants.Ranged,
            AttributeConstants.Ammunition,
            AttributeConstants.Metal,
            AttributeConstants.Bludgeoning)]
        public override void Collections(string name, params string[] attributes)
        {
            base.Collections(name, attributes);
        }
    }
}