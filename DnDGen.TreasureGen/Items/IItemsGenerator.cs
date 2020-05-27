using System.Collections.Generic;

namespace DnDGen.TreasureGen.Items
{
    public interface IItemsGenerator
    {
        IEnumerable<Item> GenerateRandomAtLevel(int level);
        Item GenerateAtLevel(int level, string itemType, string itemName, params string[] traits);
    }
}