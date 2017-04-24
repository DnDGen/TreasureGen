using System;
using System.Linq;
using TreasureGen.Domain.Selectors.Selections;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Domain.Selectors.Collections
{
    internal class IntelligenceDataSelector : IIntelligenceDataSelector
    {
        private ICollectionsSelector innerSelector;

        public IntelligenceDataSelector(ICollectionsSelector innerSelector)
        {
            this.innerSelector = innerSelector;
        }

        public IntelligenceSelection SelectFrom(string name)
        {
            var data = innerSelector.SelectFrom(TableNameConstants.Collections.Set.IntelligenceData, name).ToList();

            if (data.Count < 3)
                throw new Exception("Data is not formatted for intelligence");

            var result = new IntelligenceSelection();
            result.Senses = data[DataIndexConstants.Intelligence.Senses];
            result.LesserPowersCount = Convert.ToInt32(data[DataIndexConstants.Intelligence.LesserPowersCount]);
            result.GreaterPowersCount = Convert.ToInt32(data[DataIndexConstants.Intelligence.GreaterPowersCount]);

            return result;
        }
    }
}