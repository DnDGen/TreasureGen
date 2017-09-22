using DnDGen.Core.Selectors.Collections;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Goods;

namespace TreasureGen.Domain.Generators.Goods
{
    internal class GoodsGenerator : IGoodsGenerator
    {
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private readonly ICollectionsSelector collectionSelector;

        public GoodsGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, ICollectionsSelector collectionSelector)
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
            var valueTableName = string.Format(TableNameConstants.Percentiles.Formattable.GOODTYPEValues, typeAndAmountSelection.Type);
            var descriptionTableName = string.Format(TableNameConstants.Collections.Formattable.GOODTYPEDescriptions, typeAndAmountSelection.Type);

            while (typeAndAmountSelection.Amount-- > 0)
            {
                var valueSelection = typeAndAmountPercentileSelector.SelectFrom(valueTableName);

                var good = new Good();
                good.Description = collectionSelector.SelectRandomFrom(descriptionTableName, valueSelection.Type);
                good.ValueInGold = valueSelection.Amount;

                goods.Add(good);
            }

            return goods;
        }
    }
}