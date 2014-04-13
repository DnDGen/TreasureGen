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
            get { return "ArmorAttributes"; }
        }

        [TestCase(ArmorConstants.Buckler, ItemTypeConstants.Armor,
                                          AttributeConstants.Wood,
                                          AttributeConstants.Shield)]
        [TestCase(ArmorConstants.LightWoodenShield, ItemTypeConstants.Armor,
                                                    AttributeConstants.Wood,
                                                    AttributeConstants.Shield)]
        [TestCase(ArmorConstants.LightSteelShield, ItemTypeConstants.Armor,
                                                   AttributeConstants.Metal,
                                                   AttributeConstants.Shield)]
        [TestCase(ArmorConstants.HeavyWoodenShield, ItemTypeConstants.Armor,
                                                    AttributeConstants.Wood,
                                                    AttributeConstants.Shield)]
        [TestCase(ArmorConstants.HeavySteelShield, ItemTypeConstants.Armor,
                                                   AttributeConstants.Metal,
                                                   AttributeConstants.Shield)]
        [TestCase(ArmorConstants.TowerShield, ItemTypeConstants.Armor,
                                              AttributeConstants.Wood,
                                              AttributeConstants.Shield)]
        [TestCase(ArmorConstants.PaddedArmor, ItemTypeConstants.Armor)]
        [TestCase(ArmorConstants.LeatherArmor, ItemTypeConstants.Armor)]
        [TestCase(ArmorConstants.StuddedLeatherArmor, ItemTypeConstants.Armor,
                                                      AttributeConstants.Metal)]
        [TestCase(ArmorConstants.ChainShirt, ItemTypeConstants.Armor,
                                             AttributeConstants.Metal)]
        [TestCase(ArmorConstants.HideArmor, ItemTypeConstants.Armor)]
        [TestCase(ArmorConstants.ScaleMail, ItemTypeConstants.Armor,
                                            AttributeConstants.Metal)]
        [TestCase(ArmorConstants.Chainmail, ItemTypeConstants.Armor,
                                            AttributeConstants.Metal)]
        [TestCase(ArmorConstants.Breastplate, ItemTypeConstants.Armor,
                                              AttributeConstants.Metal)]
        [TestCase(ArmorConstants.SplintMail, ItemTypeConstants.Armor,
                                             AttributeConstants.Metal)]
        [TestCase(ArmorConstants.BandedMail, ItemTypeConstants.Armor,
                                             AttributeConstants.Metal)]
        [TestCase(ArmorConstants.HalfPlate, ItemTypeConstants.Armor,
                                            AttributeConstants.Metal)]
        [TestCase(ArmorConstants.FullPlate, ItemTypeConstants.Armor,
                                            AttributeConstants.Metal)]
        public void Attributes(String name, params String[] attributes)
        {
            AssertAttributes(name, attributes);
        }
    }
}