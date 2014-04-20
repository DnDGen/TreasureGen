using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Major
{
    [TestFixture]
    public class MajorSpecificShieldsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MajorSpecificShields"; }
        }

        [TestCase(ArmorConstants.CastersShield, 1, 1, 20)]
        [TestCase(ArmorConstants.SpinedShield, 1, 21, 40)]
        [TestCase(ArmorConstants.LionsShield, 2, 41, 60)]
        [TestCase(ArmorConstants.WingedShield, 3, 61, 90)]
        [TestCase(ArmorConstants.AbsorbingShield, 1, 91, 100)]
        public void Percentile(String armor, Int32 bonus, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", armor, bonus);
            AssertPercentile(content, lower, upper);
        }
    }
}