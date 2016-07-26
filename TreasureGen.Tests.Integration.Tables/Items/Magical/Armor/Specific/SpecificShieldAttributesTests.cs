using NUnit.Framework;
using System;
using TreasureGen.Items;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Armor.Specific
{
    [TestFixture]
    public class SpecificShieldAttributesTests : CollectionsTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, AttributeConstants.Shield); }
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
        public override void Collections(String name, params String[] attributes)
        {
            base.Collections(name, attributes);
        }
    }
}