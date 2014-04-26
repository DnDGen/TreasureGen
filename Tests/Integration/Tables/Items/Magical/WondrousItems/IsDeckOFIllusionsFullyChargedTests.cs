using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.WondrousItems
{
    [TestFixture]
    public class IsDeckOFIllusionsFullyChargedTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "IsDeckOfIllusionsFullyCharged"; }
        }

        [TestCase(true, 1, 90)]
        [TestCase(false, 91, 100)]
        public void Percentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            var content = Convert.ToString(isTrue);
            AssertPercentile(content, lower, upper);
        }
    }
}