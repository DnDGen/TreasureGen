using DnDGen.TreasureGen.Tables;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Integration.Tables.Goods.Levels
{
    [TestFixture]
    public class Level30PlusGoodsTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get { return string.Format(TableNameConstants.Percentiles.Formattable.LevelXGoods, 20); }
        }

        [Test]
        public override void ReplacementStringsAreValid()
        {
            AssertReplacementStringsAreValid();
        }

        [TestCase(31)]
        [TestCase(32)]
        [TestCase(33)]
        [TestCase(34)]
        [TestCase(35)]
        [TestCase(36)]
        [TestCase(37)]
        [TestCase(38)]
        [TestCase(39)]
        [TestCase(40)]
        [TestCase(41)]
        [TestCase(42)]
        [TestCase(43)]
        [TestCase(44)]
        [TestCase(45)]
        [TestCase(46)]
        [TestCase(47)]
        [TestCase(48)]
        [TestCase(49)]
        [TestCase(50)]
        [TestCase(51)]
        [TestCase(52)]
        [TestCase(53)]
        [TestCase(54)]
        [TestCase(55)]
        [TestCase(56)]
        [TestCase(57)]
        [TestCase(58)]
        [TestCase(59)]
        [TestCase(60)]
        [TestCase(61)]
        [TestCase(62)]
        [TestCase(63)]
        [TestCase(64)]
        [TestCase(65)]
        [TestCase(66)]
        [TestCase(67)]
        [TestCase(68)]
        [TestCase(69)]
        [TestCase(70)]
        [TestCase(71)]
        [TestCase(72)]
        [TestCase(73)]
        [TestCase(74)]
        [TestCase(75)]
        [TestCase(76)]
        [TestCase(77)]
        [TestCase(78)]
        [TestCase(79)]
        [TestCase(80)]
        [TestCase(81)]
        [TestCase(82)]
        [TestCase(83)]
        [TestCase(84)]
        [TestCase(85)]
        [TestCase(86)]
        [TestCase(87)]
        [TestCase(88)]
        [TestCase(89)]
        [TestCase(90)]
        [TestCase(91)]
        [TestCase(92)]
        [TestCase(93)]
        [TestCase(94)]
        [TestCase(95)]
        [TestCase(96)]
        [TestCase(97)]
        [TestCase(98)]
        [TestCase(99)]
        [TestCase(100)]
        public void EpicGoodsPercentile(int level)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.LevelXGoods, level);
            var levelTable = PercentileMapper.Map(Name, tableName);

            Assert.That(levelTable.Keys, Is.EquivalentTo(Enumerable.Range(1, 100)));

            var gemEntry = table[10];
            var artEntry = table[100];

            for (var i = 1; i <= 38; i++)
            {
                Assert.That(levelTable[i], Is.EqualTo(gemEntry), $"Table {tableName}, Roll {i}");
            }

            for (var i = 39; i <= 100; i++)
            {
                Assert.That(levelTable[i], Is.EqualTo(artEntry), $"Table {tableName}, Roll {i}");
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }
    }
}