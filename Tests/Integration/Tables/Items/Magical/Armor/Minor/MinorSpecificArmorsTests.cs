using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Minor
{
    [TestFixture]
    public class MinorSpecificArmorsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MinorSpecificArmors"; }
        }

        [TestCase(ArmorConstants.ChainShirt, 1, 50)]
        [TestCase(ArmorConstants.FullPlate, 51, 80)]
        [TestCase(ArmorConstants.ElvenChain, 81, 100)]
        public void Percentile(String armor, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},0", armor);
            AssertPercentile(content, lower, upper);
        }
    }
}