using System.Collections.Generic;

namespace DnDGen.TreasureGen.Items
{
    public interface IItemsGenerator
    {
        IEnumerable<Item> GenerateAtLevel(int level);
    }
}