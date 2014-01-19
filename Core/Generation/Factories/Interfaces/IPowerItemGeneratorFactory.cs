using System;
using EquipmentGen.Core.Generation.Generators.Interfaces;

namespace EquipmentGen.Core.Generation.Factories.Interfaces
{
    public interface IPowerItemGeneratorFactory
    {
        IPowerItemGenerator CreateWith(String power);
    }
}