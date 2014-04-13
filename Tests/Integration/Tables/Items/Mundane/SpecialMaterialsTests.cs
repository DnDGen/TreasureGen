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
            get { return "GemDescriptions"; }
        }

        protected override String GetTableName()
        {
            return "SpecialMaterials";
        }

        [Test]
        public void AdamantineAttributes()
        {
            var attributes = new[] { AttributeConstants.Metal };
            AssertAttributes(TraitConstants.Adamantine, attributes);
        }

        [Test]
        public void DragonhideAttributes()
        {
            var attributes = new[] { ItemTypeConstants.Armor };
            AssertAttributes(TraitConstants.Dragonhide, attributes);
        }

        [Test]
        public void ColdIronAttributes()
        {
            var attributes = new[] { AttributeConstants.Metal, ItemTypeConstants.Weapon };
            AssertAttributes(TraitConstants.ColdIron, attributes);
        }

        [Test]
        public void MithralAttributes()
        {
            var attributes = new[] { AttributeConstants.Metal };
            AssertAttributes(TraitConstants.Mithral, attributes);
        }

        [Test]
        public void AlchemicalSilverAttributes()
        {
            var attributes = new[] { AttributeConstants.Metal, ItemTypeConstants.Weapon };
            AssertAttributes(TraitConstants.AlchemicalSilver, attributes);
        }

        [Test]
        public void DarkwoodAttributes()
        {
            var attributes = new[] { AttributeConstants.Wood };
            AssertAttributes(TraitConstants.Darkwood, attributes);
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

            AssertAttributes("SpecialMaterials", attributes);
        }
    }
}