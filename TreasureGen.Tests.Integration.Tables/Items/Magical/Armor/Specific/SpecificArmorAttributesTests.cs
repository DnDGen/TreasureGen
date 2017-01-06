using NUnit.Framework;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Armor
{
    [TestFixture]
    public class SpecificArmorsAttributesTests : CollectionsTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, ItemTypeConstants.Armor); }
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
        public override void Collections(string name, params string[] attributes)
        {
            base.Collections(name, attributes);
        }
    }
}