using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class GoodsGenerator : IGoodsGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;
        private IDice dice;
        private IPercentileResultProvider percentileResultProvider;
        private IAttributesProvider attributesProvider;

        public GoodsGenerator(IDice dice, ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider,
            IPercentileResultProvider percentileResultProvider, IAttributesProvider typesProvider)
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
            var typeAndAmountResult = typeAndAmountPercentileResultProvider.GetResultFrom(tableName, roll);

            if (String.IsNullOrEmpty(typeAndAmountResult.Type))
                return Enumerable.Empty<Good>();

            var goods = new List<Good>();
            var valueTableName = String.Format("{0}Values", typeAndAmountResult.Type);
            var descriptionTableName = String.Format("{0}Descriptions", typeAndAmountResult.Type);
            var quantity = dice.Roll(typeAndAmountResult.AmountToRoll);

            while (quantity-- > 0)
            {
                roll = dice.Percentile();
                var valueRoll = percentileResultProvider.GetResultFrom(valueTableName, roll);
                var descriptions = attributesProvider.GetAttributesFor(valueRoll, descriptionTableName);
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