using System.Collections.Generic;

namespace TreasureGen.Items
{
    public interface IItemsGenerator
    {
        IEnumerable<Item> GenerateAtLevel(int level);
    }
}