using System;
using EquipmentGen.Core.Generation.Generators.Interfaces;

namespace EquipmentGen.Core.Generation.Factories.Interfaces
{
    public interface IMagicalItemGeneratorFactory
    {
        IMagicalItemGenerator CreateWith(String type);
    }
}