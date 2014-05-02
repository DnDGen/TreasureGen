using System;
using EquipmentGen.Generators.Interfaces.Items.Magical;

namespace EquipmentGen.Generators.RuntimeFactories.Interfaces
{
    public interface IMagicalItemGeneratorFactory
    {
        IMagicalItemGenerator CreateGeneratorOf(String type);
    }
}