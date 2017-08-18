using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Selections;

namespace TreasureGen.Domain.Selectors.Percentiles
{
    internal class TypeAndAmountPercentileSelector : ITypeAndAmountPercentileSelector
    {
        private readonly ITreasurePercentileSelector percentileSelector;
        private readonly Dice dice;

        public TypeAndAmountPercentileSelector(ITreasurePercentileSelector percentileSelector, Dice dice)
        {
            this.percentileSelector = percentileSelector;
            this.dice = dice;
        }

        public TypeAndAmountSelection SelectFrom(string tableName)
        {
            var percentileResult = percentileSelector.SelectFrom(tableName);
            var result = ParseResult(percentileResult);

            return result;
        }

        private TypeAndAmountSelection ParseResult(string percentileResult)
        {
            var result = new TypeAndAmountSelection();

            if (string.IsNullOrEmpty(percentileResult))
                return result;

            if (!percentileResult.Contains(","))
                throw new FormatException($"{percentileResult} is not formatted for type and amount parsing");

            var parsedResult = percentileResult.Split(',');

            result.Type = parsedResult[0];
            result.Amount = dice.Roll(parsedResult[1]).AsSum();

            return result;
        }

        public IEnumerable<TypeAndAmountSelection> SelectAllFrom(string tablename)
        {
            var percentileResults = percentileSelector.SelectAllFrom(tablename);
            var results = percentileResults.Select(r => ParseResult(r));

            return results;
        }
    }
}