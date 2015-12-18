using RollGen;
using System;
using TreasureGen.Selectors.Results;

namespace TreasureGen.Selectors.Domain
{
    public class TypeAndAmountPercentileSelector : ITypeAndAmountPercentileSelector
    {
        private IPercentileSelector percentileSelector;
        private Dice dice;

        public TypeAndAmountPercentileSelector(IPercentileSelector percentileSelector, Dice dice)
        {
            this.percentileSelector = percentileSelector;
            this.dice = dice;
        }

        public TypeAndAmountPercentileResult SelectFrom(String tableName)
        {
            var percentileResult = percentileSelector.SelectFrom(tableName);
            var result = new TypeAndAmountPercentileResult();

            if (String.IsNullOrEmpty(percentileResult))
                return result;

            if (percentileResult.Contains(",") == false)
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