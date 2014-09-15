using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Tools
{
    [TestFixture]
    public class ToolsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Tools"; }
        }

        [TestCase("Empty backpack", 1, 3)]
        [TestCase("Crowbar", 4, 6)]
        [TestCase("Bullseye lantern", 7, 11)]
        [TestCase("Simple lock", 12, 16)]
        [TestCase("Average lock", 17, 21)]
        [TestCase("Good lock", 22, 28)]
        [TestCase("Superior lock", 29, 35)]
        [TestCase("Masterwork manacles", 36, 40)]
        [TestCase("Small steel mirror", 41, 43)]
        [TestCase("Silk rope (50')", 44, 46)]
        [TestCase("Spyglass", 47, 53)]
        [TestCase("Masterwork artisan's tools", 54, 58)]
        [TestCase("Climber's kit", 59, 63)]
        [TestCase("Disguise kit", 64, 68)]
        [TestCase("Healer's kit", 69, 73)]
        [TestCase("Silver holy symbol", 74, 77)]
        [TestCase("Hourglass", 78, 81)]
        [TestCase("Magnifying glass", 82, 88)]
        [TestCase("Masterwork musical instrument", 89, 95)]
        [TestCase("Masterwork thieves' tools", 96, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }
    }
}