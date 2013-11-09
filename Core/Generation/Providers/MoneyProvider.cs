using D20Dice;
using EquipmentGen.Core.Data.Moneys;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using System;

namespace EquipmentGen.Core.Generation.Providers
{
    public class MoneyProvider : IMoneyProvider
    {
        private IPercentileResultProvider percentileResultProvider;
        private IDice dice;

        public MoneyProvider(IPercentileResultProvider percentileResultProvider, IDice dice)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.dice = dice;
        }

        public Money GetMoney(Int32 level)
        {
            var tableName = String.Format("Level{0}Money", level);
            var percentileResult = percentileResultProvider.GetPercentileResult(tableName);

            var money = new Money();
            if (String.IsNullOrEmpty(percentileResult))
                return money;

            var parsedResult = percentileResult.Split(',');

            money.Currency = parsedResult[0];
            money.Quantity = dice.Roll(parsedResult[1]);

            return money;
        }
    }
}