using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture]
    public class SpecialMaterialsTests : TypesTest
    {
        [SetUp]
        public void Setup()
        {
            filename = "SpecialMaterials.xml";
        }

        [Test]
        public void AdamantineTypes()
        {
            AssertContent(ItemsConstants.Gear.Traits.Adamantine, ItemsConstants.Gear.Types.Metal);
        }

        [Test]
        public void DragonhideTypes()
        {
            AssertContent(ItemsConstants.Gear.Traits.Dragonhide, ItemsConstants.ItemTypes.Armor);
        }

        [Test]
        public void ColdIronTypes()
        {
            AssertContent(ItemsConstants.Gear.Traits.ColdIron, ItemsConstants.Gear.Types.Metal, ItemsConstants.ItemTypes.Weapon);
        }

        [Test]
        public void MithralTypes()
        {
            AssertContent(ItemsConstants.Gear.Traits.Mithral, ItemsConstants.Gear.Types.Metal);
        }

        [Test]
        public void AlchemicalSilverTypes()
        {
            AssertContent(ItemsConstants.Gear.Traits.AlchemicalSilver, ItemsConstants.Gear.Types.Metal, ItemsConstants.ItemTypes.Weapon);
        }

        [Test]
        public void DarkwoodTypes()
        {
            AssertContent(ItemsConstants.Gear.Traits.Darkwood, ItemsConstants.Gear.Types.Wood);
        }
    }
}