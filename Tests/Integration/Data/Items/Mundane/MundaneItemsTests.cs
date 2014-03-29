using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane
{
    [TestFixture]
    public class MundaneItemsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "MundaneItems";
        }

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