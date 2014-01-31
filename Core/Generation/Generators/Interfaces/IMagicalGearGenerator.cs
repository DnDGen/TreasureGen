using System;
using EquipmentGen.Core.Data.Items;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface IMagicalGearGenerator
    {
        Gear GenerateAtPower(String power);
    }
}