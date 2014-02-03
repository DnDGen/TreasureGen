using System;
using D20Dice;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Providers.Objects;

namespace EquipmentGen.Core.Generation.Providers
{
    public class TypeAndAmountPercentileResultProvider : ITypeAndAmountPercentileResultProvider
    {
        private IPercentileResultProvider innerProvider;
        private IDice dice;

        public TypeAndAmountPercentileResultProvider(IPercentileResultProvider innerProvider, IDice dice)
        {
            this.innerProvider = innerProvider;
            this.dice = dice;
        }

        public TypeAndAmountPercentileResult GetResultFrom(String tableName)
        {
            var percentileResult = innerProvider.GetResultFrom(tableName);

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