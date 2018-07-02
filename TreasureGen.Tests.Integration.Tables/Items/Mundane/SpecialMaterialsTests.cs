using NUnit.Framework;
using TreasureGen.Tables;
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
        [TestCase(TraitConstants.SpecialMaterials.AlchemicalSilver,
            AttributeConstants.Metal,
            ItemTypeConstants.Weapon)]
        [TestCase(TraitConstants.SpecialMaterials.ColdIron,
            AttributeConstants.Metal,
            ItemTypeConstants.Weapon)]
        [TestCase(TraitConstants.SpecialMaterials.Darkwood, AttributeConstants.Wood)]
        [TestCase(TraitConstants.SpecialMaterials.Dragonhide, ItemTypeConstants.Armor)]
        [TestCase(TraitConstants.SpecialMaterials.Mithral, AttributeConstants.Metal)]
        [TestCase(TraitConstants.Masterwork,
            TraitConstants.SpecialMaterials.Adamantine,
            TraitConstants.SpecialMaterials.Darkwood,
            TraitConstants.SpecialMaterials.Dragonhide,
            TraitConstants.SpecialMaterials.Mithral)]
        public override void Collections(string name, params string[] attributes)
        {
            base.Collections(name, attributes);
        }

        [Test]
        public void TableContainsAllSpecialMaterials()
        {
            var materials = TraitConstants.SpecialMaterials.All();
            var table = CollectionMapper.Map(tableName);
            Assert.That(table.Keys, Is.SupersetOf(materials));
        }
    }
}