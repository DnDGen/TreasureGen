﻿using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture, TypesFilename("SpecialMaterials.xml")]
    public class SpecialMaterialsTests : TypesTest
    {
        [Test]
        public void AdamantineTypes()
        {
            var types = new[] { ItemsConstants.Gear.Types.Metal };
            AssertContent(ItemsConstants.Gear.Traits.Adamantine, types);
        }

        [Test]
        public void DragonhideTypes()
        {
            var types = new[] { ItemsConstants.ItemTypes.Armor };
            AssertContent(ItemsConstants.Gear.Traits.Dragonhide, types);
        }

        [Test]
        public void ColdIronTypes()
        {
            var types = new[] { ItemsConstants.Gear.Types.Metal, ItemsConstants.ItemTypes.Weapon };
            AssertContent(ItemsConstants.Gear.Traits.ColdIron, types);
        }

        [Test]
        public void MithralTypes()
        {
            var types = new[] { ItemsConstants.Gear.Types.Metal };
            AssertContent(ItemsConstants.Gear.Traits.Mithral, types);
        }

        [Test]
        public void AlchemicalSilverTypes()
        {
            var types = new[] { ItemsConstants.Gear.Types.Metal, ItemsConstants.ItemTypes.Weapon };
            AssertContent(ItemsConstants.Gear.Traits.AlchemicalSilver, types);
        }

        [Test]
        public void DarkwoodTypes()
        {
            var types = new[] { ItemsConstants.Gear.Types.Wood };
            AssertContent(ItemsConstants.Gear.Traits.Darkwood, types);
        }
    }
}