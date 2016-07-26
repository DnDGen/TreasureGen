using System;
using TreasureGen.Items;
using TreasureGen.Domain.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Mundane
{
    [TestFixture]
    public class SpecialMaterialsTests : CollectionsTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Collections.Set.SpecialMaterials; }
        }

        [TestCase(TraitConstants.Adamantine, AttributeConstants.Metal)]
        [TestCase(TraitConstants.Dragonhide, ItemTypeConstants.Armor)]
        [TestCase(TraitConstants.ColdIron, AttributeConstants.Metal,
                                           ItemTypeConstants.Weapon)]
        [TestCase(TraitConstants.Mithral, AttributeConstants.Metal)]
        [TestCase(TraitConstants.AlchemicalSilver, AttributeConstants.Metal,
                                                   ItemTypeConstants.Weapon)]
        [TestCase(TraitConstants.Darkwood, AttributeConstants.Wood)]
        public override void Collections(String name, params String[] attributes)
        {
            base.Collections(name, attributes);
        }
    }
}