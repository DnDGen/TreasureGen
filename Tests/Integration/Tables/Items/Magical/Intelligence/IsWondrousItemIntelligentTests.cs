using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class IsWondrousItemIntelligentTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "IsWondrousItemIntelligent"; }
        }

        [TestCase(false, 2, 100)]
        public void Percentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            var content = Convert.ToString(isTrue);
            AssertPercentile(content, lower, upper);
        }

        [TestCase(true, 1)]
        public void Percentile(Boolean isTrue, Int32 roll)
        {
            var content = Convert.ToString(isTrue);
            AssertPercentile(content, roll);
        }
    }
}