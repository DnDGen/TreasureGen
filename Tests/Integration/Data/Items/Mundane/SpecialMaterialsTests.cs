using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane
{
    [TestFixture]
    public class SpecialMaterialsTests : AttributesTests
    {
        protected override String GetTableName()
        {
            return "SpecialMaterials";
        }

        [Test]
        public void AdamantineAttributes()
        {
            var attributes = new[] { AttributeConstants.Metal };
            AssertContent(TraitConstants.Adamantine, attributes);
        }

        [Test]
        public void DragonhideAttributes()
        {
            var attributes = new[] { ItemTypeConstants.Armor };
            AssertContent(TraitConstants.Dragonhide, attributes);
        }

        [Test]
        public void ColdIronAttributes()
        {
            var attributes = new[] { AttributeConstants.Metal, ItemTypeConstants.Weapon };
            AssertContent(TraitConstants.ColdIron, attributes);
        }

        [Test]
        public void MithralAttributes()
        {
            var attributes = new[] { AttributeConstants.Metal };
            AssertContent(TraitConstants.Mithral, attributes);
        }

        [Test]
        public void AlchemicalSilverAttributes()
        {
            var attributes = new[] { AttributeConstants.Metal, ItemTypeConstants.Weapon };
            AssertContent(TraitConstants.AlchemicalSilver, attributes);
        }

        [Test]
        public void DarkwoodAttributes()
        {
            var attributes = new[] { AttributeConstants.Wood };
            AssertContent(TraitConstants.Darkwood, attributes);
        }

        [Test]
        public void SpecialMaterialAttributes()
        {
            var attributes = new[]
            {
                TraitConstants.Mithral,
                TraitConstants.Adamantine,
                TraitConstants.AlchemicalSilver,
                TraitConstants.Darkwood,
                TraitConstants.ColdIron,
                TraitConstants.Dragonhide
            };

            AssertContent("SpecialMaterials", attributes);
        }
    }
}