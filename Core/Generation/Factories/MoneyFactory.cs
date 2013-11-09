using D20Dice.Dice;
using EquipmentGen.Core.Data.Moneys;
using EquipmentGen.Core.Generation.Providers;
using System;

namespace EquipmentGen.Core.Generation.Factories
{
    public static class MoneyFactory
    {
        public static Money CreateWith(IDice dice, Int32 level)
        {
            var money = new Money();

            var moneyProvider = ProviderFactory.CreateMoneyProviderWith(dice);

            return money;
        }
    }
}