using RollGen;
using System;
using TreasureGen.Selectors.Results;

namespace TreasureGen.Selectors.Domain
{
    public class TypeAndAmountPercentileSelector : ITypeAndAmountPercentileSelector
    {
        private IPercentileSelector percentileSelector;
        private IDice dice;

        public TypeAndAmountPercentileSelector(IPercentileSelector percentileSelector, IDice dice)
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

            if (!percentileResult.Contains(","))
            {
                var message = String.Format("Table {0} was not formatted for type and amount parsing", tableName);
                throw new FormatException(message);
            }
            var parsedResult = percentileResult.Split(',');

            result.Type = parsedResult[0];
            result.Amount = GetAmount(parsedResult[1]);

            return result;
        }

        private Int32 GetAmount(String amountResult)
        {
            var amount = amountResult.Split('d');
            var quantity = Convert.ToInt32(amount[0]);
            var die = 1;

            if (amount.Length > 1)
                die = Convert.ToInt32(amount[1]);

            return dice.Roll(quantity).d(die);
        }
    }
}