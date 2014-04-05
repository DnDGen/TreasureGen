using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class LanguagesTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Languages";
        }

        [TestCase("Abyssal", 1, 5)]
        [TestCase("Aquan", 6, 10)]
        [TestCase("Auran", 11, 15)]
        [TestCase("Celestial", 19, 20)]
        [TestCase("Common", 21, 25)]
        [TestCase("Draconic", 26, 30)]
        [TestCase("Dwarven", 31, 35)]
        [TestCase("Elven", 36, 40)]
        [TestCase("Giant", 41, 45)]
        [TestCase("Gnome", 46, 50)]
        [TestCase("Goblin", 51, 55)]
        [TestCase("Gnoll", 56, 60)]
        [TestCase("Halfling", 61, 65)]
        [TestCase("Ignan", 66, 70)]
        [TestCase("Infernal", 71, 75)]
        [TestCase("Orc", 76, 80)]
        [TestCase("Sylvan", 81, 85)]
        [TestCase("Terran", 86, 90)]
        [TestCase("Undercommon", 91, 95)]
        [TestCase("Druidic", 96, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}