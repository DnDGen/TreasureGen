using System;
using System.Linq;
using TreasureGen.Selectors.Results;

namespace TreasureGen.Domain.Selectors.Attributes
{
    internal class IntelligenceAttributesSelector : IIntelligenceAttributesSelector
    {
        private IAttributesSelector innerSelector;

        public IntelligenceAttributesSelector(IAttributesSelector innerSelector)
        {
            this.innerSelector = innerSelector;
        }

        public IntelligenceAttributesResult SelectFrom(string tableName, string name)
        {
            var attributes = innerSelector.SelectFrom(tableName, name).ToList();

            if (attributes.Count < 3)
                throw new Exception("Attributes are not formatted for intelligence");

            var result = new IntelligenceAttributesResult();
            result.Senses = attributes[0];
            result.LesserPowersCount = Convert.ToInt32(attributes[1]);
            result.GreaterPowersCount = Convert.ToInt32(attributes[2]);

            return result;
        }
    }
}