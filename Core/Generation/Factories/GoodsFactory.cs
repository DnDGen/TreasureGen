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
        private IGoodPercentileResultProvider goodPercentileResultProvider;
        private IDice dice;
        private IGoodDescriptionProvider goodDescriptionProvider;

        public GoodsFactory(IGoodPercentileResultProvider goodPercentileResultProvider, IDice dice,
            IGoodDescriptionProvider goodDescriptionProvider)
        {
            this.goodPercentileResultProvider = goodPercentileResultProvider;
            this.dice = dice;
            this.goodDescriptionProvider = goodDescriptionProvider;
        }

        public IEnumerable<Good> CreateAtLevel(Int32 level)
        {
            var result = goodPercentileResultProvider.GetGoodPercentileResult(level);

            if (String.IsNullOrEmpty(result.GoodType))
                return Enumerable.Empty<Good>();

            var goods = new List<Good>();

            var amount = dice.Roll(result.RollToDetermineAmount);
            while (amount-- > 0)
            {
                var valueRoll = goodPercentileResultProvider.GetGoodPercentileResult(result.GoodType);
                var good = new Good();

                good.Description = goodDescriptionProvider.GetDescriptionFor(valueRoll);
                good.ValueInGold = dice.Roll(valueRoll);

                goods.Add(good);
            }

            return goods;
        }
    }
}