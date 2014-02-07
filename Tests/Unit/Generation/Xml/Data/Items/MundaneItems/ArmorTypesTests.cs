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
                ItemTypeConstants.Armor, 
                TypeConstants.Wood
            };

            AssertContent(ArmorConstants.Buckler, types);
        }

        [Test]
        public void LightWoodenShieldTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Armor,
                TypeConstants.Wood
            };

            AssertContent(ArmorConstants.LightWoodenShield, types);
        }

        [Test]
        public void LightSteelShieldTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Armor, 
                TypeConstants.Metal 
            };

            AssertContent(ArmorConstants.LightSteelShield, types);
        }

        [Test]
        public void HeavyWoodenShieldTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor,
                TypeConstants.Wood
            };

            AssertContent(ArmorConstants.HeavyWoodenShield, types);
        }

        [Test]
        public void HeavySteelShieldTypes()
        {
            var types = new[]
            { 
                ItemTypeConstants.Armor,
                TypeConstants.Metal
            };

            AssertContent(ArmorConstants.HeavySteelShield, types);
        }

        [Test]
        public void TowerShieldTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor, 
                TypeConstants.Wood
            };

            AssertContent(ArmorConstants.TowerShield, types);
        }

        [Test]
        public void PaddedArmorTypes()
        {
            var types = new[]
            { 
                ItemTypeConstants.Armor
            };

            AssertContent(ArmorConstants.PaddedArmor, types);
        }

        [Test]
        public void LeatherArmorTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(ArmorConstants.LeatherArmor, types);
        }

        [Test]
        public void StuddedLeatherArmorTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Armor, 
                TypeConstants.Metal
            };

            AssertContent(ArmorConstants.StuddedLeatherArmor, types);
        }

        [Test]
        public void ChainShirtTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Armor,
                TypeConstants.Metal
            };

            AssertContent(ArmorConstants.ChainShirt, types);
        }

        [Test]
        public void HideArmorTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Armor
            };

            AssertContent(ArmorConstants.HideArmor, types);
        }

        [Test]
        public void ScaleMailTypes()
        {
            var types = new[] 
            { 
                ItemTypeConstants.Armor,
                TypeConstants.Metal
            };

            AssertContent(ArmorConstants.ScaleMail, types);
        }

        [Test]
        public void ChainmailTypes()
        {
            var types = new[]
            { 
                ItemTypeConstants.Armor,
                TypeConstants.Metal
            };

            AssertContent(ArmorConstants.Chainmail, types);
        }

        [Test]
        public void BreastplateTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Armor, 
                TypeConstants.Metal
            };

            AssertContent(ArmorConstants.Breastplate, types);
        }

        [Test]
        public void SplintMailTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor,
                TypeConstants.Metal 
            };

            AssertContent(ArmorConstants.SplintMail, types);
        }

        [Test]
        public void BandedMailTypes()
        {
            var types = new[] 
            {
                ItemTypeConstants.Armor,
                TypeConstants.Metal
            };

            AssertContent(ArmorConstants.BandedMail, types);
        }

        [Test]
        public void HalfPlateTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor,
                TypeConstants.Metal
            };

            AssertContent(ArmorConstants.HalfPlate, types);
        }

        [Test]
        public void FullPlateTypes()
        {
            var types = new[] 
            { 
                ItemTypeConstants.Armor, 
                TypeConstants.Metal
            };

            AssertContent(ArmorConstants.FullPlate, types);
        }
    }
}