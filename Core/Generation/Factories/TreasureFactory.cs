using System;
using D20Dice;
using EquipmentGen.Core.Data;

namespace EquipmentGen.Core.Generation.Factories
{
    public static class TreasureFactory
    {
        public static Treasure CreateUsing(IDice dice, Int32 level)
        {
            var treasure = new Treasure();

            treasure.Coin = CoinFactory.CreateWith(dice, level);

            return treasure;
        }
    }
}