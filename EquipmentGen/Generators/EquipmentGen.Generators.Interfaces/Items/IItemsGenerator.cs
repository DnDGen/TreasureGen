using System;
using System.Collections.Generic;
using EquipmentGen.Common.Items;

namespace EquipmentGen.Generators.Interfaces.Items
{
    public interface IItemsGenerator
    {
        IEnumerable<Item> GenerateAtLevel(Int32 level);
    }
}