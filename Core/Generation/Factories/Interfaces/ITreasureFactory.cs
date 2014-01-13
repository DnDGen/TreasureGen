using System;
using EquipmentGen.Core.Data;

namespace EquipmentGen.Core.Generation.Factories.Interfaces
{
    public interface ITreasureFactory
    {
        Treasure CreateWith(Int32 level);
    }
}