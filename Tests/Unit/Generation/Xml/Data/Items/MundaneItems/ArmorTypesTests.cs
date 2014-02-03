using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture, TypesTable("ArmorTypes")]
    public class ArmorTypesTests : TypesTest
    {
        [Test]
        public void BucklerTypes()
        {
            var types = new[] 
            { 
                ItemsConstants.ItemTypes.Armor, 
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Armor.Buckler, types);
        }

        [Test]
        public void LightWoodenShieldTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Armor.LightWoodenShield, types);
        }

        [Test]
        public void LightSteelShieldTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Armor, 
                ItemsConstants.Gear.Types.Metal 
            };

            AssertContent(ItemsConstants.Gear.Armor.LightSteelShield, types);
        }

        [Test]
        public void HeavyWoodenShieldTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Armor.HeavyWoodenShield, types);
        }

        [Test]
        public void HeavySteelShieldTypes()
        {
            var types = new[]
            { 
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Armor.HeavySteelShield, types);
        }

        [Test]
        public void TowerShieldTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor, 
                ItemsConstants.Gear.Types.Wood
            };

            AssertContent(ItemsConstants.Gear.Armor.TowerShield, types);
        }

        [Test]
        public void PaddedArmorTypes()
        {
            var types = new[]
            { 
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent(ItemsConstants.Gear.Armor.PaddedArmor, types);
        }

        [Test]
        public void LeatherArmorTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent(ItemsConstants.Gear.Armor.LeatherArmor, types);
        }

        [Test]
        public void StuddedLeatherArmorTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Armor, 
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Armor.StuddedLeatherArmor, types);
        }

        [Test]
        public void ChainShirtTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Armor.ChainShirt, types);
        }

        [Test]
        public void HideArmorTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent(ItemsConstants.Gear.Armor.HideArmor, types);
        }

        [Test]
        public void ScaleMailTypes()
        {
            var types = new[] 
            { 
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Armor.ScaleMail, types);
        }

        [Test]
        public void ChainmailTypes()
        {
            var types = new[]
            { 
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Armor.Chainmail, types);
        }

        [Test]
        public void BreastplateTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Armor, 
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Armor.Breastplate, types);
        }

        [Test]
        public void SplintMailTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Metal 
            };

            AssertContent(ItemsConstants.Gear.Armor.SplintMail, types);
        }

        [Test]
        public void BandedMailTypes()
        {
            var types = new[] 
            {
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Armor.BandedMail, types);
        }

        [Test]
        public void HalfPlateTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Armor.HalfPlate, types);
        }

        [Test]
        public void FullPlateTypes()
        {
            var types = new[] 
            { 
                ItemsConstants.ItemTypes.Armor, 
                ItemsConstants.Gear.Types.Metal
            };

            AssertContent(ItemsConstants.Gear.Armor.FullPlate, types);
        }
    }
}