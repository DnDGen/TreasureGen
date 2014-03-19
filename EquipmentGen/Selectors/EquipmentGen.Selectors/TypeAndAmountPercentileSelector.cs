using System;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Objects;

namespace EquipmentGen.Selectors
{
    public class TypeAndAmountPercentileSelector : ITypeAndAmountPercentileSelector
    {
        private IPercentileSelector innerProvider;

        public TypeAndAmountPercentileSelector(IPercentileSelector innerProvider)
        {
            this.innerProvider = innerProvider;
        }

        public TypeAndAmountPercentileResult SelectFrom(String tableName, Int32 roll)
        {
            var percentileResult = innerProvider.SelectFrom(tableName, roll);

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