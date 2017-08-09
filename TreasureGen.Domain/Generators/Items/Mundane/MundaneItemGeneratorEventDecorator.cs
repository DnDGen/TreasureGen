using EventGen;
using System.Collections.Generic;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class MundaneItemGeneratorEventDecorator : MundaneItemGenerator
    {
        private readonly GenEventQueue eventQueue;
        private readonly MundaneItemGenerator innerGenerator;

        public MundaneItemGeneratorEventDecorator(MundaneItemGenerator innerGenerator, GenEventQueue eventQueue)
        {
            this.eventQueue = eventQueue;
            this.innerGenerator = innerGenerator;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning mundane item generation from template: {template.ItemType} {template.Name}");
            var item = innerGenerator.GenerateFrom(template, allowRandomDecoration);
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

        public Item GenerateFrom(IEnumerable<string> subset)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning mundane item generation from [{string.Join(", ", subset)}]");
            var item = innerGenerator.GenerateFrom(subset);
            eventQueue.Enqueue("TreasureGen", $"Completed generation of {item.ItemType} {item.Name}");

            return item;
        }
    }
}
