using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Curses
{
    [TestFixture]
    public class CursesTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Curses"; }
        }

        [TestCase("Delusion", 1, 15)]
        [TestCase("Opposite effect or target", 16, 35)]
        [TestCase("Intermittent Functioning", 36, 45)]
        [TestCase("Requirement", 46, 60)]
        [TestCase("Drawback", 61, 75)]
        [TestCase("Completely different effect", 76, 90)]
        [TestCase("SpecificCursedItem", 91, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}