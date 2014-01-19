using System;
using EquipmentGen.Core.Data.Items;

namespace EquipmentGen.Core.Generation.Factories.Interfaces
{
    public interface IGearFactory
    {
        Gear CreateAtLevel(Int32 level);
        Gear CreateWith(String power);
    }
}