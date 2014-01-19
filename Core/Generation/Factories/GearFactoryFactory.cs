using System;
using EquipmentGen.Core.Generation.Factories.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class GearFactoryFactory : IGearFactoryFactory
    {
        public IGearFactory CreateWith(String type)
        {
            throw new NotImplementedException();
        }
    }
}