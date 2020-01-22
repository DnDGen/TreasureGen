using DnDGen.Infrastructure.Selectors.Collections;
using System;
using System.Linq;
using DnDGen.TreasureGen.Selectors.Selections;
using DnDGen.TreasureGen.Tables;

namespace DnDGen.TreasureGen.Selectors.Collections
{
    internal class RangeDataSelector : IRangeDataSelector
    {
        private readonly ICollectionSelector innerSelector;

        public RangeDataSelector(ICollectionSelector innerSelector)
        {
            this.innerSelector = innerSelector;
        }

        public RangeSelection SelectFrom(string tableName, string name)
        {
            var data = innerSelector.SelectFrom(tableName, name).ToArray();

            if (data.Count() != 2)
                throw new Exception("Data is not in format for range");

            var selection = new RangeSelection();
            selection.Minimum = Convert.ToInt32(data[DataIndexConstants.Range.Minimum]);
            selection.Maximum = Convert.ToInt32(data[DataIndexConstants.Range.Maximum]);

            return selection;
        }
    }
}