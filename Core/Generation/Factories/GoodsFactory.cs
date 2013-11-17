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
            var result = GetResult(dice, level);
            var type = result[0];
            var amount = dice.Roll(result[1]);

            var goods = new List<Good>();

            while (amount-- > 0)
            {
                var good = GenerateGood(type, dice);
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

        private static String[] GetResult(IDice dice, Int32 level)
        {
            var percentileResultProvider = ProviderFactory.CreatePercentileResultProviderWith(dice);
            var tableName = String.Format("Level{0}Goods", level);
            var result = percentileResultProvider.GetPercentileResult(tableName);

            return result.Split(',');
        }
    }
}