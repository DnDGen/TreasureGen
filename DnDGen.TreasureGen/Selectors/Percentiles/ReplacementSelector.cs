using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Tables;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Selectors.Percentiles
{
    internal class ReplacementSelector : IReplacementSelector
    {
        private readonly ICollectionSelector collectionsSelector;

        public ReplacementSelector(ICollectionSelector collectionsSelector)
        {
            this.collectionsSelector = collectionsSelector;
        }

        public string SelectRandom(string source)
        {
            var replacementTables = GetReplacementTargetsAndTables(source);
            var replaceTargets = replacementTables.Keys;
            var result = source;

            foreach (var replaceTarget in replaceTargets)
            {
                result = Replace(result, replaceTarget, replacementTables[replaceTarget]);
            }

            return result;
        }

        private Dictionary<string, IEnumerable<string>> GetReplacementTargetsAndTables(string source)
        {
            var replacements = collectionsSelector.SelectAllFrom(TableNameConstants.Collections.Set.ReplacementStrings);
            var matchingReplacements = replacements
                .Where(kvp => source.Contains(kvp.Key))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            return matchingReplacements;
        }

        public IEnumerable<string> SelectAll(string source) => SelectAll(new[] { source });
        public string SelectSingle(string source) => SelectAll(source).Single();

        public IEnumerable<string> SelectAll(IEnumerable<string> sources)
        {
            var allResults = new List<string>();
            allResults.AddRange(sources);
            var replacements = collectionsSelector.SelectAllFrom(TableNameConstants.Collections.Set.ReplacementStrings);
            var resultsNeedingReplacement = allResults
                .Where(r => replacements.Keys.Any(k => r.Contains(k)));

            while (resultsNeedingReplacement.Any())
            {
                //INFO: Doing ToArray so the foreach doesn't complain when we add to the original collection
                foreach (var result in resultsNeedingReplacement.ToArray())
                {
                    var replacedResult = result;
                    var replacementTables = GetReplacementTargetsAndTables(result);

                    foreach (var replaceTarget in replacementTables.Keys)
                    {
                        var replacedResults = ReplaceEach(result, replaceTarget, replacementTables[replaceTarget]);
                        allResults.AddRange(replacedResults);
                    }

                    allResults.Remove(result);
                }
            }

            return allResults.Distinct();
        }

        private string Replace(string source, string target, IEnumerable<string> replacements)
        {
            var replacement = collectionsSelector.SelectRandomFrom(replacements);
            var result = source.Replace(target, replacement);

            return result;
        }

        private IEnumerable<string> ReplaceEach(string source, string target, IEnumerable<string> replacements)
        {
            var results = new List<string>();

            foreach (var replacement in replacements)
            {
                var result = source.Replace(target, replacement);
                results.Add(result);
            }

            return results;
        }
    }
}
