using System;
using EquipmentGen.Core.Data;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface ITreasureGenerator
    {
        Treasure GenerateAtLevel(Int32 level);
    }
}