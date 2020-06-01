using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Goods;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Selectors.Selections;
using DnDGen.TreasureGen.Tables;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDGen.TreasureGen.Generators.Goods
{
    internal class GoodsGenerator : IGoodsGenerator
    {
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private readonly ICollectionSelector collectionSelector;

        public GoodsGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, ICollectionSelector collectionSelector)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.collectionSelector = collectionSelector;
        }

        public IEnumerable<Good> GenerateAtLevel(int level)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.LevelXGoods, level);
            var typeAndAmountSelection = typeAndAmountPercentileSelector.SelectFrom(tableName);

            if (string.IsNullOrEmpty(typeAndAmountSelection.Type))
                return Enumerable.Empty<Good>();

            var goods = new List<Good>();

            while (typeAndAmountSelection.Amount-- > 0)
            {
                var good = GenerateGood(typeAndAmountSelection);

                goods.Add(good);
            }

            return goods;
        }

        private Good GenerateGood(TypeAndAmountSelection quantity)
        {
            var valueTableName = string.Format(TableNameConstants.Percentiles.Formattable.GOODTYPEValues, quantity.Type);
            var descriptionTableName = string.Format(TableNameConstants.Collections.Formattable.GOODTYPEDescriptions, quantity.Type);

            var valueSelection = typeAndAmountPercentileSelector.SelectFrom(valueTableName);

            var good = new Good();
            good.Description = collectionSelector.SelectRandomFrom(descriptionTableName, valueSelection.Type);
            good.ValueInGold = valueSelection.Amount;

            return good;
        }

        public async Task<IEnumerable<Good>> GenerateAtLevelAsync(int level)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.LevelXGoods, level);
            var typeAndAmountSelection = typeAndAmountPercentileSelector.SelectFrom(tableName);

            if (string.IsNullOrEmpty(typeAndAmountSelection.Type))
                return Enumerable.Empty<Good>();

            var tasks = new List<Task<Good>>();

            while (typeAndAmountSelection.Amount-- > 0)
            {
                var task = Task.Run(() => GenerateGood(typeAndAmountSelection));
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);

            return tasks.Select(t => t.Result);
        }
    }
}