using NUnit.Framework;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Armor.Specific
{
    [TestFixture]
    public class SpecificShieldAttributesTests : CollectionsTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, AttributeConstants.Shield); }
        }

        [TestCase(ArmorConstants.AbsorbingShield, ItemTypeConstants.Armor,
                                                  AttributeConstants.Shield,
                                                  AttributeConstants.NotTower,
                                                  AttributeConstants.Specific,
                                                  AttributeConstants.Metal)]
        [TestCase(ArmorConstants.Buckler, ItemTypeConstants.Armor,
                                          AttributeConstants.Shield,
                                          AttributeConstants.NotTower,
                                          AttributeConstants.Specific,
                                          AttributeConstants.Wood)]
        [TestCase(ArmorConstants.HeavyWoodenShield, ItemTypeConstants.Armor,
                                                    AttributeConstants.Shield,
                                                    AttributeConstants.NotTower,
                                                    AttributeConstants.Specific,
                                                    AttributeConstants.Wood)]
        [TestCase(ArmorConstants.HeavySteelShield, ItemTypeConstants.Armor,
                                                   AttributeConstants.Shield,
                                                   AttributeConstants.NotTower,
                                                   AttributeConstants.Specific,
                                                   AttributeConstants.Metal)]
        [TestCase(ArmorConstants.CastersShield, ItemTypeConstants.Armor,
                                                AttributeConstants.Shield,
                                                AttributeConstants.NotTower,
                                                AttributeConstants.Specific,
                                                AttributeConstants.Wood)]
        [TestCase(ArmorConstants.SpinedShield, ItemTypeConstants.Armor,
                                               AttributeConstants.Shield,
                                               AttributeConstants.NotTower,
                                               AttributeConstants.Specific,
                                               AttributeConstants.Metal)]
        [TestCase(ArmorConstants.LionsShield, ItemTypeConstants.Armor,
                                              AttributeConstants.Shield,
                                              AttributeConstants.NotTower,
                                              AttributeConstants.Specific,
                                              AttributeConstants.Metal)]
        [TestCase(ArmorConstants.WingedShield, ItemTypeConstants.Armor,
                                               AttributeConstants.Shield,
                                               AttributeConstants.NotTower,
                                               AttributeConstants.Specific,
                                               AttributeConstants.Wood)]
        public override void Collections(string name, params string[] attributes)
        {
            base.Collections(name, attributes);
        }
    }
}