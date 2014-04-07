using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Curses
{
    [TestFixture]
    public class CurseHeightChangesTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "CurseHeightChanges";
        }

        [TestCase("shrink", 1, 50)]
        [TestCase("grow", 51, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}