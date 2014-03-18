using System;
using EquipmentGen.Core.Generation.Generators.Interfaces;

namespace EquipmentGen.Core.Generation.Factories.Interfaces
{
    public interface IMundaneGearGeneratorFactory
    {
        IMundaneGearGenerator CreateWith(String type);
    }
}