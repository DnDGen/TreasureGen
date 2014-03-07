using System;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface IChargesGenerator
    {
        Int32 GenerateFor(String itemType, String name);
    }
}