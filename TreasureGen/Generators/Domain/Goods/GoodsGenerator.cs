using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Common.Goods;
using TreasureGen.Generators.Goods;
using TreasureGen.Selectors;
using TreasureGen.Tables;

namespace TreasureGen.Generators.Domain.Goods
{
    public class GoodsGenerator : IGoodsGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IDice dice;
        private IAttributesSelector attributesSelector;

        public GoodsGenerator(IDice dice, ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            IAttributesSelector attributesSelector)
        {
            this.dice = dice;
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.attributesSelector = attributesSelector;
        }

        public IEnumerable<Good> GenerateAtLevel(Int32 level)
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.LevelXGoods, level);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);

            if (String.IsNullOrEmpty(result.Type))
                return Enumerable.Empty<Good>();

            var goods = new List<Good>();
            var valueTableName = String.Format(TableNameConstants.Percentiles.Formattable.GOODTYPEValues, result.Type);
            var descriptionTableName = String.Format(TableNameConstants.Attributes.Formattable.GOODTYPEDescriptions, result.Type);

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