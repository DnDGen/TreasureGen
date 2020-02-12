using DnDGen.EventGen;
using DnDGen.TreasureGen.Items;
using System.Collections.Generic;
using System.Linq;

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

        public Item GenerateAtLevel(int level, string itemType, string itemName)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning level {level} {itemType} generation ({itemName})");
            var item = innerGenerator.GenerateAtLevel(level, itemType, itemName);
            eventQueue.Enqueue("TreasureGen", $"Completed generation of {item.ItemType} {item.Name}");

            return item;
        }
    }
}
