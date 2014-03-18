using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items
{
    [TestFixture, AttributesTable("ArmorAttributes")]
    public class ArmorAttributesTests : AttributesTests
    {
        [Test]
        public void BucklerAttributes()
        {
            var attributes = new[] 
            { 
                ItemTypeConstants.Armor, 
                AttributeConstants.Wood
            };

            AssertContent(ArmorConstants.Buckler, attributes);
        }

        [Test]
        public void LightWoodenShieldAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Wood
            };

            AssertContent(ArmorConstants.LightWoodenShield, attributes);
        }

        [Test]
        public void LightSteelShieldAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Armor, 
                AttributeConstants.Metal 
            };

            AssertContent(ArmorConstants.LightSteelShield, attributes);
        }

        [Test]
        public void HeavyWoodenShieldAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Wood
            };

            AssertContent(ArmorConstants.HeavyWoodenShield, attributes);
        }

        [Test]
        public void HeavySteelShieldAttributes()
        {
            var attributes = new[]
            { 
                ItemTypeConstants.Armor,
                AttributeConstants.Metal
            };

            AssertContent(ArmorConstants.HeavySteelShield, attributes);
        }

        [Test]
        public void TowerShieldAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor, 
                AttributeConstants.Wood
            };

            AssertContent(ArmorConstants.TowerShield, attributes);
        }

        [Test]
        public void PaddedArmorAttributes()
        {
            var attributes = new[]
            { 
                ItemTypeConstants.Armor
            };

            AssertContent(ArmorConstants.PaddedArmor, attributes);
        }

        [Test]
        public void LeatherArmorAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(ArmorConstants.LeatherArmor, attributes);
        }

        [Test]
        public void StuddedLeatherArmorAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Armor, 
                AttributeConstants.Metal
            };

            AssertContent(ArmorConstants.StuddedLeatherArmor, attributes);
        }

        [Test]
        public void ChainShirtAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Metal
            };

            AssertContent(ArmorConstants.ChainShirt, attributes);
        }

        [Test]
        public void HideArmorAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Armor
            };

            AssertContent(ArmorConstants.HideArmor, attributes);
        }

        [Test]
        public void ScaleMailAttributes()
        {
            var attributes = new[] 
            { 
                ItemTypeConstants.Armor,
                AttributeConstants.Metal
            };

            AssertContent(ArmorConstants.ScaleMail, attributes);
        }

        [Test]
        public void ChainmailAttributes()
        {
            var attributes = new[]
            { 
                ItemTypeConstants.Armor,
                AttributeConstants.Metal
            };

            AssertContent(ArmorConstants.Chainmail, attributes);
        }

        [Test]
        public void BreastplateAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Armor, 
                AttributeConstants.Metal
            };

            AssertContent(ArmorConstants.Breastplate, attributes);
        }

        [Test]
        public void SplintMailAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Metal 
            };

            AssertContent(ArmorConstants.SplintMail, attributes);
        }

        [Test]
        public void BandedMailAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Metal
            };

            AssertContent(ArmorConstants.BandedMail, attributes);
        }

        [Test]
        public void HalfPlateAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Metal
            };

            AssertContent(ArmorConstants.HalfPlate, attributes);
        }

        [Test]
        public void FullPlateAttributes()
        {
            var attributes = new[] 
            { 
                ItemTypeConstants.Armor, 
                AttributeConstants.Metal
            };

            AssertContent(ArmorConstants.FullPlate, attributes);
        }
    }
}