using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Curses
{
    [TestFixture]
    public class CursedDependentSituationsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "CursedDependentSituations"; }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase("Temperature below freezing", 1, 3)]
        [TestCase("Temperature above freezing", 4, 5)]
        [TestCase("During the day", 6, 10)]
        [TestCase("During the night", 11, 15)]
        [TestCase("In direct sunlight", 16, 20)]
        [TestCase("Out of direct sunlight", 21, 25)]
        [TestCase("Underwater", 26, 34)]
        [TestCase("Out of water", 35, 37)]
        [TestCase("Underground", 38, 45)]
        [TestCase("Aboveground", 46, 55)]
        [TestCase("Within 10 feet of a DESIGNATEDFOE", 56, 64)]
        [TestCase("Within 10 feet of an arcane spellcaster", 65, 72)]
        [TestCase("Within 10 feet of a divine spellcaster", 73, 80)]
        [TestCase("In the hands of a nonspellcaster", 81, 85)]
        [TestCase("In the hands of a spellcaster", 86, 90)]
        [TestCase("In the hands of a ALIGNMENT creature", 91, 95)]
        [TestCase("On nonholy days or during particular astrological events", 97, 99)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [TestCase("In the hands of a GENDER", 96)]
        [TestCase("More than 100 miles from a particular site", 100)]
        public override void Percentile(String content, Int32 roll)
        {
            base.Percentile(content, roll);
        }
    }
}