using System;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Providers.Objects;

namespace EquipmentGen.Core.Generation.Providers
{
    public class CoinPercentileResultProvider : ICoinPercentileResultProvider
    {
        private IPercentileResultProvider percentileResultProvider;

        public CoinPercentileResultProvider(IPercentileResultProvider percentileResultProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
        }

        public CoinPercentileResult GetCoinPercentileResult(Int32 level)
        {
            var tableName = String.Format("Level{0}Coins", level);
            var percentileResult = percentileResultProvider.GetPercentileResult(tableName);

            var coinResult = new CoinPercentileResult() { CoinType = String.Empty, RollToDetermineAmount = String.Empty };
            if (String.IsNullOrEmpty(percentileResult))
                return coinResult;

            var parsedResult = percentileResult.Split(',');

            coinResult.CoinType = parsedResult[0];
            coinResult.RollToDetermineAmount = parsedResult[1];

            return coinResult;
        }
    }
}