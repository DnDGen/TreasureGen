using DnDGen.EventGen;
using System.Collections.Generic;
using System.Linq;
using DnDGen.TreasureGen.Items;

namespace DnDGen.TreasureGen.Generators.Items
{
    internal class ItemsGeneratorEventDecorator : IItemsGenerator
    {
        private readonly GenEventQueue eventQueue;
        private readonly IItemsGenerator innerGenerator;

        public ItemsGeneratorEventDecorator(IItemsGenerator innerGenerator, GenEventQueue eventQueue)
        {
            this.eventQueue = eventQueue;
            this.innerGenerator = innerGenerator;
        }

        public IEnumerable<Item> GenerateAtLevel(int level)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning level {level} items generation");
            var items = innerGenerator.GenerateAtLevel(level);
            eventQueue.Enqueue("TreasureGen", $"Completed generation of {items.Count()} level {level} items");

            return items;
        }
    }
}
