using RollGen;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Goods;

namespace TreasureGen.Domain.Generators.Goods
{
    internal class GoodsGenerator : IGoodsGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private Dice dice;
        private ICollectionsSelector attributesSelector;

        public GoodsGenerator(Dice dice, ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            ICollectionsSelector attributesSelector)
        {
            this.dice = dice;
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.attributesSelector = attributesSelector;
        }

        public IEnumerable<Good> GenerateAtLevel(int level)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.LevelXGoods, level);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);

            if (string.IsNullOrEmpty(result.Type))
                return Enumerable.Empty<Good>();

            var goods = new List<Good>();
            var valueTableName = string.Format(TableNameConstants.Percentiles.Formattable.GOODTYPEValues, result.Type);
            var descriptionTableName = string.Format(TableNameConstants.Collections.Formattable.GOODTYPEDescriptions, result.Type);

            while (result.Amount-- > 0)
            {
                var valueResult = typeAndAmountPercentileSelector.SelectFrom(valueTableName);
                var descriptions = attributesSelector.SelectFrom(descriptionTableName, valueResult.Type);
                var descriptionIndex = dice.Roll().d(descriptions.Count()) - 1;

                var good = new Good();
                good.Description = descriptions.ElementAt(descriptionIndex);
                good.ValueInGold = valueResult.Amount;

                goods.Add(good);
            }

            return goods;
        }
    }
}