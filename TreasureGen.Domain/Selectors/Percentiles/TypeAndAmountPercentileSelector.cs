using RollGen;
using System;

namespace TreasureGen.Domain.Selectors.Percentiles
{
    internal class TypeAndAmountPercentileSelector : ITypeAndAmountPercentileSelector
    {
        private IPercentileSelector percentileSelector;
        private Dice dice;

        public TypeAndAmountPercentileSelector(IPercentileSelector percentileSelector, Dice dice)
        {
            this.percentileSelector = percentileSelector;
            this.dice = dice;
        }

        public TypeAndAmountPercentileResult SelectFrom(string tableName)
        {
            var percentileResult = percentileSelector.SelectFrom(tableName);
            var result = new TypeAndAmountPercentileResult();

            if (string.IsNullOrEmpty(percentileResult))
                return result;

            if (percentileResult.Contains(",") == false)
            {
                var message = string.Format("Table {0} was not formatted for type and amount parsing", tableName);
                throw new FormatException(message);
            }

            var parsedResult = percentileResult.Split(',');

            result.Type = parsedResult[0];
            result.Amount = dice.Roll(parsedResult[1]).AsSum();

            return result;
        }
    }
}