using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Selectors.Selections;
using DnDGen.TreasureGen.Tables;
using System;
using System.Linq;

namespace DnDGen.TreasureGen.Selectors.Collections
{
    internal class IntelligenceDataSelector : IIntelligenceDataSelector
    {
        private readonly ICollectionSelector innerSelector;

        public IntelligenceDataSelector(ICollectionSelector innerSelector)
        {
            this.innerSelector = innerSelector;
        }

        public IntelligenceSelection SelectFrom(string name)
        {
            var data = innerSelector.SelectFrom(Config.Name, TableNameConstants.Collections.Set.IntelligenceData, name).ToList();

            if (data.Count != 3)
                throw new Exception("Data is not formatted for intelligence");

            var result = new IntelligenceSelection();
            result.Senses = data[DataIndexConstants.Intelligence.Senses];
            result.LesserPowersCount = Convert.ToInt32(data[DataIndexConstants.Intelligence.LesserPowersCount]);
            result.GreaterPowersCount = Convert.ToInt32(data[DataIndexConstants.Intelligence.GreaterPowersCount]);

            return result;
        }
    }
}