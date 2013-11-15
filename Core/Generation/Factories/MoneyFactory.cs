using D20Dice;
using EquipmentGen.Core.Data.Moneys;
using EquipmentGen.Core.Generation.Providers;
using System;

namespace EquipmentGen.Core.Generation.Factories
{
    public static class MoneyFactory
    {
        public static Money CreateWith(IDice dice, Int32 level)
        {
            var moneyProvider = ProviderFactory.CreateMoneyProviderWith(dice);
            return moneyProvider.GetMoney(level);
        }
    }
}