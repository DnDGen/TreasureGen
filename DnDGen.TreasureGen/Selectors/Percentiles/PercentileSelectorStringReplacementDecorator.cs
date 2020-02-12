using DnDGen.Infrastructure.Selectors.Percentiles;
using System.Collections.Generic;

namespace DnDGen.TreasureGen.Selectors.Percentiles
{
    internal class PercentileSelectorStringReplacementDecorator : ITreasurePercentileSelector
    {
        private readonly IPercentileSelector innerSelector;
        private readonly IReplacementSelector replacementSelector;

        public PercentileSelectorStringReplacementDecorator(
            IPercentileSelector innerSelector,
            IReplacementSelector replacementSelector)
        {
            this.innerSelector = innerSelector;
            this.replacementSelector = replacementSelector;
        }

        public string SelectFrom(string tableName)
        {
            var result = innerSelector.SelectFrom(tableName);
            var replaceResult = replacementSelector.SelectRandom(result);

            return replaceResult;
        }

        public IEnumerable<string> SelectAllFrom(string tableName)
        {
            var results = innerSelector.SelectAllFrom(tableName);
            var allResults = replacementSelector.SelectAll(results);

            return allResults;
        }

        public T SelectFrom<T>(string tableName)
        {
            return innerSelector.SelectFrom<T>(tableName);
        }

        public IEnumerable<T> SelectAllFrom<T>(string tableName)
        {
            return innerSelector.SelectAllFrom<T>(tableName);
        }

        public bool SelectFrom(double chance)
        {
            return innerSelector.SelectFrom(chance);
        }

        public bool SelectFrom(int rollThreshold)
        {
            return innerSelector.SelectFrom(rollThreshold);
        }
    }
}