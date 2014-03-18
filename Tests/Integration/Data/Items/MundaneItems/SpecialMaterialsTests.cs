using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MundaneItems
{
    [TestFixture, AttributesTable("SpecialMaterials")]
    public class SpecialMaterialsTests : AttributesTests
    {
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