using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls
{
    [TestFixture]
    public class MinorSpellLevelsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "MinorSpellLevels";
        }

        [TestCase("0", 1, 5)]
        [TestCase("1", 6, 50)]
        [TestCase("2", 51, 95)]
        [TestCase("3", 96, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}