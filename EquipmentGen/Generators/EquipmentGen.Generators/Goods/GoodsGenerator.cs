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
        private IAttributesProvider typesProvider;

        public GoodsGenerator(IDice dice, ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider,
            IPercentileResultProvider percentileResultProvider, IAttributesProvider typesProvider)
        {
            this.dice = dice;
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
            this.percentileResultProvider = percentileResultProvider;
            this.typesProvider = typesProvider;
        }

        public IEnumerable<Good> GenerateAtLevel(Int32 level)
        {
            var tableName = String.Format("Level{0}Goods", level);
            var typeAndAmountResult = typeAndAmountPercentileResultProvider.GetResultFrom(tableName);

            if (String.IsNullOrEmpty(typeAndAmountResult.Type))
                return Enumerable.Empty<Good>();

            var goods = new List<Good>();
            var valueTableName = String.Format("{0}Values", typeAndAmountResult.Type);
            var descriptionTableName = String.Format("{0}Descriptions", typeAndAmountResult.Type);

            while (typeAndAmountResult.AmountToRoll-- > 0)
            {
                var valueRoll = percentileResultProvider.GetResultFrom(valueTableName);
                var descriptions = typesProvider.GetAttributesFor(valueRoll, descriptionTableName);
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