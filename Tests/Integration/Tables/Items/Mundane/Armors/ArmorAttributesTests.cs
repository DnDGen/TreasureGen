using System;
using System.Linq;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Armors
{
    [TestFixture]
    public class ArmorAttributesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "ArmorAttributes"; }
        }

        [TestCase(ArmorConstants.Buckler, AttributeConstants.Wood,
                                          AttributeConstants.Shield,
                                          AttributeConstants.NotTower)]
        [TestCase(ArmorConstants.LightWoodenShield, AttributeConstants.Wood,
                                                    AttributeConstants.Shield,
                                                    AttributeConstants.NotTower)]
        [TestCase(ArmorConstants.LightSteelShield, AttributeConstants.Metal,
                                                   AttributeConstants.Shield,
                                                   AttributeConstants.NotTower)]
        [TestCase(ArmorConstants.HeavyWoodenShield, AttributeConstants.Wood,
                                                    AttributeConstants.Shield,
                                                    AttributeConstants.NotTower)]
        [TestCase(ArmorConstants.HeavySteelShield, AttributeConstants.Metal,
                                                   AttributeConstants.Shield,
                                                   AttributeConstants.NotTower)]
        [TestCase(ArmorConstants.TowerShield, AttributeConstants.Wood,
                                              AttributeConstants.Shield)]
        [TestCase(ArmorConstants.PaddedArmor)]
        [TestCase(ArmorConstants.LeatherArmor)]
        [TestCase(ArmorConstants.StuddedLeatherArmor, AttributeConstants.Metal)]
        [TestCase(ArmorConstants.ChainShirt, AttributeConstants.Metal)]
        [TestCase(ArmorConstants.HideArmor)]
        [TestCase(ArmorConstants.ScaleMail, AttributeConstants.Metal)]
        [TestCase(ArmorConstants.Chainmail, AttributeConstants.Metal)]
        [TestCase(ArmorConstants.Breastplate, AttributeConstants.Metal)]
        [TestCase(ArmorConstants.SplintMail, AttributeConstants.Metal)]
        [TestCase(ArmorConstants.BandedMail, AttributeConstants.Metal)]
        [TestCase(ArmorConstants.HalfPlate, AttributeConstants.Metal)]
        [TestCase(ArmorConstants.FullPlate, AttributeConstants.Metal)]
        public void Attributes(String name, params String[] attributes)
        {
            if (attributes.Any())
                AssertAttributes(name, attributes);
            else
                AssertEmpty(name);
        }
    }
}