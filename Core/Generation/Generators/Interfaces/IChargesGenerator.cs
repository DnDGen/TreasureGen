using System;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface IChargesGenerator
    {
        Int32 GenerateChargesFor(String itemType, String name);
    }
}