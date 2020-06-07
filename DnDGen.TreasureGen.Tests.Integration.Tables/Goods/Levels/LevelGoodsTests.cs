using DnDGen.Infrastructure.Mappers.Percentiles;
using DnDGen.TreasureGen.Tables;
using Ninject;
using NUnit.Framework;
using System;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Integration.Tables.Goods
{
    [TestFixture]
    public class LevelGoodsTests : TableTests
    {
        [Inject]
        public PercentileMapper PercentileMapper { get; set; }

        protected override string tableName => throw new NotImplementedException();

        [Test]
        public void LevelCoinsExistForAllLevels()
        {
            for (var level = LevelLimits.Minimum; level <= LevelLimits.Maximum; level++)
            {
                var levelTableName = string.Format(TableNameConstants.Percentiles.Formattable.LevelXGoods, level);
                var table = PercentileMapper.Map(levelTableName);
                Assert.That(table, Is.Not.Null);
                Assert.That(table.Keys, Is.EqualTo(Enumerable.Range(1, 100)));
            }
        }
    }
}
