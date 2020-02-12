using DnDGen.EventGen;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;

namespace DnDGen.TreasureGen.Generators.Items.Magical
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

        public Item GenerateFrom(string power, string itemName)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning {power} magical item generation ({itemName})");
            var item = innerGenerator.GenerateFrom(power, itemName);
            eventQueue.Enqueue("TreasureGen", $"Completed generation of {power} {item.ItemType} {item.Name}");

            return item;
        }

        public bool IsItemOfPower(string itemName, string power)
        {
            return innerGenerator.IsItemOfPower(itemName, power);
        }
    }
}
