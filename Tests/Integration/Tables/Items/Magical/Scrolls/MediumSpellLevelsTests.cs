using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Scrolls
{
    [TestFixture]
    public class MediumSpellLevelsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MediumSpellLevels"; }
        }

        [TestCase("2", 1, 5)]
        [TestCase("3", 6, 65)]
        [TestCase("4", 66, 95)]
        [TestCase("5", 96, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}