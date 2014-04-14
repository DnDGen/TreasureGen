using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.WondrousItems
{
    [TestFixture]
    public class HornOfValhallaTypesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "HornOfValhallaTypes"; }
        }

        [TestCase("Silver", 1, 40)]
        [TestCase("Brass", 41, 75)]
        [TestCase("Bronze", 76, 90)]
        [TestCase("Iron", 91, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}