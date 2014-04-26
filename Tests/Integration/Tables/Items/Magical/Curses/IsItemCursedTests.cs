using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Curses
{
    [TestFixture]
    public class IsItemCursedTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "IsItemCursed"; }
        }

        [TestCase(true, 1, 5)]
        [TestCase(false, 6, 100)]
        public void Percentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            var content = Convert.ToString(isTrue);
            AssertPercentile(content, lower, upper);
        }
    }
}