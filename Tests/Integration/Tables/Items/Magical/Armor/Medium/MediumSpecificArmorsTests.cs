using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Medium
{
    [TestFixture]
    public class MediumSpecificArmorsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MediumSpecificArmors"; }
        }

        [TestCase(ArmorConstants.ChainShirt, 0, 1, 25)]
        [TestCase(ArmorConstants.FullPlate, 0, 26, 45)]
        [TestCase(ArmorConstants.ElvenChain, 0, 46, 57)]
        [TestCase(ArmorConstants.RhinoHide, 2, 58, 67)]
        [TestCase(ArmorConstants.Breastplate, 0, 68, 82)]
        [TestCase(ArmorConstants.DwarvenPlate, 0, 83, 97)]
        [TestCase(ArmorConstants.BandedMailOfLuck, 3, 98, 100)]
        public void Percentile(String armor, Int32 bonus, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", armor, bonus);
            AssertPercentile(content, lower, upper);
        }
    }
}