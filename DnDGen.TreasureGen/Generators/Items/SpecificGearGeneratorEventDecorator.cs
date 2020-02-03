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

        public bool CanBeSpecific(string power, string specificGearType, string itemName)
        {
            var canBeSpecific = innerGenerator.CanBeSpecific(power, specificGearType, itemName);

            return canBeSpecific;
        }

        public Item GenerateFrom(Item template)
        {
            eventQueue.Enqueue("TreasureGen", $"Generating specific gear from template: {template.ItemType} {template.Name}");
            var item = innerGenerator.GenerateFrom(template);
            eventQueue.Enqueue("TreasureGen", $"Generated {item.ItemType} {item.Name}");

            return item;
        }

        public string GenerateNameFrom(string power, string specificGearType, string baseType)
        {
            return innerGenerator.GenerateNameFrom(power, specificGearType, baseType);
        }

        public Item GeneratePrototypeFrom(string power, string specificGearType, string name)
        {
            return innerGenerator.GeneratePrototypeFrom(power, specificGearType, name);
        }

        public string GenerateRandomNameFrom(string power, string specificGearType)
        {
            return innerGenerator.GenerateRandomNameFrom(power, specificGearType);
        }

        public bool IsSpecific(Item template)
        {
            var isSpecific = innerGenerator.IsSpecific(template);

            return isSpecific;
        }

        public bool IsSpecific(string specificGearType, string itemName)
        {
            var isSpecific = innerGenerator.IsSpecific(specificGearType, itemName);

            return isSpecific;
        }
    }
}