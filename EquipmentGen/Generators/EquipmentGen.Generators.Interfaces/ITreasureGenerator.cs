using System;
using EquipmentGen.Common;

namespace EquipmentGen.Generators.Interfaces
{
    public interface ITreasureGenerator
    {
        Treasure GenerateAtLevel(Int32 level);
    }
}