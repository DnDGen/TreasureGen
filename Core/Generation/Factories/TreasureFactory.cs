using D20Dice;
using EquipmentGen.Core.Data;
using System;

namespace EquipmentGen.Core.Generation.Factories
{
    public static class TreasureFactory
    {
        public static Treasure CreateUsing(IDice dice, Int32 level)
        {
            var treasure = new Treasure();

            treasure.Money = MoneyFactory.CreateWith(dice, level);

            return treasure;
        }
    }
}