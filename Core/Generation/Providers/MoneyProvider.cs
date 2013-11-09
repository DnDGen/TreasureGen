using EquipmentGen.Core.Data.Moneys;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using System;

namespace EquipmentGen.Core.Generation.Providers
{
    public class MoneyProvider : IMoneyProvider
    {
        private IPercentileResultProvider percentileResultProvider;

        public MoneyProvider(IPercentileResultProvider percentileResultProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
        }

        public Money GetMoney(Int32 level)
        {
            var money = new Money();

            var tableName = String.Format("Level{0}Money", level);
            var percentileResult = percentileResultProvider.GetPercentileResult(tableName);

            return money;
        }
    }
}