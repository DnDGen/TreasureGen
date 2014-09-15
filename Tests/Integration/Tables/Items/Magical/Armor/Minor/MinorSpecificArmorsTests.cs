using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Minor
{
    [TestFixture]
    public class MinorSpecificArmorsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return "MinorSpecificArmors"; }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(ArmorConstants.ChainShirt, 0, 1, 50)]
        [TestCase(ArmorConstants.FullPlate, 0, 51, 80)]
        [TestCase(ArmorConstants.ElvenChain, 0, 81, 100)]
        public override void TypeAndAmountPercentile(String type, Int32 amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}