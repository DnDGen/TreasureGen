using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods.Gems
{
    [TestFixture]
    public class GemValuesTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "GemValues";
        }

        [Test]
        public void GemValue4d4Percentile()
        {
            AssertPercentile("4d4", 1, 25);
        }

        [Test]
        public void GemValue2d4x10Percentile()
        {
            AssertPercentile("2d4*10", 26, 50);
        }

        [Test]
        public void GemValue4d4x10Percentile()
        {
            AssertPercentile("4d4*10", 51, 70);
        }

        [Test]
        public void GemValue2d4x100Percentile()
        {
            AssertPercentile("2d4*100", 71, 90);
        }

        [Test]
        public void GemValue4d4x100Percentile()
        {
            AssertPercentile("4d4*100", 91, 99);
        }

        [Test]
        public void GemValue2d4x1000Percentile()
        {
            AssertPercentile("2d4*1000", 100);
        }
    }
}