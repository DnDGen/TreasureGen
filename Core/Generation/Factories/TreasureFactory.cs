using D20Dice.Dice;
using EquipmentGen.Core.Data;

namespace EquipmentGen.Core.Generation.Factories
{
    public static class TreasureFactory
    {
        public static Treasure CreateUsing(IDice dice)
        {
            var treasure = new Treasure();

            treasure.Money = MoneyFactory.CreateWith(dice);

            return treasure;
        }
    }
}