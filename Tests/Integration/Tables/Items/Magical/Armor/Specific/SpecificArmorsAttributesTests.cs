using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor
{
    [TestFixture]
    public class SpecificArmorsAttributesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Attributes.Formattable.SpecificITEMTYPEAttributes, ItemTypeConstants.Armor); }
        }

        [TestCase(ArmorConstants.BandedMailOfLuck, ItemTypeConstants.Armor,
                                                   AttributeConstants.Specific,
                                                   AttributeConstants.Metal)]
        [TestCase(ArmorConstants.BreastplateOfCommand, ItemTypeConstants.Armor,
                                                       AttributeConstants.Specific,
                                                       AttributeConstants.Metal)]
        [TestCase(ArmorConstants.CelestialArmor, ItemTypeConstants.Armor,
                                                 AttributeConstants.Specific,
                                                 AttributeConstants.Metal)]
        [TestCase(ArmorConstants.DemonArmor, ItemTypeConstants.Armor,
                                             AttributeConstants.Specific,
                                             AttributeConstants.Metal)]
        [TestCase(ArmorConstants.DwarvenPlate, ItemTypeConstants.Armor,
                                               AttributeConstants.Specific,
                                               AttributeConstants.Metal)]
        [TestCase(ArmorConstants.ElvenChain, ItemTypeConstants.Armor,
                                             AttributeConstants.Specific,
                                             AttributeConstants.Metal)]
        [TestCase(ArmorConstants.FullPlateOfSpeed, ItemTypeConstants.Armor,
                                                   AttributeConstants.Specific,
                                                   AttributeConstants.Metal)]
        [TestCase(ArmorConstants.PlateArmorOfTheDeep, ItemTypeConstants.Armor,
                                                      AttributeConstants.Specific,
                                                      AttributeConstants.Metal)]
        [TestCase(ArmorConstants.RhinoHide, ItemTypeConstants.Armor,
                                            AttributeConstants.Specific)]
        [TestCase(ArmorConstants.ChainShirt, ItemTypeConstants.Armor,
                                             AttributeConstants.Specific,
                                             AttributeConstants.Metal)]
        [TestCase(ArmorConstants.FullPlate, ItemTypeConstants.Armor,
                                            AttributeConstants.Specific)]
        [TestCase(ArmorConstants.Breastplate, ItemTypeConstants.Armor,
                                              AttributeConstants.Specific,
                                              AttributeConstants.Metal)]
        public override void Attributes(String name, params String[] attributes)
        {
            base.Attributes(name, attributes);
        }
    }
}