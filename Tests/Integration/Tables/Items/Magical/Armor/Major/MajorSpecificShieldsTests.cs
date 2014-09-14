using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Major
{
    [TestFixture]
    public class MajorSpecificShieldsTests : TypeAndAmountPercentileTests
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
        public override void TypeAndAmountPercentile(String type, Int32 amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }
    }
}