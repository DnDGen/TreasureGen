using DnDGen.EventGen;
using DnDGen.TreasureGen.Items;

namespace DnDGen.TreasureGen.Generators.Items
{
    internal class SpecificGearGeneratorEventDecorator : ISpecificGearGenerator
    {
        private readonly ISpecificGearGenerator innerGenerator;
        private readonly GenEventQueue eventQueue;

        public SpecificGearGeneratorEventDecorator(ISpecificGearGenerator innerGenerator, GenEventQueue eventQueue)
        {
            this.innerGenerator = innerGenerator;
            this.eventQueue = eventQueue;
        }

        public Item GenerateFrom(Item template)
        {
            eventQueue.Enqueue("TreasureGen", $"Generating specific gear from template: {template.ItemType} {template.Name}");
            var item = innerGenerator.GenerateFrom(template);
            eventQueue.Enqueue("TreasureGen", $"Generated {item.ItemType} {item.Name}");

            return item;
        }

        public bool IsSpecific(Item template)
        {
            var isSpecific = innerGenerator.IsSpecific(template);

            return isSpecific;
        }

        public Item GenerateRandomPrototypeFrom(string power, string specificGearType)
        {
            var prototype = innerGenerator.GenerateRandomPrototypeFrom(power, specificGearType);

            return prototype;
        }
    }
}