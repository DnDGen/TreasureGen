using DnDGen.Core.Selectors.Collections;
using DnDGen.Core.Selectors.Percentiles;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Domain.Selectors.Percentiles
{
    internal class PercentileSelectorStringReplacementDecorator : ITreasurePercentileSelector
    {
        private readonly IPercentileSelector innerSelector;
        private readonly ICollectionsSelector collectionsSelector;

        public PercentileSelectorStringReplacementDecorator(IPercentileSelector innerSelector, ICollectionsSelector collectionsSelector)
        {
            this.innerSelector = innerSelector;
            this.collectionsSelector = collectionsSelector;
        }

        public string SelectFrom(string tableName)
        {
            var result = innerSelector.SelectFrom(tableName);
            var replaceResult = ReplaceStringTemplates(result);

            return replaceResult;
        }

        private string ReplaceStringTemplates(string source)
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

        private Dictionary<string, string> GetReplacementTargetsAndTables(string source)
        {
            var replaceTargets = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ReplacementStrings, TableNameConstants.Collections.Set.ReplacementStrings);
            replaceTargets = replaceTargets.Where(t => source.Contains(t));

            var replacementTables = new Dictionary<string, string>();

            foreach (var replaceTarget in replaceTargets)
                replacementTables[replaceTarget] = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ReplacementStrings, replaceTarget).Single();

            return replacementTables;
        }

        public IEnumerable<string> SelectAllFrom(string tableName)
        {
            var results = innerSelector.SelectAllFrom(tableName);
            var allResults = new List<string>();
            allResults.AddRange(results);
            var resultsNeedingReplacement = allResults.Where(r => NeedsReplacement(r));

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

        private bool NeedsReplacement(string source)
        {
            var replaceTargets = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ReplacementStrings, TableNameConstants.Collections.Set.ReplacementStrings);
            return replaceTargets.Any(t => source.Contains(t));
        }

        private string Replace(string source, string target, string table)
        {
            var replacement = innerSelector.SelectFrom(table);
            var result = source.Replace(target, replacement);

            return result;
        }

        private IEnumerable<string> ReplaceEach(string source, string target, string table)
        {
            var replacements = innerSelector.SelectAllFrom(table);
            var results = new List<string>();

            foreach (var replacement in replacements)
            {
                var result = source.Replace(target, replacement);
                results.Add(result);
            }

            return results;
        }

        public T SelectFrom<T>(string tableName)
        {
            return innerSelector.SelectFrom<T>(tableName);
        }

        public IEnumerable<T> SelectAllFrom<T>(string tableName)
        {
            return innerSelector.SelectAllFrom<T>(tableName);
        }
    }
}