using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Domain.Selectors.Percentiles
{
    internal class ReplacePercentileSelectorDecorator : IPercentileSelector
    {
        private IPercentileSelector innerSelector;
        private Dictionary<string, string> replacementTables;

        public ReplacePercentileSelectorDecorator(IPercentileSelector innerSelector, ICollectionsSelector attributesSelector)
        {
            this.innerSelector = innerSelector;

            var replaceTargets = attributesSelector.SelectFrom(TableNameConstants.Collections.Set.ReplacementStrings, TableNameConstants.Collections.Set.ReplacementStrings);
            replacementTables = new Dictionary<string, string>();

            foreach (var replaceTarget in replaceTargets)
                replacementTables[replaceTarget] = attributesSelector.SelectFrom(TableNameConstants.Collections.Set.ReplacementStrings, replaceTarget).Single();
        }

        public string SelectFrom(string tableName)
        {
            var result = innerSelector.SelectFrom(tableName);
            var replaceTargets = replacementTables.Keys.Where(k => result.Contains(k));

            foreach (var replaceTarget in replaceTargets)
            {
                var replacement = innerSelector.SelectFrom(replacementTables[replaceTarget]);
                result = result.Replace(replaceTarget, replacement);
            }

            return result;
        }

        public IEnumerable<string> SelectAllFrom(string tableName)
        {
            var results = innerSelector.SelectAllFrom(tableName);
            var resultsToPerformReplace = results.Where(r => replacementTables.Keys.Any(k => r.Contains(k)));
            var otherResults = results.Except(resultsToPerformReplace);

            var allResults = new List<string>();
            allResults.AddRange(otherResults);

            foreach (var result in resultsToPerformReplace)
            {
                var replaceTargets = replacementTables.Keys.Where(k => result.Contains(k));

                foreach (var replaceTarget in replaceTargets)
                {
                    var replacements = innerSelector.SelectAllFrom(replacementTables[replaceTarget]);

                    foreach (var replacement in replacements)
                    {
                        var newResult = result.Replace(replaceTarget, replacement);
                        allResults.Add(newResult);
                    }

                }
            }

            return allResults;
        }
    }
}