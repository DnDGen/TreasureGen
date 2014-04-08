using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Rings
{
    [TestFixture]
    public class ElementsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "Elements";
        }

        [TestCase("Acid", 1, 20)]
        [TestCase("Cold", 21, 40)]
        [TestCase("Electricity", 41, 60)]
        [TestCase("Fire", 61, 80)]
        [TestCase("Sonic", 81, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}