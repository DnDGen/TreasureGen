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
            var tableName = String.Format("Level{0}Goods", level);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);

            if (String.IsNullOrEmpty(result.Type))
                return Enumerable.Empty<Good>();

            var goods = new List<Good>();
            var valueTableName = String.Format("{0}Values", result.Type);
            var descriptionTableName = String.Format("{0}Descriptions", result.Type);

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