using System;
using EquipmentGen.Core.Data.Items;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface IGearGenerator
    {
        Gear GenerateAtLevel(Int32 level);
        Gear GenerateAtPower(String power);
    }
}