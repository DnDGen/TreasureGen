using EventGen;
using System.Collections.Generic;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class MagicalItemGeneratorEventGenDecorator : MagicalItemGenerator
    {
        private GenEventQueue eventQueue;
        private MagicalItemGenerator innerGenerator;

        public MagicalItemGeneratorEventGenDecorator(MagicalItemGenerator innerGenerator, GenEventQueue eventQueue)
        {
            this.eventQueue = eventQueue;
            this.innerGenerator = innerGenerator;
        }

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning magical item generation from template: {template.ItemType} {template.Name}");
            var item = innerGenerator.Generate(template, allowRandomDecoration);
            eventQueue.Enqueue("TreasureGen", $"Completed generation of {item.ItemType} {item.Name}");

            return item;
        }

        public Item GenerateAtPower(string power)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning {power} magical item generation");
            var item = innerGenerator.GenerateAtPower(power);
            eventQueue.Enqueue("TreasureGen", $"Completed generation of {power} {item.ItemType} {item.Name}");

            return item;
        }

        public Item GenerateFromSubset(string power, IEnumerable<string> subset)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning {power} magical item generation from [{string.Join(", ", subset)}]");
            var item = innerGenerator.GenerateFromSubset(power, subset);
            eventQueue.Enqueue("TreasureGen", $"Completed generation of {power} {item.ItemType} {item.Name}");

            return item;
        }
    }
}
