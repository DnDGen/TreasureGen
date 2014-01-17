using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items;

namespace EquipmentGen.Core.Generation.Factories.Interfaces
{
    public interface IItemsFactory
    {
        IEnumerable<Item> CreateAtLevel(Int32 level);
    }
}