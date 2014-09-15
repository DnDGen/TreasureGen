using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Rings
{
    [TestFixture]
    public class ElementsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "Elements"; }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase("Acid", 1, 20)]
        [TestCase("Cold", 21, 40)]
        [TestCase("Electricity", 41, 60)]
        [TestCase("Fire", 61, 80)]
        [TestCase("Sonic", 81, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}