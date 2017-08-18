using EventGen;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Selections;

namespace TreasureGen.Domain.Selectors.Percentiles
{
    internal class TypeAndAmountPercentileSelectorEventDecorator : ITypeAndAmountPercentileSelector
    {
        private readonly GenEventQueue eventQueue;
        private readonly ITypeAndAmountPercentileSelector innerSelector;

        public TypeAndAmountPercentileSelectorEventDecorator(ITypeAndAmountPercentileSelector innerSelector, GenEventQueue eventQueue)
        {
            this.eventQueue = eventQueue;
            this.innerSelector = innerSelector;
        }

        public IEnumerable<TypeAndAmountSelection> SelectAllFrom(string tablename)
        {
            eventQueue.Enqueue("TreasureGen", $"Selecting all types and amounts from {tablename}");
            var typesAndAmounts = innerSelector.SelectAllFrom(tablename);
            eventQueue.Enqueue("TreasureGen", $"Selected {typesAndAmounts.Count()} types and amounts from {tablename}");

            return typesAndAmounts;
        }

        public TypeAndAmountSelection SelectFrom(string tableName)
        {
            return innerSelector.SelectFrom(tableName);
        }
    }
}
