using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class IntelligenceStrongStatTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "IntelligenceStrongStats";
        }

        [TestCase("12", 1, 34)]
        [TestCase("13", 35, 59)]
        [TestCase("14", 60, 79)]
        [TestCase("15", 80, 91)]
        [TestCase("16", 92, 97)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase("17", 98)]
        [TestCase("18", 99)]
        [TestCase("19", 100)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }
    }
}