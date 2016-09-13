using NUnit.Framework;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Tables.Items.Mundane
{
    [TestFixture]
    public class SpecialMaterialsTests : CollectionsTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Collections.Set.SpecialMaterials; }
        }

        [TestCase(TraitConstants.SpecialMaterials.Adamantine, AttributeConstants.Metal)]
        [TestCase(TraitConstants.SpecialMaterials.Dragonhide, ItemTypeConstants.Armor)]
        [TestCase(TraitConstants.SpecialMaterials.ColdIron, AttributeConstants.Metal, ItemTypeConstants.Weapon)]
        [TestCase(TraitConstants.SpecialMaterials.Mithral, AttributeConstants.Metal)]
        [TestCase(TraitConstants.SpecialMaterials.AlchemicalSilver, AttributeConstants.Metal, ItemTypeConstants.Weapon)]
        [TestCase(TraitConstants.SpecialMaterials.Darkwood, AttributeConstants.Wood)]
        public override void Collections(string name, params string[] attributes)
        {
            base.Collections(name, attributes);
        }
    }
}