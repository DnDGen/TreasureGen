using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Mundane
{
    [TestFixture]
    public class SpecialMaterialsTests : AttributesTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Attributes.Set.SpecialMaterials; }
        }

        [TestCase(TraitConstants.Adamantine, AttributeConstants.Metal)]
        [TestCase(TraitConstants.Dragonhide, ItemTypeConstants.Armor)]
        [TestCase(TraitConstants.ColdIron, AttributeConstants.Metal,
                                           ItemTypeConstants.Weapon)]
        [TestCase(TraitConstants.Mithral, AttributeConstants.Metal)]
        [TestCase(TraitConstants.AlchemicalSilver, AttributeConstants.Metal,
                                                   ItemTypeConstants.Weapon)]
        [TestCase(TraitConstants.Darkwood, AttributeConstants.Wood)]
        public override void Attributes(String name, params String[] attributes)
        {
            base.Attributes(name, attributes);
        }
    }
}