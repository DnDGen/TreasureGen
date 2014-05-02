using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Rings
{
    [TestFixture]
    public class MinorRingsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MinorRings"; }
        }

        [TestCase("Protection", 1, 1, 18)]
        [TestCase("Feather falling", 0, 19, 28)]
        [TestCase("Sustenance", 0, 29, 36)]
        [TestCase("Climbing", 0, 37, 44)]
        [TestCase("Jumping", 0, 45, 52)]
        [TestCase("Swimming", 0, 53, 60)]
        [TestCase("Counterspells", 0, 61, 70)]
        [TestCase("Mind shielding", 0, 71, 75)]
        [TestCase("Protection", 2, 76, 80)]
        [TestCase("Force shield", 0, 81, 85)]
        [TestCase("Ram", 0, 86, 90)]
        [TestCase("Animal friendship", 0, 91, 93)]
        [TestCase("Minor ENERGY resistance", 0, 94, 96)]
        [TestCase("Chameleon power", 0, 97, 98)]
        [TestCase("Water walking", 0, 99, 100)]
        public void Percentile(String name, Int32 bonus, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", name, bonus);
            AssertPercentile(content, lower, upper);
        }
    }
}