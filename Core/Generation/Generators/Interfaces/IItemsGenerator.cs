using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface IItemsGenerator
    {
        IEnumerable<Item> GenerateAtLevel(Int32 level);
    }
}