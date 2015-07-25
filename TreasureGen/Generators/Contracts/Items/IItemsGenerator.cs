using System;
using System.Collections.Generic;
using TreasureGen.Common.Items;

namespace TreasureGen.Generators.Items
{
    public interface IItemsGenerator
    {
        IEnumerable<Item> GenerateAtLevel(Int32 level);
    }
}