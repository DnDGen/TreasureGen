using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Rings
{
    [TestFixture]
    public class MinorRingsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "MinorRings";
        }

        [TestCase("Protection +1", 1, 18)]
        [TestCase("Feather falling", 19, 28)]
        [TestCase("Sustenance", 29, 36)]
        [TestCase("Climbing", 37, 44)]
        [TestCase("Jumping", 45, 52)]
        [TestCase("Swimming", 53, 60)]
        [TestCase("Counterspells", 61, 70)]
        [TestCase("Mind shielding", 71, 75)]
        [TestCase("Protection +2", 76, 80)]
        [TestCase("Force shield", 81, 85)]
        [TestCase("Ram", 86, 90)]
        [TestCase("Animal friendship", 91, 93)]
        [TestCase("Minor energy resistance", 94, 96)]
        [TestCase("Chameleon power", 97, 98)]
        [TestCase("Water walking", 99, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}