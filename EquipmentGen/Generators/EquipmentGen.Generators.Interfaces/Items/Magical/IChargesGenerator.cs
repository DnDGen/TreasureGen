using System;

namespace EquipmentGen.Generators.Interfaces.Items.Magical
{
    public interface IChargesGenerator
    {
        Int32 GenerateFor(String itemType, String name);
    }
}