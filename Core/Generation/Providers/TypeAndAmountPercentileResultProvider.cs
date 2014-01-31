using System;
using D20Dice;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Providers.Objects;

namespace EquipmentGen.Core.Generation.Providers
{
    public class TypeAndAmountPercentileResultProvider : ITypeAndAmountPercentileResultProvider
    {
        private IPercentileResultProvider percentileResultProvider;
        private IDice dice;

        public TypeAndAmountPercentileResultProvider(IPercentileResultProvider percentileResultProvider, IDice dice)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.dice = dice;
        }

        public TypeAndAmountPercentileResult GetTypeAndAmountPercentileResult(String tableName)
        {
            var percentileResult = percentileResultProvider.GetPercentileResult(tableName);

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
            result.Amount = dice.Roll(parsedResult[1]);

            return result;
        }
    }
}