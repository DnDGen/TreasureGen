using System;
using EquipmentGen.Core.Data.Items;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface ISpecificGearGenerator
    {
        Item GenerateFrom(String specificGearType);
    }
}