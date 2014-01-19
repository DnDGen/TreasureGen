using System;

namespace EquipmentGen.Core.Generation.Factories.Interfaces
{
    public interface IGearFactoryFactory
    {
        IGearFactory CreateWith(String type);
    }
}