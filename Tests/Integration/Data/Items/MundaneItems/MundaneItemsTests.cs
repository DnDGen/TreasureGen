using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MundaneItems
{
    [TestFixture, PercentileTable("MundaneItems")]
    public class MundaneItemsTests : PercentileTests
    {
        [TestCase(ItemTypeConstants.AlchemicalItem, 1, 17)]
        [TestCase(ItemTypeConstants.Armor, 18, 50)]
        [TestCase(ItemTypeConstants.Weapon, 51, 83)]
        [TestCase(ItemTypeConstants.Tool, 84, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}