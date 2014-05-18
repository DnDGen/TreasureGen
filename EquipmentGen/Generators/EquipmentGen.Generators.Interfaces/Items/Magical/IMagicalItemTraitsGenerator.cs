using System;
using System.Collections.Generic;

namespace EquipmentGen.Generators.Interfaces.Items.Magical
{
    public interface IMagicalItemTraitsGenerator
    {
        IEnumerable<String> GenerateFor(String itemType, IEnumerable<String> attributes);
    }
}