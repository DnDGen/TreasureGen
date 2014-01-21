using System;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class MagicalItemGeneratorFactory : IMagicalItemGeneratorFactory
    {
        public IMagicalItemGenerator CreateWith(String type)
        {
            throw new NotImplementedException();
        }
    }
}