using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Armors
{
    [TestFixture]
    public class ArmorAttributesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "GemDescriptions"; }
        }

        protected override String GetTableName()
        {
            return "ArmorAttributes";
        }

        [Test]
        public void BucklerAttributes()
        {
            var attributes = new[] 
            { 
                ItemTypeConstants.Armor, 
                AttributeConstants.Wood,
                AttributeConstants.Shield
            };

            AssertAttributes(ArmorConstants.Buckler, attributes);
        }

        [Test]
        public void LightWoodenShieldAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Wood,
                AttributeConstants.Shield
            };

            AssertAttributes(ArmorConstants.LightWoodenShield, attributes);
        }

        [Test]
        public void LightSteelShieldAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Armor, 
                AttributeConstants.Metal,
                AttributeConstants.Shield
            };

            AssertAttributes(ArmorConstants.LightSteelShield, attributes);
        }

        [Test]
        public void HeavyWoodenShieldAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Wood,
                AttributeConstants.Shield
            };

            AssertAttributes(ArmorConstants.HeavyWoodenShield, attributes);
        }

        [Test]
        public void HeavySteelShieldAttributes()
        {
            var attributes = new[]
            { 
                ItemTypeConstants.Armor,
                AttributeConstants.Metal,
                AttributeConstants.Shield
            };

            AssertAttributes(ArmorConstants.HeavySteelShield, attributes);
        }

        [Test]
        public void TowerShieldAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor, 
                AttributeConstants.Wood,
                AttributeConstants.Shield
            };

            AssertAttributes(ArmorConstants.TowerShield, attributes);
        }

        [Test]
        public void PaddedArmorAttributes()
        {
            var attributes = new[]
            { 
                ItemTypeConstants.Armor
            };

            AssertAttributes(ArmorConstants.PaddedArmor, attributes);
        }

        [Test]
        public void LeatherArmorAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertAttributes(ArmorConstants.LeatherArmor, attributes);
        }

        [Test]
        public void StuddedLeatherArmorAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Armor, 
                AttributeConstants.Metal
            };

            AssertAttributes(ArmorConstants.StuddedLeatherArmor, attributes);
        }

        [Test]
        public void ChainShirtAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Metal
            };

            AssertAttributes(ArmorConstants.ChainShirt, attributes);
        }

        [Test]
        public void HideArmorAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Armor
            };

            AssertAttributes(ArmorConstants.HideArmor, attributes);
        }

        [Test]
        public void ScaleMailAttributes()
        {
            var attributes = new[] 
            { 
                ItemTypeConstants.Armor,
                AttributeConstants.Metal
            };

            AssertAttributes(ArmorConstants.ScaleMail, attributes);
        }

        [Test]
        public void ChainmailAttributes()
        {
            var attributes = new[]
            { 
                ItemTypeConstants.Armor,
                AttributeConstants.Metal
            };

            AssertAttributes(ArmorConstants.Chainmail, attributes);
        }

        [Test]
        public void BreastplateAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Armor, 
                AttributeConstants.Metal
            };

            AssertAttributes(ArmorConstants.Breastplate, attributes);
        }

        [Test]
        public void SplintMailAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Metal 
            };

            AssertAttributes(ArmorConstants.SplintMail, attributes);
        }

        [Test]
        public void BandedMailAttributes()
        {
            var attributes = new[] 
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Metal
            };

            AssertAttributes(ArmorConstants.BandedMail, attributes);
        }

        [Test]
        public void HalfPlateAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Metal
            };

            AssertAttributes(ArmorConstants.HalfPlate, attributes);
        }

        [Test]
        public void FullPlateAttributes()
        {
            var attributes = new[] 
            { 
                ItemTypeConstants.Armor, 
                AttributeConstants.Metal
            };

            AssertAttributes(ArmorConstants.FullPlate, attributes);
        }
    }
}