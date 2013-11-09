using D20Dice.Dice;
using EquipmentGen.Core.Data.Moneys;

namespace EquipmentGen.Core.Generation.Factories
{
    public static class MoneyFactory
    {
        public static Money CreateWith(IDice dice)
        {
            var money = new Money();

            return money;
        }
    }
}