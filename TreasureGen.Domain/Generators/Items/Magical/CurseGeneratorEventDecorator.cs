using EventGen;
using System.Collections.Generic;
using TreasureGen.Items;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class CurseGeneratorEventDecorator : ICurseGenerator
    {
        private readonly ICurseGenerator innerGenerator;
        private readonly GenEventQueue eventQueue;

        public CurseGeneratorEventDecorator(ICurseGenerator innerGenerator, GenEventQueue eventQueue)
        {
            this.innerGenerator = innerGenerator;
            this.eventQueue = eventQueue;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning specific cursed item generation from template: {template.ItemType} {template.Name}");
            var item = innerGenerator.GenerateFrom(template, allowRandomDecoration);

            if (item != null)
                eventQueue.Enqueue("TreasureGen", $"Completed generation of {item.ItemType} {item.Name}");
            else
                eventQueue.Enqueue("TreasureGen", $"No specific cursed item was generated");

            return item;
        }

        public Item Generate()
        {
            eventQueue.Enqueue("TreasureGen", "Beginning specific cursed item generation");
            var item = innerGenerator.Generate();

            if (item != null)
                eventQueue.Enqueue("TreasureGen", $"Completed generation of {item.ItemType} {item.Name}");
            else
                eventQueue.Enqueue("TreasureGen", $"No specific cursed item was generated");

            return item;
        }

        public Item GenerateFrom(IEnumerable<string> subset)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning specific cursed item generation from [{string.Join(", ", subset)}]");
            var item = innerGenerator.GenerateFrom(subset);

            if (item != null)
                eventQueue.Enqueue("TreasureGen", $"Completed generation of {item.ItemType} {item.Name}");
            else
                eventQueue.Enqueue("TreasureGen", $"No specific cursed item was generated");

            return item;
        }

        public string GenerateCurse()
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning curse generation");
            var curse = innerGenerator.GenerateCurse();
            eventQueue.Enqueue("TreasureGen", $"Completed generation of {curse}");

            return curse;
        }

        public bool HasCurse(bool isMagical)
        {
            eventQueue.Enqueue("TreasureGen", $"Determining if item is cursed");
            var isCursed = innerGenerator.HasCurse(isMagical);

            if (isCursed)
                eventQueue.Enqueue("TreasureGen", $"Item is cursed");
            else
                eventQueue.Enqueue("TreasureGen", $"Item is not cursed");

            return isCursed;
        }

        public bool IsSpecificCursedItem(Item template)
        {
            eventQueue.Enqueue("TreasureGen", $"Determining if {template.Name} is a specific cursed item");
            var isSpecificCursed = innerGenerator.IsSpecificCursedItem(template);

            if (isSpecificCursed)
                eventQueue.Enqueue("TreasureGen", $"{template.Name} is a specific cursed item");
            else
                eventQueue.Enqueue("TreasureGen", $"{template.Name} is not a specific cursed item");

            return isSpecificCursed;
        }
    }
}
