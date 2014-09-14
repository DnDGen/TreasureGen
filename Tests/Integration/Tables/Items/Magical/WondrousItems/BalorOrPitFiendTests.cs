using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.WondrousItems
{
    [TestFixture]
    public class BalorOrPitFiendTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "BalorOrPitFiend"; }
        }

        [TestCase("Balor", 1, 50)]
        [TestCase("Pit fiend", 51, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}