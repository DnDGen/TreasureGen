using EventGen;
using System.Collections.Generic;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Generators.Items.Magical
{
    internal class MagicalItemGeneratorEventDecorator : MagicalItemGenerator
    {
        private readonly GenEventQueue eventQueue;
        private readonly MagicalItemGenerator innerGenerator;

        public MagicalItemGeneratorEventDecorator(MagicalItemGenerator innerGenerator, GenEventQueue eventQueue)
        {
            this.eventQueue = eventQueue;
            this.innerGenerator = innerGenerator;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning magical item generation from template: {template.ItemType} {template.Name}");
            var item = innerGenerator.GenerateFrom(template, allowRandomDecoration);
            eventQueue.Enqueue("TreasureGen", $"Completed generation of {item.ItemType} {item.Name}");

            return item;
        }

        public Item GenerateFrom(string power)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning {power} magical item generation");
            var item = innerGenerator.GenerateFrom(power);
            eventQueue.Enqueue("TreasureGen", $"Completed generation of {power} {item.ItemType} {item.Name}");

            return item;
        }

        public Item GenerateFrom(string power, IEnumerable<string> subset, params string[] traits)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning {power} magical item generation from [{string.Join(", ", subset)}]");
            var item = innerGenerator.GenerateFrom(power, subset, traits);
            eventQueue.Enqueue("TreasureGen", $"Completed generation of {power} {item.ItemType} {item.Name}");

            return item;
        }
    }
}
