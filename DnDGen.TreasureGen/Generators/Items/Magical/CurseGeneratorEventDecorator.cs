using DnDGen.EventGen;
using DnDGen.TreasureGen.Items;

namespace DnDGen.TreasureGen.Generators.Items.Magical
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
            eventQueue.Enqueue("TreasureGen", $"Generating a specific cursed item from template: {template.ItemType} {template.Name}");
            var item = innerGenerator.GenerateFrom(template, allowRandomDecoration);

            if (item != null)
                eventQueue.Enqueue("TreasureGen", $"Generated {item.ItemType} {item.Name}");
            else
                eventQueue.Enqueue("TreasureGen", $"No specific cursed item was generated");

            return item;
        }

        public Item Generate()
        {
            eventQueue.Enqueue("TreasureGen", "Generating a specific cursed item");
            var item = innerGenerator.Generate();

            if (item != null)
                eventQueue.Enqueue("TreasureGen", $"Generated {item.ItemType} {item.Name}");
            else
                eventQueue.Enqueue("TreasureGen", $"No specific cursed item was generated");

            return item;
        }

        public Item Generate(string itemName)
        {
            eventQueue.Enqueue("TreasureGen", $"Generating a specific cursed item ({itemName})");
            var item = innerGenerator.Generate(itemName);

            if (item != null)
                eventQueue.Enqueue("TreasureGen", $"Generated {item.ItemType} {item.Name}");
            else
                eventQueue.Enqueue("TreasureGen", $"No specific cursed item was generated");

            return item;
        }

        public string GenerateCurse()
        {
            eventQueue.Enqueue("TreasureGen", $"Generating a curse");
            var curse = innerGenerator.GenerateCurse();
            eventQueue.Enqueue("TreasureGen", $"Generated a curse of {curse}");

            return curse;
        }

        public bool HasCurse(Item item)
        {
            eventQueue.Enqueue("TreasureGen", $"Determining if item {item.Name} is cursed");
            var isCursed = innerGenerator.HasCurse(item);

            if (isCursed)
                eventQueue.Enqueue("TreasureGen", $"Item {item.Name} is cursed");
            else
                eventQueue.Enqueue("TreasureGen", $"Item {item.Name} is not cursed");

            return isCursed;
        }

        public bool IsSpecificCursedItem(Item template)
        {
            eventQueue.Enqueue("TreasureGen", $"Determining if item {template.Name} is a specific cursed item");
            var isSpecificCursed = innerGenerator.IsSpecificCursedItem(template);

            if (isSpecificCursed)
                eventQueue.Enqueue("TreasureGen", $"Item {template.Name} is a specific cursed item");
            else
                eventQueue.Enqueue("TreasureGen", $"Item {template.Name} is not a specific cursed item");

            return isSpecificCursed;
        }

        public bool IsSpecificCursedItem(string itemName)
        {
            eventQueue.Enqueue("TreasureGen", $"Determining if item {itemName} is a specific cursed item");
            var isSpecificCursed = innerGenerator.IsSpecificCursedItem(itemName);

            if (isSpecificCursed)
                eventQueue.Enqueue("TreasureGen", $"Item {itemName} is a specific cursed item");
            else
                eventQueue.Enqueue("TreasureGen", $"Item {itemName} is not a specific cursed item");

            return isSpecificCursed;
        }

        public bool CanBeSpecificCursedItem(string itemName)
        {
            eventQueue.Enqueue("TreasureGen", $"Determining if item {itemName} can be a specific cursed item");
            var canBeSpecificCursed = innerGenerator.CanBeSpecificCursedItem(itemName);

            if (canBeSpecificCursed)
                eventQueue.Enqueue("TreasureGen", $"Item {itemName} can be a specific cursed item");
            else
                eventQueue.Enqueue("TreasureGen", $"Item {itemName} cannot be a specific cursed item");

            return canBeSpecificCursed;
        }

        public bool ItemTypeCanBeSpecificCursedItem(string itemType)
        {
            eventQueue.Enqueue("TreasureGen", $"Determining if Item Type {itemType} can be a specific cursed item");
            var canBeSpecificCursed = innerGenerator.ItemTypeCanBeSpecificCursedItem(itemType);

            if (canBeSpecificCursed)
                eventQueue.Enqueue("TreasureGen", $"Item Type {itemType} can be a specific cursed item");
            else
                eventQueue.Enqueue("TreasureGen", $"Item Type {itemType} cannot be a specific cursed item");

            return canBeSpecificCursed;
        }

        public Item GenerateSpecificCursedItem(string itemType)
        {
            eventQueue.Enqueue("TreasureGen", $"Generating a specific cursed item (type {itemType})");
            var item = innerGenerator.GenerateSpecificCursedItem(itemType);

            if (item != null)
                eventQueue.Enqueue("TreasureGen", $"Generated {item.ItemType} {item.Name}");
            else
                eventQueue.Enqueue("TreasureGen", $"No specific cursed item was generated");

            return item;
        }
    }
}
