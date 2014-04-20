using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Goods;
using EquipmentGen.Generators.Interfaces.Goods;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Goods
{
    public class GoodsGenerator : IGoodsGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IDice dice;
        private IPercentileSelector percentileSelector;
        private IAttributesSelector attributesSelector;

        public GoodsGenerator(IDice dice, ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            IPercentileSelector percentileSelector, IAttributesSelector attributesSelector)
        {
            this.dice = dice;
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.percentileSelector = percentileSelector;
            this.attributesSelector = attributesSelector;
        }

        public IEnumerable<Good> GenerateAtLevel(Int32 level)
        {
            var roll = dice.Percentile();
            var tableName = String.Format("Level{0}Goods", level);
            var typeAndAmountResult = typeAndAmountPercentileSelector.SelectFrom(tableName, roll);

            if (String.IsNullOrEmpty(typeAndAmountResult.Type))
                return Enumerable.Empty<Good>();

            var goods = new List<Good>();
            var valueTableName = String.Format("{0}Values", typeAndAmountResult.Type);
            var descriptionTableName = String.Format("{0}Descriptions", typeAndAmountResult.Type);
            var quantity = dice.Roll(typeAndAmountResult.Amount);

            while (quantity-- > 0)
            {
                roll = dice.Percentile();
                var valueRoll = percentileSelector.SelectFrom(valueTableName, roll);
                var descriptions = attributesSelector.SelectFrom(descriptionTableName, valueRoll);
                var descriptionIndexRoll = String.Format("1d{0}-1", descriptions.Count());
                var descriptionIndex = dice.Roll(descriptionIndexRoll);

                var good = new Good();
                good.Description = descriptions.ElementAt(descriptionIndex);
                good.ValueInGold = dice.Roll(valueRoll);

                goods.Add(good);
            }

            return goods;
        }
    }
}