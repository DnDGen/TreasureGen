using System;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Generators.Interfaces.Items.Mundane;

namespace EquipmentGen.Generators.RuntimeFactories.Interfaces
{
    public interface IMundaneGearGeneratorFactory
    {
        IMundaneGearGenerator CreateWith(String type);
    }
}