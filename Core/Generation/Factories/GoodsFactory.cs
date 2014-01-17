using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class GoodsFactory : IGoodsFactory
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;
        private IGoodPercentileResultProvider goodPercentileResultProvider;
        private IDice dice;

        public GoodsFactory(IGoodPercentileResultProvider goodPercentileResultProvider, IDice dice,
            ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider)
        {
            this.goodPercentileResultProvider = goodPercentileResultProvider;
            this.dice = dice;
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
        }

        public IEnumerable<Good> CreateAtLevel(Int32 level)
        {
            var tableName = String.Format("Level{0}Goods", level);
            var typeAndAmountResult = typeAndAmountPercentileResultProvider.GetTypeAndAmountPercentileResult(tableName);

            if (String.IsNullOrEmpty(typeAndAmountResult.Type))
                return Enumerable.Empty<Good>();

            var goods = new List<Good>();

            var amount = dice.Roll(typeAndAmountResult.RollToDetermineAmount);
            tableName = String.Format("{0}Value", typeAndAmountResult.Type);
            while (amount-- > 0)
            {
                var valueResult = goodPercentileResultProvider.GetGoodValuePercentileResult(tableName);
                var roll = String.Format("1d{0}-1", valueResult.Descriptions.Count());
                var index = dice.Roll(roll);

                var good = new Good();
                good.Description = valueResult.Descriptions.ElementAt(index);
                good.ValueInGold = dice.Roll(valueResult.ValueRoll);

                goods.Add(good);
            }

            return goods;
        }
    }
}