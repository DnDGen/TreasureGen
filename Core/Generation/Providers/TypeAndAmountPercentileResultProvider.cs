using System;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Providers.Objects;

namespace EquipmentGen.Core.Generation.Providers
{
    public class TypeAndAmountPercentileResultProvider : ITypeAndAmountPercentileResultProvider
    {
        private IPercentileResultProvider percentileResultProvider;

        public TypeAndAmountPercentileResultProvider(IPercentileResultProvider percentileResultProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
        }

        public TypeAndAmountPercentileResult GetTypeAndAmountPercentileResult(String tableName)
        {
            var percentileResult = percentileResultProvider.GetPercentileResult(tableName);

            var result = new TypeAndAmountPercentileResult() { Type = String.Empty, RollToDetermineAmount = String.Empty };
            if (String.IsNullOrEmpty(percentileResult))
                return result;

            var parsedResult = percentileResult.Split(',');

            result.Type = parsedResult[0];
            result.RollToDetermineAmount = parsedResult[1];

            return result;
        }
    }
}