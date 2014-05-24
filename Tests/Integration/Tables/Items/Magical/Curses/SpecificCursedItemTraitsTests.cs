using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Curses
{
    [TestFixture]
    public class SpecificCursedItemTraitsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "SpecificCursedItemTraits"; }
        }

        [TestCase(EmptyContent, 1, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}