using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Scrolls
{
    [TestFixture]
    public class MajorSpellLevelsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MajorSpellLevels"; }
        }

        [TestCase("4", 1, 5)]
        [TestCase("5", 6, 50)]
        [TestCase("6", 51, 70)]
        [TestCase("7", 71, 85)]
        [TestCase("8", 86, 95)]
        [TestCase("9", 96, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}