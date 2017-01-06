using NUnit.Framework;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical
{
    [TestFixture]
    public class EpicItemsTests : CollectionsTests
    {
        protected override string tableName
        {
            get
            {
                return TableNameConstants.Collections.Set.EpicItems;
            }
        }

        [TestCase(1, 0)]
        [TestCase(2, 0)]
        [TestCase(3, 0)]
        [TestCase(4, 0)]
        [TestCase(5, 0)]
        [TestCase(6, 0)]
        [TestCase(7, 0)]
        [TestCase(8, 0)]
        [TestCase(9, 0)]
        [TestCase(10, 0)]
        [TestCase(11, 0)]
        [TestCase(12, 0)]
        [TestCase(13, 0)]
        [TestCase(14, 0)]
        [TestCase(15, 0)]
        [TestCase(16, 0)]
        [TestCase(17, 0)]
        [TestCase(18, 0)]
        [TestCase(19, 0)]
        [TestCase(20, 0)]
        [TestCase(21, 1)]
        [TestCase(22, 2)]
        [TestCase(23, 4)]
        [TestCase(24, 6)]
        [TestCase(25, 9)]
        [TestCase(26, 12)]
        [TestCase(27, 17)]
        [TestCase(28, 23)]
        [TestCase(29, 31)]
        [TestCase(30, 42)]
        public void EpicItems(int level, int quantity)
        {
            var limits = new[] { quantity.ToString(), quantity.ToString() };
            base.OrderedCollections(level.ToString(), limits);
        }
    }
}
