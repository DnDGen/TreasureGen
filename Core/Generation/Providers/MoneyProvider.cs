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
            var parsedResult = percentileResult.Split(',');

            var money = new Money();
            money.Currency = parsedResult[0];
            money.Quantity = RollMoney(parsedResult[1], Convert.ToInt32(parsedResult[2]));

            return money;
        }

        private Int32 RollMoney(String rollString, Int32 multiplier)
        {
            var parsedRoll = rollString.Split('d');
            var rollQuantity = Convert.ToInt32(parsedRoll[0]);

            var roll = GetRoll(rollQuantity, parsedRoll[1]);
            return roll * multiplier;
        }

        private Int32 GetRoll(Int32 quantity, String rollDie)
        {
            switch (rollDie)
            {
                case "2": return dice.d2(quantity);
                case "3": return dice.d3(quantity);
                case "4": return dice.d4(quantity);
                case "6": return dice.d6(quantity);
                case "8": return dice.d8(quantity);
                case "10": return dice.d10(quantity);
                case "12": return dice.d12(quantity);
                case "20": return dice.d20(quantity);
                case "100": return dice.Percentile(quantity);
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}