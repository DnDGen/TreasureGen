using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnDGen.TreasureGen.Items
{
    public interface IItemsGenerator
    {
        IEnumerable<Item> GenerateRandomAtLevel(int level);
        Task<IEnumerable<Item>> GenerateRandomAtLevelAsync(int level);
        Item GenerateAtLevel(int level, string itemType, string itemName, params string[] traits);
        Task<Item> GenerateAtLevelAsync(int level, string itemType, string itemName, params string[] traits);
    }
}