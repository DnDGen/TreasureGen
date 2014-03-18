using System;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Providers.Objects;

namespace EquipmentGen.Core.Generation.Providers
{
    public class TypeAndAmountPercentileResultProvider : ITypeAndAmountPercentileResultProvider
    {
        private IPercentileResultProvider innerProvider;

        public TypeAndAmountPercentileResultProvider(IPercentileResultProvider innerProvider)
        {
            this.innerProvider = innerProvider;
        }

        public TypeAndAmountPercentileResult GetResultFrom(String tableName, Int32 roll)
        {
            var percentileResult = innerProvider.GetResultFrom(tableName, roll);

            var result = new TypeAndAmountPercentileResult();
            if (String.IsNullOrEmpty(percentileResult))
                return result;

            if (!percentileResult.Contains(","))
            {
                var message = String.Format("Table {0} was not formatted for type and amount parsing", tableName);
                throw new FormatException(message);
            }

            var parsedResult = percentileResult.Split(',');

            result.Type = parsedResult[0];
            result.AmountToRoll = parsedResult[1];

            return result;
        }
    }
}