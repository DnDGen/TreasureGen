using EventGen;
using System.Collections.Generic;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class MundaneItemGeneratorEventGenDecorator : MundaneItemGenerator
    {
        private GenEventQueue eventQueue;
        private MundaneItemGenerator innerGenerator;

        public MundaneItemGeneratorEventGenDecorator(MundaneItemGenerator innerGenerator, GenEventQueue eventQueue)
        {
            this.eventQueue = eventQueue;
            this.innerGenerator = innerGenerator;
        }

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning mundane item generation from template: {template.ItemType} {template.Name}");
            var item = innerGenerator.Generate(template, allowRandomDecoration);
            eventQueue.Enqueue("TreasureGen", $"Completed generation of {item.ItemType} {item.Name}");

            return item;
        }

        public Item Generate()
        {
            eventQueue.Enqueue("TreasureGen", "Beginning mundane item generation");
            var item = innerGenerator.Generate();
            eventQueue.Enqueue("TreasureGen", $"Completed generation of {item.ItemType} {item.Name}");

            return item;
        }

        public Item GenerateFromSubset(IEnumerable<string> subset)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning mundane item generation from [{string.Join(", ", subset)}]");
            var item = innerGenerator.GenerateFromSubset(subset);
            eventQueue.Enqueue("TreasureGen", $"Completed generation of {item.ItemType} {item.Name}");

            return item;
        }
    }
}
