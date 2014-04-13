using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane
{
    [TestFixture]
    public class SpecialMaterialsTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "SpecialMaterials"; }
        }

        [TestCase(TraitConstants.Adamantine, AttributeConstants.Metal)]
        [TestCase(TraitConstants.Dragonhide, ItemTypeConstants.Armor)]
        [TestCase(TraitConstants.ColdIron, AttributeConstants.Metal,
                                           ItemTypeConstants.Weapon)]
        [TestCase(TraitConstants.Mithral, AttributeConstants.Metal)]
        [TestCase(TraitConstants.AlchemicalSilver, AttributeConstants.Metal,
                                                   ItemTypeConstants.Weapon)]
        [TestCase(TraitConstants.Darkwood, AttributeConstants.Wood)]
        [TestCase("SpecialMaterials", TraitConstants.Mithral,
                                      TraitConstants.Adamantine,
                                      TraitConstants.AlchemicalSilver,
                                      TraitConstants.Darkwood,
                                      TraitConstants.ColdIron,
                                      TraitConstants.Dragonhide)]
        public void Attributes(String name, params String[] attributes)
        {
            AssertAttributes(name, attributes);
        }
    }
}