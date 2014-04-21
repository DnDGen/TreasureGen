using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor
{
    [TestFixture]
    public class SpecificShieldsAttributesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "SpecificShieldsAttributes"; }
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
        public void Attributes(String name, params String[] attributes)
        {
            AssertAttributes(name, attributes);
        }
    }
}