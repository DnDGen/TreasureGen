using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Armors
{
    [TestFixture]
    public class DarkwoodShieldsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "DarkwoodShields"; }
        }

        [TestCase(ArmorConstants.Buckler, 1, 50)]
        [TestCase(ArmorConstants.HeavyWoodenShield, 51, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}