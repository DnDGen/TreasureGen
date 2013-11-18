using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Core.Generation.Providers;

namespace EquipmentGen.Core.Generation.Factories
{
    public static class GoodsFactory
    {
        public static IEnumerable<Good> CreateWith(IDice dice, Int32 level)
        {
            var goodPercentileResultProvider = ProviderFactory.CreateGoodPercentileResultProviderWith(dice);
            var result = goodPercentileResultProvider.GetGoodPercentileResult(level);
            var amount = dice.Roll(result.RollToDetermineAmount);

            var goods = new List<Good>();

            while (amount-- > 0)
            {
                var good = GenerateGood(result.GoodType, dice);
                goods.Add(good);
            }

            return goods;
        }

        private static Good GenerateGood(String type, IDice dice)
        {
            switch (type)
            {
                case GoodsConstants.Gem: return GemFactory.CreateWith(dice);
                case GoodsConstants.Art: return ArtFactory.CreateWith(dice);
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}