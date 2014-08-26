using System;
using D20Dice;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;
using System.Linq;

namespace EquipmentGen.Selectors
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

            var amount = parsedResult[1].Split('d', '*');

            if (amount.Length == 1)
            {
                result.Amount = Convert.ToInt32(amount[0]);
            }
            else if (amount.Length == 2)
            {
                var quantity = Convert.ToInt32(amount[0]);
                var die = Convert.ToInt32(amount[1]);
                result.Amount = dice.Roll(quantity).d(die);
            }
            else
            {
                var quantity = Convert.ToInt32(amount[0]);
                var die = Convert.ToInt32(amount[1]);
                var multiplier = Convert.ToInt32(amount[2]);

                result.Amount = dice.Roll(quantity).d(die) * multiplier;
            }

            return result;
        }
    }
}