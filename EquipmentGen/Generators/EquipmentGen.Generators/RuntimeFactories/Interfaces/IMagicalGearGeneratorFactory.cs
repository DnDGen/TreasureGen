using System;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Generators.Interfaces.Items.Magical;

namespace EquipmentGen.Generators.RuntimeFactories.Interfaces
{
    public interface IMagicalGearGeneratorFactory
    {
        IMagicalGearGenerator CreateWith(String type);
    }
}