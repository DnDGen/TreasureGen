using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Tables;

namespace TreasureGen.Selectors.Domain.Decorators
{
    public class ReplacePercentileSelectorDecorator : IPercentileSelector
    {
        private IPercentileSelector innerSelector;
        private Dictionary<String, String> replacementTables;

        public ReplacePercentileSelectorDecorator(IPercentileSelector innerSelector, IAttributesSelector attributesSelector)
        {
            this.innerSelector = innerSelector;

            var replaceTargets = attributesSelector.SelectFrom(TableNameConstants.Attributes.Set.ReplacementStrings, TableNameConstants.Attributes.Set.ReplacementStrings);
            replacementTables = new Dictionary<String, String>();

            foreach (var replaceTarget in replaceTargets)
                replacementTables[replaceTarget] = attributesSelector.SelectFrom(TableNameConstants.Attributes.Set.ReplacementStrings, replaceTarget).Single();
        }

        public String SelectFrom(String tableName)
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

        public IEnumerable<String> SelectAllFrom(String tableName)
        {
            var results = innerSelector.SelectAllFrom(tableName);
            var resultsToPerformReplace = results.Where(r => replacementTables.Keys.Any(k => r.Contains(k)));
            var otherResults = results.Except(resultsToPerformReplace);

            var allResults = new List<String>();
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