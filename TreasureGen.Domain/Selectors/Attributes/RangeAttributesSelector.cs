using System;
using System.Linq;
using TreasureGen.Selectors.Results;

namespace TreasureGen.Domain.Selectors.Attributes
{
    internal class RangeAttributesSelector : IRangeAttributesSelector
    {
        private IAttributesSelector innerSelector;

        public RangeAttributesSelector(IAttributesSelector innerSelector)
        {
            this.innerSelector = innerSelector;
        }

        public RangeAttributesResult SelectFrom(string tableName, string name)
        {
            var attributes = innerSelector.SelectFrom(tableName, name);

            if (attributes.Count() < 2)
                throw new Exception("Attributes are not in format for range");

            var minimum = attributes.First();
            var maximum = attributes.Last();

            var result = new RangeAttributesResult();
            result.Minimum = Convert.ToInt32(minimum);
            result.Maximum = Convert.ToInt32(maximum);

            return result;
        }
    }
}