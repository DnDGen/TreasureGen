using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture, TypesTable("SpecialMaterials")]
    public class SpecialMaterialsTests : TypesTest
    {
        [Test]
        public void AdamantineTypes()
        {
            var types = new[] { TypeConstants.Metal };
            AssertContent(TraitConstants.Adamantine, types);
        }

        [Test]
        public void DragonhideTypes()
        {
            var types = new[] { ItemTypeConstants.Armor };
            AssertContent(TraitConstants.Dragonhide, types);
        }

        [Test]
        public void ColdIronTypes()
        {
            var types = new[] { TypeConstants.Metal, ItemTypeConstants.Weapon };
            AssertContent(TraitConstants.ColdIron, types);
        }

        [Test]
        public void MithralTypes()
        {
            var types = new[] { TypeConstants.Metal };
            AssertContent(TraitConstants.Mithral, types);
        }

        [Test]
        public void AlchemicalSilverTypes()
        {
            var types = new[] { TypeConstants.Metal, ItemTypeConstants.Weapon };
            AssertContent(TraitConstants.AlchemicalSilver, types);
        }

        [Test]
        public void DarkwoodTypes()
        {
            var types = new[] { TypeConstants.Wood };
            AssertContent(TraitConstants.Darkwood, types);
        }

        [Test]
        public void SpecialMaterialTypes()
        {
            var types = new[]
            {
                TraitConstants.Mithral,
                TraitConstants.Adamantine,
                TraitConstants.AlchemicalSilver,
                TraitConstants.Darkwood,
                TraitConstants.ColdIron,
                TraitConstants.Dragonhide
                
            };

            AssertContent("SpecialMaterials", types);
        }
    }
}