using System;
using EquipmentGen.Common.Goods;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods.Art
{
    [TestFixture]
    public class ArtValuesTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.GOODTYPEValues, GoodsConstants.Art); }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase("1d10*10", 1, 10)]
        [TestCase("3d6*10", 11, 25)]
        [TestCase("1d6*100", 26, 40)]
        [TestCase("1d10*100", 41, 50)]
        [TestCase("2d6*100", 51, 60)]
        [TestCase("3d6*100", 61, 70)]
        [TestCase("4d6*100", 71, 80)]
        [TestCase("5d6*100", 81, 85)]
        [TestCase("1d4*1000", 86, 90)]
        [TestCase("1d6*1000", 91, 95)]
        [TestCase("2d4*1000", 96, 99)]
        public void TypeAndAmountPercentile(String value, Int32 lower, Int32 upper)
        {
            TypeAndAmountPercentile(value, value, lower, upper);
        }

        [TestCase("2d6*1000", 100)]
        public void TypeAndAmountPercentile(String value, Int32 roll)
        {
            TypeAndAmountPercentile(value, value, roll);
        }
    }
}