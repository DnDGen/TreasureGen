using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Rings
{
    [TestFixture]
    public class MediumRingsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "MediumRings";
        }

        [TestCase("Counterspells", 1, 5)]
        [TestCase("Mind shielding", 6, 8)]
        [TestCase("Protection +2", 9, 18)]
        [TestCase("Force shield", 19, 23)]
        [TestCase("Ram", 24, 28)]
        [TestCase("Improved climbing", 29, 34)]
        [TestCase("Improved jumping", 35, 40)]
        [TestCase("Improved swimming", 41, 46)]
        [TestCase("Animal friendship", 47, 51)]
        [TestCase("Minor energy resistance", 52, 56)]
        [TestCase("Chameleon power", 57, 61)]
        [TestCase("Water walking", 62, 66)]
        [TestCase("Protection +3", 67, 71)]
        [TestCase("Minor spell storing", 72, 76)]
        [TestCase("Invisibility", 77, 81)]
        [TestCase("Wizardry (I)", 82, 85)]
        [TestCase("Evasion", 86, 90)]
        [TestCase("X-ray vision", 91, 93)]
        [TestCase("Blinking", 94, 97)]
        [TestCase("Major energy resistance", 98, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}