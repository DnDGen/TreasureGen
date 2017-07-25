using EventGen;
using TreasureGen.Items;

namespace TreasureGen.Domain.Generators.Items
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

        public Item GenerateFrom(string power, string specificGearType)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning {power} specific {specificGearType} generation");
            var item = innerGenerator.GenerateFrom(power, specificGearType);
            eventQueue.Enqueue("TreasureGen", $"Completed generation of {item.ItemType} {item.Name}");

            return item;
        }

        public Item GenerateFrom(Item template)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning specific gear generation from template: {template.ItemType} {template.Name}");
            var item = innerGenerator.GenerateFrom(template);
            eventQueue.Enqueue("TreasureGen", $"Completed generation of {item.ItemType} {item.Name}");

            return item;
        }

        public bool TemplateIsSpecific(Item template)
        {
            eventQueue.Enqueue("TreasureGen", $"Determining if {template.Name} is a specific gear");
            var isSpecific = innerGenerator.TemplateIsSpecific(template);

            if (isSpecific)
                eventQueue.Enqueue("TreasureGen", $"{template.Name} is a specific gear");
            else
                eventQueue.Enqueue("TreasureGen", $"{template.Name} is not a specific gear");

            return isSpecific;
        }
    }
}