using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Scrolls
{
    [TestFixture]
    public class ScrollTraitsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "ScrollTraits"; }
        }

        [TestCase(EmptyContent, 1, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}