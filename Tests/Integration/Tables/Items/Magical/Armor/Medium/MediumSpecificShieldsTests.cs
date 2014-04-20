using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Medium
{
    [TestFixture]
    public class MediumSpecificShieldsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MediumSpecificShields"; }
        }

        [TestCase(ArmorConstants.Buckler, 0, 1, 20)]
        [TestCase(ArmorConstants.HeavyWoodenShield, 0, 21, 45)]
        [TestCase(ArmorConstants.HeavySteelShield, 0, 46, 70)]
        [TestCase(ArmorConstants.CastersShield, 1, 71, 85)]
        [TestCase(ArmorConstants.SpinedShield, 1, 86, 90)]
        [TestCase(ArmorConstants.LionsShield, 2, 91, 95)]
        [TestCase(ArmorConstants.WingedShield, 3, 96, 100)]
        public void Percentile(String armor, Int32 bonus, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", armor, bonus);
            AssertPercentile(content, lower, upper);
        }
    }
}