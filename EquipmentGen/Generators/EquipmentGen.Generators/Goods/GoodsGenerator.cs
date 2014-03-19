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
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileResultProvider;
        private IDice dice;
        private IPercentileSelector percentileResultProvider;
        private IAttributesSelector attributesProvider;

        public GoodsGenerator(IDice dice, ITypeAndAmountPercentileSelector typeAndAmountPercentileResultProvider,
            IPercentileSelector percentileResultProvider, IAttributesSelector typesProvider)
        {
            this.dice = dice;
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
            this.percentileResultProvider = percentileResultProvider;
            this.attributesProvider = typesProvider;
        }

        public IEnumerable<Good> GenerateAtLevel(Int32 level)
        {
            var roll = dice.Percentile();
            var tableName = String.Format("Level{0}Goods", level);
            var typeAndAmountResult = typeAndAmountPercentileResultProvider.SelectFrom(tableName, roll);

            if (String.IsNullOrEmpty(typeAndAmountResult.Type))
                return Enumerable.Empty<Good>();

            var goods = new List<Good>();
            var valueTableName = String.Format("{0}Values", typeAndAmountResult.Type);
            var descriptionTableName = String.Format("{0}Descriptions", typeAndAmountResult.Type);
            var quantity = dice.Roll(typeAndAmountResult.AmountToRoll);

            while (quantity-- > 0)
            {
                roll = dice.Percentile();
                var valueRoll = percentileResultProvider.SelectFrom(valueTableName, roll);
                var descriptions = attributesProvider.SelectFrom(valueRoll, descriptionTableName);
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