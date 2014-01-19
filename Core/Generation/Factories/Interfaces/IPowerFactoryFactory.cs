using System;

namespace EquipmentGen.Core.Generation.Factories.Interfaces
{
    public interface IPowerFactoryFactory
    {
        IPowerFactory CreateWith(String power);
    }
}