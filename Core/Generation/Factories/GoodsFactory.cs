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
                throw new NotImplementedException();
            }

            return goods;
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