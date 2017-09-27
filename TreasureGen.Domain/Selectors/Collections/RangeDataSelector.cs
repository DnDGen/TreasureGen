using DnDGen.Core.Selectors.Collections;
using System;
using System.Linq;
using TreasureGen.Domain.Selectors.Selections;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Domain.Selectors.Collections
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