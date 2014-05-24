using System;
using EquipmentGen.Generators.Interfaces.Items.Mundane;

namespace EquipmentGen.Generators.RuntimeFactories.Interfaces
{
    public interface IMundaneItemGeneratorFactory
    {
        IMundaneItemGenerator CreateGeneratorOf(String itemType);
    }
}